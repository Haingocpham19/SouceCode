using Core.AppModel.Response;
using Core.CustomException;
using iChiba.Portal.Common;
using iChibaShopping.Core.AppService.Implement;
using iChibaShopping.Core.AppService.Interface;
using iChiba.Portal.CustomException;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Implement.Adapter;
using iChiba.Portal.PublicApi.AppService.Implement.Common;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.CS.PublicApi.Driver;
using ShoppingCartItemCache = iChiba.Portal.Cache.Model.ShoppingCartItem;
using ShoppingCartsCache = iChiba.Portal.Cache.Model.ShoppingCarts;
using ErrorCodeDefine = iChiba.Portal.CustomException.ErrorCodeDefine;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class ShoppingCartAppService : BaseAppService, IShoppingCartAppService
    {
        private const int BUY_FEE_PERCENT_DEFAULT = 8;

        private readonly IShoppingCartService shoppingCartService;
        private readonly ICurrentContext currentContext;
        private readonly CustomerClient customerClient;
        private readonly ExchangeRate exchangeRate;
        private readonly BuyFeeDiscountConfig buyFeeDiscountConfig;

        public ShoppingCartAppService(ILogger<ShoppingCartAppService> logger,
            IShoppingCartService shoppingCartService,
            ICurrentContext currentContext,
            CustomerClient customerClient,
            ExchangeRate exchangeRate,
            BuyFeeDiscountConfig buyFeeDiscountConfig)
            : base(logger)
        {
            this.shoppingCartService = shoppingCartService;
            this.currentContext = currentContext;
            this.customerClient = customerClient;
            this.exchangeRate = exchangeRate;
            this.buyFeeDiscountConfig = buyFeeDiscountConfig;
        }

        private string GetIdentityRefId(string @default)
        {
            try
            {
                if (!currentContext.IsAuthenticated)
                {
                    return @default;
                }
                var userId = currentContext.UserId;

                userId = !string.IsNullOrWhiteSpace(userId) ? userId : @default;

                return userId;
            }
            catch
            {
                return @default;
            }
        }

        private async Task<int> GetBuyFee()
        {
            try
            {
                if (!currentContext.IsAuthenticated)
                {
                    const int DEFAULT_BUY_FEE_PERCENT = 8;

                    return DEFAULT_BUY_FEE_PERCENT;
                }

                var buyFeeResponse = await customerClient.GetBuyFee();
                var buyFee = buyFeeResponse != null && buyFeeResponse.Status ? buyFeeResponse.Data : BUY_FEE_PERCENT_DEFAULT;

                return buyFee;
            }
            catch
            {
                return BUY_FEE_PERCENT_DEFAULT;
            }
        }

        private async Task<int> GetBuyFeeByCurrency(string currency)
        {
            try
            {
                if (!currentContext.IsAuthenticated)
                {
                    const int DEFAULT_BUY_FEE_PERCENT = 8;

                    return DEFAULT_BUY_FEE_PERCENT;
                }

                var buyFeeResponse = await customerClient.GetBuyFeeByCurrency(currency);
                var buyFee = buyFeeResponse != null && buyFeeResponse.Status ? buyFeeResponse.Data : BUY_FEE_PERCENT_DEFAULT;

                return buyFee;
            }
            catch
            {
                return BUY_FEE_PERCENT_DEFAULT;
            }
        }

        public async Task<BaseEntityResponse<ShoppingCart>> GetCurrent(ShoppingCartGetCurrentRequest request)
        {
            var response = new BaseEntityResponse<ShoppingCart>();

            await TryCatchAsync(async () =>
            {
                var identityRefId = GetIdentityRefId(request.IdentityRefId);

                if (identityRefId == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var cart = await shoppingCartService.GetById(identityRefId);

                if (cart == null || cart.Current == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var currentCart = cart.Current;
                var cartResponse = cart.Current.ToModel();

                var jpyRate = (int)await exchangeRate.GetJPRate();
                var usdRate = (int)await exchangeRate.GetUSDRate();

                var buyFee = await GetBuyFee();
                var mercariBuyFee = BUY_FEE_PERCENT_DEFAULT;
                var now = DateTime.Now;

                if (buyFeeDiscountConfig.FromDate <= now && now <= buyFeeDiscountConfig.ToDate)
                {
                    buyFee = buyFeeDiscountConfig.BuyFeePercent;
                    mercariBuyFee = buyFeeDiscountConfig.MercariBuyFeePercent;
                }

                if (!string.IsNullOrWhiteSpace(request.RefType))
                {
                    var cartItemByRefTypes = currentCart.GetByRefType(request.RefType);

                    cartResponse.Items = cartItemByRefTypes.Select(m => m.ToModel()).ToList();
                    //cartResponse.Amount = currentCart.CalculateTotalAmount(cartItemByRefTypes);
                }

                await SetPriceVND(cartResponse, buyFee);
                cartResponse.Items = cartResponse.Items
                    .OrderByDescending(m => m.CreatedDate)
                    .ToList();


                var orderOthers = cartResponse.Items.Select(async m =>
                {
                    await SetPriceVND(m, buyFee);
                    return m;
                }).Select(x=>x.Result);


                cartResponse.Items = orderOthers.ToList();

                //cartResponse.Items
                //    .ToList()
                //    .ForEach(m => SetPriceVND(m, jpyRate, buyFee));

                response.SetData(cartResponse)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        private ShoppingCartItemCache ToShoppingCartItem(IShoppingCartAddRequest request)
        {
            var model = new ShoppingCartItemCache();

            model.Attributes = request.Attributes;
            model.PreviewImage = request.PreviewImage;
            model.Images = request.Images;
            model.Quantity = request.Quantity;
            model.Weight = request.Weight;
            model.Length = request.Length;
            model.Price = request.Price;
            model.Tax = request.Tax;
            model.Ref = request.Ref;
            model.RefType = request.RefType;
            model.ProductName = request.ProductName;
            model.ProductLink = request.ProductLink;
            model.NoteOrder = request.NoteOrder;
            model.SellerId = request.SellerId;
            model.ShippingFee = request.ShippingFee;
            model.Currency = request.Currency;

            return model;
        }

        public async Task<BaseEntityResponse<string>> Add(ShoppingCartAddRequest request)
        {
            var response = new BaseEntityResponse<string>();

            await TryCatchAsync(async () =>
            {
                var ensureWithConditions = new (Func<bool>, string)[]
                {
                    //(condition, errorCode will be throw)
                    (() => request.Weight < 0, ErrorCodeDefine.SHOPPING_CART_WEUGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Width < 0, ErrorCodeDefine.SHOPPING_CART_WIDTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Height < 0, ErrorCodeDefine.SHOPPING_CART_HEIGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Length < 0, ErrorCodeDefine.SHOPPING_CART_LENGTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Price <= 0, ErrorCodeDefine.SHOPPING_CART_PRICE_MUST_GT_0),
                    (() => string.IsNullOrWhiteSpace(request.Ref), ErrorCodeDefine.SHOPPING_CART_REF_REQUIRED),
                    (() => string.IsNullOrWhiteSpace(request.RefType), ErrorCodeDefine.SHOPPING_CART_REF_TYPE_REQUIRED)
                };

                EnsureIfConditionIsTrue(ensureWithConditions);

                var identityRefId = GetIdentityRefId(request.IdentityRefId);
                ShoppingCartsCache cart = null;

                if (!string.IsNullOrWhiteSpace(identityRefId))
                {
                    cart = await shoppingCartService.GetById(identityRefId);
                }

                string responseIdentityRefId = null;

                if (cart == null)
                {
                    cart = ShoppingCartsCache.CreateInstance(identityRefId);
                    responseIdentityRefId = cart.IdentityRefId;
                }

                const int MINIMUM_QUANTITY = 1;

                if (request.Quantity <= MINIMUM_QUANTITY)
                {
                    request.Quantity = MINIMUM_QUANTITY;
                }

                var cartItem = ToShoppingCartItem(request);

                cart.Current.Add(cartItem);
                await shoppingCartService.HashSet(cart);
                response.SetData(responseIdentityRefId)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> AddTemp(ShoppingCartAddTempRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var ensureWithConditions = new (Func<bool>, string)[]
                {
                    //(condition, errorCode will be throw)
                    (() => request.Weight < 0, ErrorCodeDefine.SHOPPING_CART_WEUGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Width < 0, ErrorCodeDefine.SHOPPING_CART_WIDTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Height < 0, ErrorCodeDefine.SHOPPING_CART_HEIGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Length < 0, ErrorCodeDefine.SHOPPING_CART_LENGTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Price <= 0, ErrorCodeDefine.SHOPPING_CART_PRICE_MUST_GT_0),
                    (() => string.IsNullOrWhiteSpace(request.Ref), ErrorCodeDefine.SHOPPING_CART_REF_REQUIRED),
                    (() => string.IsNullOrWhiteSpace(request.RefType), ErrorCodeDefine.SHOPPING_CART_REF_TYPE_REQUIRED)
                };

                EnsureIfConditionIsTrue(ensureWithConditions);

                var userId = currentContext.UserId;
                ShoppingCartsCache cart = await shoppingCartService.GetById(userId);

                if (cart == null)
                {
                    cart = ShoppingCartsCache.CreateInstance(userId);
                }

                const int MINIMUM_QUANTITY = 1;

                if (request.Quantity <= MINIMUM_QUANTITY)
                {
                    request.Quantity = MINIMUM_QUANTITY;
                }

                var cartItem = ToShoppingCartItem(request);

                cart.Temp.Clear();
                cart.Temp.Add(cartItem);
                await shoppingCartService.HashSet(cart);
                response.Successful();

                return response;
            }, response);

            return response;
        }

        private void ValidateShoppingCartAddTempRequest(ShoppingCartAddTempRequest request)
        {
            var ensureWithConditions = new (Func<bool>, string)[]
                {
                    //(condition, errorCode will be throw)
                    (() => request.Weight < 0, ErrorCodeDefine.SHOPPING_CART_WEUGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Width < 0, ErrorCodeDefine.SHOPPING_CART_WIDTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Height < 0, ErrorCodeDefine.SHOPPING_CART_HEIGHT_MUST_GT_OR_EQUAL_0),
                    (() => request.Length < 0, ErrorCodeDefine.SHOPPING_CART_LENGTH_MUST_GT_OR_EQUAL_0),
                    (() => request.Price <= 0, ErrorCodeDefine.SHOPPING_CART_PRICE_MUST_GT_0),
                    (() => string.IsNullOrWhiteSpace(request.Ref), ErrorCodeDefine.SHOPPING_CART_REF_REQUIRED),
                    (() => string.IsNullOrWhiteSpace(request.RefType), ErrorCodeDefine.SHOPPING_CART_REF_TYPE_REQUIRED)
                };

            EnsureIfConditionIsTrue(ensureWithConditions);
        }
        public async Task<BaseResponse> AddTemps(ShoppingCartAddTempMultiItemRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var cartAddTempItems = request.Items.ToList();

                cartAddTempItems.ForEach(item => ValidateShoppingCartAddTempRequest(item));

                var userId = currentContext.UserId;
                ShoppingCartsCache cart = await shoppingCartService.GetById(userId);

                if (cart == null || cart.Temp == null)
                {
                    cart = ShoppingCartsCache.CreateInstance(userId);
                }

                const int MINIMUM_QUANTITY = 1;
                cart.Temp.Clear();
                cartAddTempItems.ForEach(item =>
                {
                    if (item.Quantity <= MINIMUM_QUANTITY)
                    {
                        item.Quantity = MINIMUM_QUANTITY;
                    }

                    var cartItem = ToShoppingCartItem(item);

                    cart.Temp.Add(cartItem);
                });
                await shoppingCartService.HashSet(cart);
                response.Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Remove(ShoppingCartRemoveItemRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var identityRefId = GetIdentityRefId(request.IdentityRefId);

                if (identityRefId == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var cart = await shoppingCartService.GetById(identityRefId);

                if (cart == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                cart.Current.Remove(request.CartItemId);
                await shoppingCartService.HashSet(cart);
                response.Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Removes(ShoppingCartRemovesItemRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var identityRefId = GetIdentityRefId(request.IdentityRefId);

                if (identityRefId == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var cart = await shoppingCartService.GetById(identityRefId);

                if (cart == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                cart.Current.Remove(request.RefType, request.SellerId);
                await shoppingCartService.HashSet(cart);
                response.Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Merge(ShoppingCartMergeRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                if (string.IsNullOrWhiteSpace(request.IdentityRefId))
                {
                    response.Successful();

                    return response;
                }

                var cartAnonymous = await shoppingCartService.GetById(request.IdentityRefId);

                if (cartAnonymous == null)
                {
                    response.Successful();

                    return response;
                }

                var userId = currentContext.UserId;
                var cart = await shoppingCartService.GetById(userId);

                if (cart == null)
                {
                    cart = cartAnonymous;
                    cart.IdentityRefId = userId;

                    await shoppingCartService.HashSet(cart);
                    response.Successful();

                    return response;
                }

                cart.Merge(cartAnonymous);
                await shoppingCartService.HashSet(cart);
                await shoppingCartService.HashDelete(cartAnonymous.IdentityRefId);
                response.Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<ShoppingCart>> OrderConfirm(ShoppingCartOrderConfirmRequest request)
        {
            var response = new BaseEntityResponse<ShoppingCart>();

            await TryCatchAsync(async () =>
            {
                var userId = currentContext.UserId;
                var cart = await shoppingCartService.GetById(userId);

                if (cart == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var cartConfirm = cart.Current;

                if (!string.IsNullOrWhiteSpace(request.OrderType))
                {
                    cartConfirm = cart.Temp;
                }

                var cartResponse = cartConfirm.ToModel();

                var buyFee = await GetBuyFee();

                if (!string.IsNullOrWhiteSpace(request.RefType) && !string.IsNullOrWhiteSpace(request.SellerId))
                {
                    var cartItemByRefTypes = cartConfirm.GetByRefTypeAndSellerId(request.RefType, request.SellerId);

                    cartResponse.Items = cartItemByRefTypes.Select(m => m.ToModel()).ToList();
                    //cartResponse.Amount = cartConfirm.CalculateTotalAmount(cartItemByRefTypes);
                }

                await SetPriceVND(cartResponse, buyFee);
                cartResponse.Items = cartResponse.Items
                    .OrderByDescending(m => m.CreatedDate)
                    .ToList();

                //var orderOthers = cartResponse.Items.Select(async m =>
                //{
                //    await SetPriceVND(m, buyFee);
                //    return m;
                //}).Select(x => x.Result);

                //cartResponse.Items = orderOthers.ToList();

                //cartResponse.Items
                //    .ToList()
                //    .ForEach(m => SetPriceVND(m, jpyRate, buyFee));

                response.SetData(cartResponse)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<ShoppingCart>> OrderConfirmByListProductId(IList<string> productIds)
        {
            var response = new BaseEntityResponse<ShoppingCart>();

            await TryCatchAsync(async () =>
            {
                if (productIds == null || productIds.Count == 0)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_CONTAINS_PRODUCT);
                }

                var userId = currentContext.UserId;
                var cart = await shoppingCartService.GetById(userId);

                if (cart == null)
                {
                    throw new ErrorCodeException(ErrorCodeDefine.SHOPPING_CART_NOT_EXISTING);
                }

                var cartConfirm = cart.Current;
                var cartResponse = cartConfirm.ToModel();
                var itemProducts = cartResponse.Items.Where(g => productIds.Contains(g.Id)).ToList();
                cartResponse.Items = itemProducts;

                var buyFee = await GetBuyFee();

                await SetPriceVND(cartResponse, buyFee);
                cartResponse.Items = cartResponse.Items
                    .OrderByDescending(m => m.CreatedDate)
                    .ToList();

                var orderOthers = cartResponse.Items.Select(async m =>
                {
                    await SetPriceVND(m, buyFee);
                    return m;
                }).Select(x => x.Result);


                cartResponse.Items = orderOthers.ToList();

                response.SetData(cartResponse)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        //private void SetPriceVND(ShoppingCartItem model, int jpyRate, int usdRate, int buyFeePercent)
        //{
        //    var usdTypes = new string[] { RefType.AMAZON_US, RefType.EBAYUS };
        //    var rate = usdTypes.Contains(model.RefType) ? usdRate : jpyRate;
        //    var tax = model.Tax;
        //    var priceWithTax = model.Amount + ((decimal)model.Amount * tax / 100);
        //    var buyFee = Round(priceWithTax * buyFeePercent / 100);
        //    model.Currency = usdTypes.Contains(model.RefType) ? Constant.Currency.USD : Constant.Currency.JPY;
        //    model.Amount = Round(priceWithTax);
        //    model.BuyFee = buyFee;
        //    model.BuyFeeVND = buyFee * rate;
        //    model.AmountVND = model.Amount * rate;
        //    model.PriceVND = model.Price * rate;
        //}

        //private void SetPriceVND(ShoppingCart model, int jpyRate, int usdRate, int buyFeePercent)
        //{
        //    var totalBuyFee = 0L;
        //    var totalBuyFeeVND = 0L;

        //    var totalAmountJP = 0L;
        //    var totalAmountUSD = 0L;
        //    var totalAmountVND = 0L;
        //    var usdTypes = new string[] { RefType.AMAZON_US, RefType.EBAYUS };

        //    foreach (var item in model.Items)
        //    {
        //        var rate = usdTypes.Contains(item.RefType) ? usdRate : jpyRate;
        //        var tax = item.Tax;
        //        var priceWithTax = item.Amount + ((decimal)item.Amount * tax / 100);
        //        var buyFee = Round(priceWithTax * buyFeePercent / 100);
        //        if (item.RefType.Equals(RefType.MERCARI))
        //        {
        //            buyFee = Round(priceWithTax * BUY_FEE_PERCENT_DEFAULT / 100);
        //        }
        //        if (usdTypes.Contains(item.RefType))
        //        {
        //            totalAmountUSD += Round(priceWithTax);
        //            item.Currency = Constant.Currency.USD;
        //        }
        //        else
        //        {
        //            totalAmountJP += Round(priceWithTax);
        //            item.Currency = Constant.Currency.JPY;
        //        }

        //        totalAmountVND += Round(priceWithTax * rate);
        //        totalBuyFee += Round(buyFee);
        //        totalBuyFeeVND += Round(buyFee * rate);
        //        item.ShippingFeeVND = item.ShippingFee * rate;
        //    }
        //    model.Amount = totalAmountJP;
        //    model.AmountUSD = totalAmountUSD;
        //    model.BuyFee = totalBuyFee;
        //    model.BuyFeeVND = totalBuyFeeVND;
        //    model.AmountVND = totalAmountVND; 
        //}

        private async Task SetPriceVND(ShoppingCartItem model, int buyFeePercent)
        {
            // thuế tại nhật
            var taxAmount = ((decimal)model.Amount * model.Tax / 100);
            // giá sp bao gồm + thuế
            var priceJp = model.Amount + taxAmount;
            // công mua
            var priceJpBuyFee = model.Amount + model.ShippingFee + taxAmount;
            var buyFee = priceJpBuyFee * buyFeePercent / 100M;
            // nếu là mua bên mercari thì lấy thuế theo config
            //if (model.RefType.Equals(RefType.MERCARI))
            //{
            //    buyFee = priceJpBuyFee * BUY_FEE_PERCENT_DEFAULT / 100M;
            //}
            model.Currency = model.Currency ?? Constant.Currency.USD;
            //var rate = model.Currency == Constant.Currency.JPY ? jpyRate : usdRate;
            var rateResponse = await exchangeRate.GetRate(model.Currency);
            var rate = decimal.ToInt64(rateResponse);
            model.Amount = Round(priceJp);
            model.AmountVND = Round(priceJp * rate);
            model.BuyFee = Round(buyFee);
            model.BuyFeeVND = Round(buyFee * rate);
            model.ShippingFeeVND = Round(model.ShippingFee * rate);
            
            //model.Price = Round(priceJp);
            //model.PriceVND = model.Price * jpyRate;
        }


        private async Task SetPriceVND(ShoppingCart model, int buyFeePercent)
        {
            foreach (var item in model.Items)
            {
                // thuế tại nhật
                var taxAmount = ((decimal)item.Amount * item.Tax / 100);
                // giá sp bao gồm + thuế
                var priceJp = item.Amount + taxAmount;
                // công mua
                buyFeePercent = await GetBuyFeeByCurrency(item.Currency);
                var priceJpBuyFee = item.Amount + item.ShippingFee + taxAmount;
                var buyFee = priceJpBuyFee * buyFeePercent / 100M;
                // nếu là mua bên mercari thì lấy thuế theo config
                //if (item.RefType.Equals(RefType.MERCARI))
                //{
                //    buyFee = priceJpBuyFee * BUY_FEE_PERCENT_DEFAULT / 100M;
                //}
                item.Currency = item.Currency ?? Constant.Currency.USD;
                //var rate = item.Currency == Constant.Currency.JPY ? jpyRate : usdRate;
                var rateResponse = await exchangeRate.GetRate(item.Currency);
                var rate = decimal.ToInt64(rateResponse);
                item.Amount = Round(priceJp);
                item.AmountVND = Round(priceJp * rate);
                item.BuyFee = Round(buyFee);
                item.BuyFeeVND = Round(buyFee * rate);
                item.ShippingFeeVND = Round(item.ShippingFee * rate);
               
                item.Price = Round(priceJp);
                item.PriceVND = item.Price * rate;
            }

            model.Amount = model.Items.Sum(g => g.Amount);
            model.AmountVND = model.Items.Sum(g => g.AmountVND);
            model.BuyFee = model.Items.Sum(g => g.BuyFee);
            model.BuyFeeVND = model.Items.Sum(g => g.BuyFeeVND);
            model.ShippingFee = model.Items.Sum(g => g.ShippingFee);
            model.ShippingFeeVND = model.Items.Sum(g => g.ShippingFeeVND);

            var total = model.AmountVND + model.BuyFeeVND + model.ShippingFeeVND;
        }

        protected virtual void EnsureIfConditionIsTrue(Func<bool> condition, Action action)
        {
            var conditionIsTrue = condition.Invoke();

            if (conditionIsTrue)
            {
                action.Invoke();
            }
        }

        protected virtual void EnsureIfConditionIsTrue(Func<bool> condition, string errorCode)
        {
            EnsureIfConditionIsTrue(condition, () => throw new ErrorCodeException(errorCode));
        }

        protected virtual void EnsureIfConditionIsTrue(params (Func<bool> condition, string)[] values)
        {
            Array.ForEach(values, item => EnsureIfConditionIsTrue(item.Item1, item.Item2));
        }
        private long Round(decimal input) => (long)Math.Round(input + 0.1m, MidpointRounding.AwayFromZero);
    }
}
