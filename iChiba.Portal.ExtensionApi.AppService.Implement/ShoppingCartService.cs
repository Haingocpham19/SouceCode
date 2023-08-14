using Core.CustomException;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.ExtensionApi.AppModel.Request;
using iChiba.Portal.ExtensionApi.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppService.Implement.Adapter;
using iChiba.Portal.ExtensionApi.AppService.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using iChiba.Portal.Common;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.ExtensionApi.AppService.Implement
{
    public class ShoppingCartService : BaseAppService, IShoppingCartService
    {
        private readonly IShoppingCartCache _shoppingCartCache;
        private readonly ICurrentContext _currentContext;
        public ShoppingCartService(IShoppingCartCache shoppingCartCache, ICurrentContext currentContext, ILogger<ShoppingCartService> logger) : base(logger)
        {
            _shoppingCartCache = shoppingCartCache;
            _currentContext = currentContext;
        }

        public async Task<ShoppingCarResponse> DeleteItemCart(ShoppingItemIdRequest request)
        {
            var res = new ShoppingCarResponse();
            await TryCatchAsync(async () =>
            {
                var result = await _shoppingCartCache.DeleteItem(request.Id, _currentContext.UserId);
                res.SetData(result).Successful();
                return res;
            }, res);
            return res;
        }

        public async Task<ShoppingCarResponse> DeleteListItemCart(ShoppingListIdRequest request)
        {
            var res = new ShoppingCarResponse();
            await TryCatchAsync(async () =>
            {
                var result = await _shoppingCartCache.DeleteListItem(request.ListId, _currentContext.UserId);
                res.SetData(result).Successful();
                return res;
            }, res);
            return res;
        }

        public async Task<ShoppingCartListItemResponse> GetListShoppingCart()
        {
            var res = new ShoppingCartListItemResponse();
            await TryCatchAsync(async () => 
            {
                var shoppingCart = await _shoppingCartCache.GetByAccountId(_currentContext.UserId);
                if (shoppingCart != null)
                {
                    var shoppingcarList = shoppingCart.Select(x => x.ToViewModel()).ToList();
                    res.SetData(shoppingcarList).Successful();
                }
                else
                {
                    res.SetData(null).Successful();
                }
                return res;
            }, res);
            return res;
        }
        public async Task<ShoppingCarResponse> AddToCart(ShoppingCartRequest request)
        {
            var res = new ShoppingCarResponse();
            await TryCatchAsync(async () =>
            {
                var shoppingCartItemList = request.ShoppingCartItems.Select(x => x.ToModel()).ToList();
                var result = await _shoppingCartCache.AddListShoppingCart(shoppingCartItemList, _currentContext.UserId);
                res.SetData(result).Successful();
                return res;
            }, res);
            return res;
        }

        public async Task<ShoppingCartListItemResponse> AddItemToCart(ShoppingCartItemRequest request)
        {
            var response = new ShoppingCartListItemResponse();

            await TryCatchAsync(async () =>
            {
                #region Add to redis

                var ShoppingCartItem = new ShoppingCartItem
                {
                    AccountId = _currentContext.UserId ?? string.Empty,
                    ProductName = request.Name ?? string.Empty,
                    ProductLink = request.Url ?? string.Empty,
                    Price = request.Price ?? 0,
                    Tax = request.Tax ?? 0,
                    ServiceCode = request.ServiceCode,
                    Images = request.Images,
                    NoteOrder = request.Note ?? string.Empty,
                    TrackingNote = request.TrackingNote ?? string.Empty,
                    Weight = request.Weight ?? 0,
                    Warehouse = request.Warehouse,
                    Quantity = request.Quantity ?? 0,
                    SellerId = request.SellerId ?? string.Empty,
                    Currency = request.Currency,
                    CreatedDate = DateTime.UtcNow,
                    SourceName = request.SourceName
                };

                var responseHashset = await _shoppingCartCache.AddShoppingCartItem(ShoppingCartItem, _currentContext.UserId);
                if (!responseHashset) throw new ErrorCodeException(Common.ErrorCodeDefine.ERROR_CACHE_SHOPPING_CART);
                var res = await _shoppingCartCache.GetByAccountId(_currentContext.UserId);
                var result = res.Select(x => x.ToViewModel()).ToList();
                #endregion

                response.SetData(result).Successful();
                return response;

            }, response);

            return response;
        }
    }
}
