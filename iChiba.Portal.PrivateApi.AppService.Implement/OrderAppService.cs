using Core.AppModel.Response;
using Core.Common;
using Core.CustomException;
using Core.Repository.Interface;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Common;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using iChiba.WH.Api.Driver;
using iChiba.WH.Service.Interface;
using Ichiba.Cdn.Client.Interface;
using Ichiba.Partner.Api.Driver.Request;
using Ichiba.WH.Api.Driver.Request;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class OrderAppService : BaseAppService, IOrderAppService
    {
        private const string ORDER_SERVICE_BUY_FEE = "SV08";

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly ApiWhClient _apiWhClient;
        private readonly CustomerDBContext _dbContext;
        private readonly IAspNetUserCache _aspNetUserCache;
        private readonly ICustomerService _customerService;
        private readonly IWarehouseService _warehouseService;
        private readonly ICodImportService _codImportService;
        private readonly IOrderService _orderService;
        private readonly ISupplierService _supplierService;
        private readonly IOrderServiceService _orderServiceService;
        private readonly IShippingRouteService _shippingRouteService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderMessageService _orderMessageService;
        private readonly IOrderPackageService _orderPackageService;
        private readonly IOrderPackageProductService _orderPackageProductService;
        private readonly IOrderServiceMappingService _orderServiceMappingService;
        private readonly IShipmentStatusHistoryService _shipmentStatusHistoryService;
        private readonly IPackageDetailQuoteService _packageDetailQuoteService;
        private readonly IPackageDetailService _packageDetailService;
        private readonly IProductService _productService;
        private readonly IPackageService _packageService;
        private readonly IShoppingCartCache _shoppingCartCache;
        private readonly IServiceChargeService _serviceChargeService;
        private readonly OM.Service.Interface.ICustomerProfileService _customerProfileService;
        private readonly ILevelService _levelService;
        private readonly IExchangeratesService _exchangeratesService;
        private readonly IFileStorage _fileStorage;

        public OrderAppService(
            ILogger<OrderAppService> logger,
            IUnitOfWork unitOfWork,
            IAspNetUserCache aspNetUserCache,
            ApiWhClient apiWhClient,
            ICustomerService customerService,
            ICurrentContext currentContext,
            IOrderMessageService orderMessageService,
            ICodImportService codImportService,
            IOrderService orderService,
            ISupplierService supplierService,
            IWarehouseService warehouseService,
            IShippingRouteService shippingRouteService,
            IOrderDetailService orderDetailService,
            IOrderServiceService orderServiceService,
            IOrderPackageService orderPackageService,
            IOrderPackageProductService orderPackageProductService,
            IOrderServiceMappingService orderServiceMappingService,
            IPackageDetailQuoteService packageDetailQuoteService,
            IShipmentStatusHistoryService shipmentStatusHistoryService,
            IPackageDetailService packageDetailService,
            IProductService productService,
            IPackageService packageService,
            OM.Service.Interface.ICustomerProfileService customerProfileService,
            IShoppingCartCache shoppingCartCache,
            IServiceChargeService serviceChargeService,
            ILevelService levelService,
            IFileStorage fileStorage,
            IExchangeratesService exchangeratesService,
            CustomerDBContext dbContext
        ) : base(logger)
        {
            _aspNetUserCache = aspNetUserCache;
            _unitOfWork = unitOfWork;
            _currentContext = currentContext;
            _customerService = customerService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _orderPackageService = orderPackageService;
            _orderPackageProductService = orderPackageProductService;
            _orderServiceMappingService = orderServiceMappingService;
            _orderMessageService = orderMessageService;
            _warehouseService = warehouseService;
            _supplierService = supplierService;
            _shippingRouteService = shippingRouteService;
            _apiWhClient = apiWhClient;
            _orderServiceService = orderServiceService;
            _codImportService = codImportService;
            _shipmentStatusHistoryService = shipmentStatusHistoryService;
            _packageDetailQuoteService = packageDetailQuoteService;
            _packageDetailService = packageDetailService;
            _productService = productService;
            _packageService = packageService;
            _shoppingCartCache = shoppingCartCache;
            _serviceChargeService = serviceChargeService;
            _customerProfileService = customerProfileService;
            _levelService = levelService;
            _exchangeratesService = exchangeratesService;
            _fileStorage = fileStorage;
            _dbContext = dbContext;
        }

        public Task<OrderListResponse> GetListOrder(OrderRequest request)
        {
            var response = new OrderListResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();
                if (request.OrderType == OrderCsType.TRANSPORT)
                {
                    response = GetListOrderVc(request);
                }
                else
                {
                    response = GetListOrderEcm(request);
                }
            }, response);
            return Task.FromResult(response);
        }

        public OrderListResponse GetListOrderEcm(OrderRequest request)
        {
            var response = new OrderListResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                // list order
                var orders = _orderService.GetListOrder(
                    _currentContext.UserId, request.OrderType, request.OrderCode,
                    request.Tracking, request.State, request.Status, request.QuoteCodes, sorts, paging
                ).ToList();
                var orderIds = orders.Select(x => x.Id).ToList();

                // list orderDetail
                var orderDetails = _orderDetailService.GetByOrderIds(orderIds);

                // list order Quote shipment
                var orderQuotes = orders.Where(x => x.QuoteCode != null).ToList();
                var orderCodes = orderQuotes.Select(x => x.Code).ToList();
                var packageDetails = _packageDetailService.GetByOrderCodes(orderCodes);
                var packageDetailQuoteIds = packageDetails.Where(x => x.PackageDetailQuoteId != null).Select(x => x.PackageDetailQuoteId.Value).ToList();

                var shipmments = _shipmentStatusHistoryService.GetByPackageDetaiQuoteId(packageDetailQuoteIds);

                // map model
                var orderDetailViewModels = orderDetails.Select(x => x.ToModel()).ToList();
                var orderViewModels = orders.Select(x => x.ToModel()).ToList();

                // orderMessage
                var orderMessages = _orderMessageService.Gets(orderIds);
                var orderMessageViewModels = orderMessages.Select(x => x.ToModel()).ToList();

                foreach (var orderViewModel in orderViewModels)
                {
                    // packageDetail
                    var packageDetail = packageDetails.FirstOrDefault(x => x.OrderCode.Equals(orderViewModel.Code));

                    // shipment
                    if (packageDetail != null && (packageDetail?.PackageDetailQuoteId ?? null) != null)
                    {
                        var shipmment = shipmments.FirstOrDefault(x => x.ShipmentId.Equals(packageDetail.PackageDetailQuoteId));
                        orderViewModel.ShippedDate = shipmment?.CreatedDate;
                    }
                    var listOrderDetail = orderDetailViewModels.Where(x => x.OrderId == orderViewModel.Id).ToList();
                    orderViewModel.ProductViewModels = listOrderDetail;
                    orderViewModel.AmountVND = OrderAdapter.GetAmountVndEcm(orderViewModel);

                    // orderMessage
                    var listOrderMessage = orderMessageViewModels.Where(x => x.OrderId.Equals(orderViewModel.Id)).ToList();
                    orderViewModel.OrderMessageViewModels = listOrderMessage;
                }
                response.FromPaging(paging)
                    .SetData(orderViewModels)
                    .Successful();
            }, response);
            return response;
        }

        public OrderListResponse GetListOrderVc(OrderRequest request)
        {
            var response = new OrderListResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();
                var orders = _orderService.GetListOrder(
                    _currentContext.UserId, request.OrderType, request.OrderCode,
                    request.Tracking, request.State, request.Status, request.QuoteCodes, sorts, paging
                ).ToList();

                // orders
                var orderIds = orders.Select(x => x.Id).ToList();
                var orderPackages = _orderPackageService.Gets(orderIds);
                var orderPackageIds = orderPackages.Select(x => x.Id).ToList();

                // orderPackageProduct
                var orderPackageProducts = _orderPackageProductService.Gets(orderPackageIds);

                // list order Quote shipment
                var orderQuotes = orders.Where(x => x.QuoteCode != null).ToList();
                var orderCodes = orderQuotes.Select(x => x.Code).ToList();
                var packageDetails = _packageDetailService.GetByOrderCodes(orderCodes);
                var packageDetailQuoteIds = packageDetails.Where(x => x.PackageDetailQuoteId != null).Select(x => x.PackageDetailQuoteId.Value).ToList();

                var shipmments = _shipmentStatusHistoryService.GetByPackageDetaiQuoteId(packageDetailQuoteIds);

                var orderViewModels = orders.Select(x => x.ToModel()).ToList();

                // orderMessage
                var orderMessages = _orderMessageService.Gets(orderIds);
                var orderMessageViewModels = orderMessages.Select(x => x.ToModel()).ToList();

                foreach (var orderViewModel in orderViewModels)
                {
                    // packageDetail
                    var packageDetail = packageDetails.Where(x => x.OrderCode.Equals(orderViewModel.Code)).FirstOrDefault();
                    // shipment
                    if (packageDetail != null && (packageDetail?.PackageDetailQuoteId ?? null) != null)
                    {
                        var shipmment = shipmments.Where(x => x.ShipmentId.Equals(packageDetail.PackageDetailQuoteId)).FirstOrDefault();
                        orderViewModel.ShippedDate = shipmment?.CreatedDate;
                    }

                    // OrderPackage
                    var orderPackageViewModels = orderPackages.Where(x => x.OrderId.Equals(orderViewModel.Id)).ToList();
                    var listOrderPackageIds = orderPackageViewModels.Select(x => x.Id).ToList();

                    // orderMessage
                    var listOrderMessage = orderMessageViewModels.Where(x => x.OrderId.Equals(orderViewModel.Id)).ToList();
                    orderViewModel.OrderMessageViewModels = listOrderMessage;

                    // OrderPackageProduct
                    var listOrderPackageProduct = orderPackageProducts.Where(x => listOrderPackageIds.Contains(x.PackageId) && x.DataType == 1).ToList();
                    orderViewModel.ProductPackages = listOrderPackageProduct.Select(x => x.ToModel()).ToList();
                    orderViewModel.AmountVND = OrderAdapter.GetAmountVndTransport(orderViewModel, listOrderPackageProduct);
                }
                response.FromPaging(paging)
                    .SetData(orderViewModels)
                    .Successful();
            }, response);
            return response;
        }

        public Task<OrderResponse> GetOrderDetail(OrderDetailRequest request)
        {
            var response = new OrderResponse();

            TryCatch(() =>
            {
                var productViewModels = new List<OrderDetailViewModel>();
                var order = _orderService.GetByCode(request.OrderCode);
                var orderViewModel = order.ToModel();

                if (order.OrderType.Equals(OrderType.TRANSPORT.GetDisplayName()))
                {
                    var orderPakages = _orderPackageProductService.Gets(order.Id);
                    var orderPakageIds = orderPakages.Select(x => x.Id).ToList();
                    var orderPakageProducts = _orderPackageProductService.Gets(orderPakageIds);
                    //productViewModels = orderPakageProducts.Select(x => x.ToModel()).ToList();
                    //orderViewModel.ProductViewModels = productViewModels;
                    orderViewModel.ProductPackages = orderPakageProducts.Select(x => x.ToModel()).ToList();
                }
                else
                {
                    var orderDetails = _orderDetailService.GetByOrderId(order.Id);
                    productViewModels = orderDetails.Select(x => x.ToModel()).ToList();
                }
                response.SetData(orderViewModel)
                    .Successful();
            }, response);

            return Task.FromResult(response);
        }

        #region CMT
        //public async Task<OrderPriceQuotesDeliveryBillCodeListResponse> GetQuotes(DeliveryBillListRequest request)
        //{
        //    try
        //    {
        //        var sorts = request.Sorts;
        //        var paging = request.ToPaging();

        //        var _request = new WareHouseFormClientRequest
        //        {
        //            Types = request.Types,
        //            WarehouseCode = request.WarehouseCode,
        //            OrderCode = request.OrderCode,
        //            OrderTypes = request.OrderTypes,
        //            CustomerName = request.CustomerName,
        //            CustomerPhone = request.CustomerPhone,
        //            CustomerIds = request.CustomerIds,
        //            DeliveryBillCode = request.DeliveryBillCode,
        //            PackageDetailStatus = request.PackageDetailStatus,
        //            CustomerId = _currentContext.UserId,
        //            Sorts = sorts,
        //            FromDate = request.FromDate,
        //            ToDate = request.ToDate,
        //            PaymentStatus = request.PaymentStatus,
        //            StatusShipment = request.StatusShipment,
        //            ShipmentFromDate = request.ShipmentFromDate,
        //            ShipmentToDate = request.ShipmentToDate,
        //            ShippedFromDate = request.ShippedFromDate,
        //            ShippedToDate = request.ShippedToDate,
        //            PageIndex = paging.PageIndex,
        //            PageSize = paging.PageSize
        //        };
        //        var data = await _apiWhClient.SearchOrderPriceQuotes(_request);
        //        foreach (var item in data.Data)
        //        {
        //            foreach (var customer in item.OrderPriceQuotesCustomer)
        //            {
        //                if (customer.Supporter != null)
        //                {
        //                    customer.EmployeeSupport = customer.Supporter.FullName;
        //                }
        //                foreach (var address in customer.PackageDetailAddress)
        //                {
        //                    if (item.COD != null)
        //                        address.PaymentCod = item.COD;
        //                    foreach (var addressDetails in address.Orders)
        //                    {
        //                        customer.CustomerAddress = addressDetails.CustomerAddress;
        //                        customer.CustomerDistrict = addressDetails.CustomerDistrict;
        //                        customer.CustomerProvince = addressDetails.CustomerProvince;
        //                        customer.CustomerWard = addressDetails.CustomerWard;
        //                        foreach (var packages in addressDetails.Packages)
        //                        {
        //                            addressDetails.TrackingCode = packages.TrackingCode;
        //                            if (packages.BinLocation != null)
        //                            {
        //                                addressDetails.NameBinLocation = packages.BinLocation.Name;
        //                            }
        //                        }
        //                        foreach (var product in addressDetails.Products)
        //                        {
        //                            addressDetails.name = product.Name;
        //                            addressDetails.Images = product.Images;
        //                            addressDetails.url = product.Url;
        //                            addressDetails.TotalAmount = product.TotalPrice;
        //                            addressDetails.TotalShippingFree = item.TotalShippingFee;
        //                            addressDetails.QtyPerUnit = product.QtyPerUnit;
        //                        }
        //                    }
        //                }
        //            }
        //        }

        //        var dataResponse = AutoMapper.Mapper.Map<Ichiba.WH.Api.Driver.Response.OrderPriceQuotesDeliveryBillCodeListResponse, OrderPriceQuotesDeliveryBillCodeListResponse>(data);

        //        #region Mapping info order

        //        if (dataResponse != null && (dataResponse.Data?.Any() ?? false))
        //        {
        //            var orderCodes = dataResponse.Data.Select(dItem => dItem.OrderPriceQuotesCustomer.Select(opItem =>
        //                opItem.PackageDetailAddress.Select(pdaItem =>
        //                    pdaItem.Orders.Select(oItem => oItem.OrderCode))))
        //                .SelectMany(item => item)
        //                .SelectMany(item => item)
        //                .SelectMany(item => item)
        //                .ToArray();

        //            var ordersOm = _orderService.GetByCodes(orderCodes).ToList();
        //            if (ordersOm != null)
        //            {
        //                var orderPackageOm = _orderPackageService.Gets(ordersOm.Select(x => x.Id).ToList());
        //                if (orderPackageOm != null)
        //                {
        //                    var productsOm = _orderPackageProductService.Gets(orderPackageOm.Select(x => x.Id).ToList()).ToList();

        //                    if (productsOm != null)
        //                    {
        //                        foreach (var orderPackage in orderPackageOm)
        //                        {
        //                            var products = productsOm.Where(x => x.PackageId.Equals(orderPackage.Id));
        //                            if (products == null) continue;
        //                            foreach (var product in products)
        //                            {
        //                                orderPackage.OrderPackageProduct.Add(product);
        //                            }
        //                        }
        //                    }
        //                }

        //                foreach (var order in ordersOm)
        //                {
        //                    var packages = orderPackageOm.Where(x => x.OrderId.Equals(order.Id));
        //                    if (packages == null) continue;
        //                    foreach (var package in packages)
        //                    {
        //                        order.OrderPackage.Add(package);
        //                    }
        //                }
        //            }
        //            /*if (ordersOM == null || !ordersOM.Any()) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);*/
        //            var orderServiceMappingModels = _orderServiceMappingService.GetByOrderId(ordersOm.Select(x => x.Id).ToList());

        //            dataResponse.Data.ToList().ForEach(dItem => dItem.OrderPriceQuotesCustomer.ForEach(opItem =>
        //                opItem.PackageDetailAddress.ForEach(pdaItem =>
        //                    pdaItem.Orders.ForEach(oItem =>
        //                    {
        //                        var orderOm = ordersOm.FirstOrDefault(x => x.Code.Equals(oItem.OrderCode));
        //                        if (orderOm == null) return;

        //                        if (orderServiceMappingModels != null && orderServiceMappingModels.Any())
        //                        {
        //                            var orderServiceMapping = orderServiceMappingModels.Where(x => x.OrderId.Equals(orderOm.Id)).ToList();
        //                            if (orderServiceMapping.Any())
        //                            {
        //                                oItem.OrderServiceMappings = new List<OrderServiceMappingViewModel>();
        //                                var orderServiceMappingModel = orderServiceMapping.Select(x => x.ToModel()).ToList();
        //                                orderServiceMappingModel.ForEach(service =>
        //                                {
        //                                    service.OrderCode = orderOm.Code;
        //                                });

        //                                oItem.OrderServiceMappings.AddRange(orderServiceMappingModel);
        //                            }
        //                        }

        //                        var orderPackages = orderOm.OrderPackage.ToList();
        //                        var productsOm = new List<OrderPackageProduct>();
        //                        orderPackages.ForEach(package =>
        //                        {
        //                            productsOm.AddRange(package.OrderPackageProduct);
        //                        });

        //                        var productsWh = oItem.Products;
        //                        foreach (var product in productsWh)
        //                        {
        //                            var productOm = productsOm.FirstOrDefault(x => x.Id.Equals(product.SourceId));
        //                            if (productOm == null) continue;

        //                            product.Weight = productOm.Weight;
        //                            product.WeightOrigin = productOm.WeightOrigin;
        //                            product.PriceStandard = productOm.PriceStandard;
        //                            product.ProductUnit = productOm.Qty.ToString();
        //                            product.DataType = productOm.DataType;
        //                        }

        //                        oItem.TotalPriceStandard = productsOm.Where(x => x.DataType != null && x.DataType == 1).Sum(x => (x.PriceStandard ?? 0M) * x.Qty);
        //                        oItem.WeightWarehouse = oItem.Weight;
        //                        oItem.Weight = orderOm.Weight;
        //                        oItem.WeightOrigin = productsOm.Where(x => x.DataType != null && x.DataType == 1).Sum(x => x.WeightOrigin ?? 0M);
        //                        oItem.DeliveryFee = orderOm.DeliveryFee;
        //                        oItem.DeliveryPayType = orderOm.DeliveryPayType;
        //                        oItem.Total = orderOm.Total ?? oItem.Total ?? 0M;
        //                        oItem.Surcharge = orderOm.Surcharge ?? oItem.Surcharge ?? 0M;
        //                        oItem.SurchargeVND = orderOm.ExchangeRate != null ? (oItem.Surcharge * orderOm.ExchangeRate) : oItem.Surcharge;
        //                        oItem.Note = orderOm.Note ?? string.Empty;
        //                        oItem.SurchargeBy = orderOm.SurchargeBy ?? null;
        //                        oItem.SurchargePay = orderOm.SurchargePay ?? null;
        //                        oItem.TotalPayment = orderOm.TotalPayment ?? 0L;
        //                        oItem.Paid = orderOm.Paid ?? 0L;
        //                        oItem.ExchangeRate = orderOm.ExchangeRate;
        //                        oItem.TotalServiceFee = orderOm.TotalServiceFee;
        //                        oItem.CurrencyCode = orderOm.Currency;
        //                        oItem.SurchargeByFee = (long)Math.Round((long)(oItem.SurchargeVND ?? 0 * oItem.BuyFee ?? 0) / 100f, MidpointRounding.AwayFromZero);

        //                        dItem.DeliveryFee += orderOm.DeliveryFee ?? 0;
        //                    }))));
        //        }

        //        #endregion


        //        return dataResponse;
        //    }
        //    catch (Exception ex)
        //    {
        //        logger.LogError(ex, ex.Message);
        //        throw new ErrorCodeException(ErrorCodeDefine.THERE_WAS_AN_ERROR_DURING_EXECUTION);
        //    }

        //}

        //public async Task<ReviewOrderPriceQuotesViewModelResponse> ReviewOrderPriceQuotes(DeliveryBillExportRequest request)
        //{
        //    try
        //    {
        //        var _request = new WareHouseClientExportRequest
        //        {
        //            Ids = request.Ids,
        //            shippingType = request.ShippingType.GetHashCode(),
        //            shippingFee = request.ShippingFee ?? 0M,
        //            packageDetailQuotesType = request.PackageDetailQuotesType.GetHashCode(),
        //            shippingUnitType = request.ShippingUnitType.GetHashCode(),
        //            binLocationId = request.BinLocationId ?? 0,
        //            region = request.Region,
        //            hasQuotes = request.HasQuotes,
        //            ShippingService = request.ShippingService,
        //            CustomerId = request.CustomerId,
        //            WareHouseCode = request.WareHouseCode
        //        };

        //        var data = await _apiWhClient.ReviewOrderPriceQuotes(_request);
        //        var dataMappings = AutoMapper.Mapper.Map<Ichiba.WH.Api.Driver.Response.ReviewOrderPriceQuotesResponse, ReviewOrderPriceQuotesViewModelResponse>(data);
        //        return dataMappings;
        //    }
        //    catch (Exception ex)
        //    {
        //        return null;
        //    }
        //}
        #endregion

        public Task<PackageDetailQuoteListResponse> GetListPackageDetailQuote(PackageDetailQuoteRequest request)
        {
            var response = new PackageDetailQuoteListResponse();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();

                var packageDetailQuotes = _packageDetailQuoteService.Gets(
                    _currentContext.UserId, request.BillCode, request.PoNumber,
                    request.PaymentStatus, request.QuoteType, request.Status, sorts, paging
                ).ToList();

                var billCodes = packageDetailQuotes.Select(x => x.Code).ToList();
                var packageDetails = _packageDetailService.GetByDeliveryBillCode(billCodes).ToList();

                var packageDetailIds = packageDetails.Select(x => x.Id).ToList();
                var products = _productService.GetByPackageDetaiId(packageDetailIds).ToList();
                if (request.QuoteType.Count > 0 && !request.QuoteType.Contains(EnumDefine.PackageDetailQuotesType.ECommerce.GetHashCode()))
                {
                    products = products.Where(x => x.DataType == 1).ToList();
                }

                var packageIds = packageDetails.Select(x => (int)x.PackageId).ToList();
                var packages = _packageService.GetById(packageIds).ToList();

                var packageDetailViewModels = packageDetails.Select(x =>
                {
                    var item = x.ToModel();
                    var product = products.Where(m => m.PackageDetailId == item.Id).ToList();
                    item.Products = product.Select(m => m.ToModel()).ToList();
                    var package = packages.FirstOrDefault(m => m.Id == item.PackageId);
                    item.TrackingCode = package?.TrackingCode ?? null;
                    return item;
                }).ToList();

                var data = packageDetailQuotes.Select(x =>
                {
                    var item = x.ToModel();
                    var packageDetailOfBills = packageDetailViewModels.Where(m => m.DeliveryBillCode == item.Code).ToList();
                    item.PackageDetails = packageDetailOfBills;
                    if (packageDetailOfBills.Count > 3)
                    {
                        item.PackageDetailDisplays = new List<PackageDetailViewModel>
                        {
                            packageDetailOfBills[0], packageDetailOfBills[1], packageDetailOfBills[2]
                        };
                    }
                    else
                    {
                        item.PackageDetailDisplays = packageDetailOfBills;
                    }
                    item.TotalAmountOrder = packageDetailOfBills.Sum(m => m.TotalAmount ?? 0);
                    item.TotalShippingFee = packageDetailOfBills.SelectMany(m => m.Products).Sum(m => (m.PriceWeight ?? 0) * (m.WeightQuote ?? 0));
                    var deliveryFee = packageDetailOfBills.Sum(m => m.ShippingFeeDomestic ?? 0);
                    if (deliveryFee > 0)
                    {
                        item.ShipmentMoneyCollect = 0;
                    }
                    item.Total = item.TotalAmountOrder + (item.ShipmentMoneyCollect ?? 0);
                    return item;
                }).ToList();

                response.FromPaging(paging).SetData(data).Successful();
            }, response);

            return Task.FromResult(response);
        }

        public async Task<BaseEntityResponse<IList<OrderMessageViewModel>>> GetMessages(OrderMessageRequest request)
        {
            var response = new BaseEntityResponse<IList<OrderMessageViewModel>>();

            await TryCatchAsync(async () =>
            {
                var data = _orderMessageService.Gets(request.OrderId);
                var authorIds = data.Select(m => m.Author).ToArray();
                var authors = await _aspNetUserCache.GetByIds(authorIds);
                var responseData = data.Select(m =>
                {
                    var model = m.ToModel();
                    var authorDisplay = authors?.Where(x => x != null)
                        .FirstOrDefault(x => x.Id.Equals(m.Author))?.FullName;

                    model.CreatedDate = model.CreatedDate.ToLocalTime();

                    if (!string.IsNullOrWhiteSpace(authorDisplay))
                    {
                        model.AuthorDisplay = authorDisplay;
                    }

                    return model;
                }).OrderByDescending(m => m.CreatedDate).ToList();

                response.SetData(responseData)
                    .Successful();

                return response;
            }, response);

            return response;
        }

        #region CURD

        public Task<BaseResponse> Add(OrderTransportRequest request)
        {
            var response = new BaseResponse();

            if (!request.ShippingRouteId.HasValue)
                throw new ArgumentNullException(nameof(request.ShippingRouteId));

            TryCatch(() =>
            {
                var codImport = _codImportService.GetsByTracking(request.Tracking);
                var orderServiceModel = _orderServiceService.GetByCode(ORDER_SERVICE_BUY_FEE);
                var model = request.ToModelOrderTransport();
                model.BuyFee = orderServiceModel?.Price ?? 0;
                model.Tracking = !string.IsNullOrWhiteSpace(model.Tracking)
                    ? model.Tracking.ToUpper() : null;
                model.OrderType = OrderCsType.TRANSPORT;
                model.Status = 1;
                model.TrackingStatus = 1;
                var shippingRoute = _shippingRouteService.GetById(request.ShippingRouteId.Value);
                model.ShippingRouteId = shippingRoute.Id;
                model.ShippingRouteCode = shippingRoute.Code;
                var warehouse = _warehouseService.GetByCode(request.Warehouse);
                //var exchangerates = exchangeratesAppService.GetRateByCode(warehouse.Currency);
                //model.ExchangeRate = exchangerates.Result.AsInt();
                model.Warehouse = warehouse.Code;
                model.Currency = warehouse.Currency;
                model.DdimportType = "DDP_CONSUMPTION";
                model.TransportPaymentType = 1;
                //if (packageWarehouse != null)
                //{
                //    model.Mawb = !string.IsNullOrWhiteSpace(packageWarehouse.FlightCode) ? packageWarehouse.FlightCode : null;
                //}
                if (codImport != null)
                {
                    model.Surcharge = Convert.ToInt64(codImport.Cod);
                    model.SurchargeDate = DateTime.UtcNow;
                    if (!string.IsNullOrWhiteSpace(codImport.Supplier))
                    {
                        var supplier = _supplierService.GetByCode(codImport.Supplier);
                        if (supplier != null)
                        {
                            model.SurchargePay = supplier.AccountId;
                        }
                    }
                }
                _orderService.Add(model);
                _unitOfWork.Commit();

                var order = _orderService.GetsByTracking(model.Tracking);
                if (codImport != null && order != null)
                {
                    var customer = _customerService.GetByAccountId(_currentContext.UserId);
                    codImport.Mawb = order.Mawb;
                    codImport.OrderCode = order.Code;
                    codImport.Note = "Tạo đơn hàng thành công";
                    codImport.CustomerCode = customer.Code;
                    codImport.Warehouse = order.Warehouse;
                    //if (packageWarehouse != null)
                    //{
                    //    codImport.Mawb = !string.IsNullOrWhiteSpace(packageWarehouse.FlightCode) ? packageWarehouse.FlightCode : null;
                    //}
                    _codImportService.Update(codImport);
                    _unitOfWork.Commit();

                    //UpdateSurcharge(order.Id, order.Surcharge, order.ExchangeRate, order.SurchargePay);
                }



                if (request.OrderServices.Count > 0)
                {
                    var listOrderService = _orderServiceService.GetByIds(request.OrderServices);
                    var listServiceMapping = new List<OrderServiceMapping>();
                    foreach (var item in listOrderService)
                    {
                        listServiceMapping.Add(new OrderServiceMapping()
                        {
                            OrderId = model.Id,
                            OrderServiceId = item.Id,
                            Price = item.Price,
                            Status = item.Status,
                        });
                    }
                    _orderServiceMappingService.AddRange(listServiceMapping);
                    _unitOfWork.Commit();
                }

                AddPackageAndPackageProduct(model.Id, request.Packages);
                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public async Task<BaseResponse> AddRange(IEnumerable<OrderTransportRequest> requests)
        {
            using (var transaction = _dbContext.Database.BeginTransaction())
            {
                try
                {
                    foreach (var request in requests)
                    {
                        var res = await Add(request);
                        if (!res.Status)
                        {
                            transaction.Rollback();
                            return new BaseResponse
                            {
                                Status = false,
                                Parameters = new Dictionary<string, string>
                                {
                                    {"Message", res.ErrorCode}
                                }
                            };
                        }
                    }

                    transaction.Commit();

                    var response = new BaseResponse();
                    response.Successful();

                    return response;
                }
                catch (Exception ex)
                {
                    transaction.Rollback();

                    return new BaseResponse
                    {
                        Status = false,
                        Parameters = new Dictionary<string, string>
                        {
                            {"Message", ex.Message}
                        }
                    };
                }
            }
        }

        private void AddPackageAndPackageProduct(int orderId, IList<OrderPackageAddRequest> orderPackages)
        {
            foreach (var item in orderPackages)
            {
                var modelPackage = item.ToModel();
                modelPackage.OrderId = orderId;
                _orderPackageService.Add(modelPackage);
                _unitOfWork.Commit();

                item.PackageProducts.ToList().ForEach(g =>
                {
                    var modelPackageProduct = g.ToModel();
                    modelPackageProduct.PackageId = modelPackage.Id;
                    _orderPackageProductService.Add(modelPackageProduct);
                });

                _unitOfWork.Commit();
            }
        }

        public async Task<ShoppingCartListResponse> GetListShoppingCart(ShoppingCartRequest request)
        {
            var response = new ShoppingCartListResponse();
            await TryCatchAsync(async () =>
            {
                var ShoppingCartCacheModels = new List<ShoppingCartViewModel>();
                var shoppingCartCache = await _shoppingCartCache.GetByAccountId(_currentContext.UserId);
                if (shoppingCartCache == null)
                {
                    ShoppingCartCacheModels = null;
                }
                else
                {
                    var service = _serviceChargeService.GetAll();

                    ShoppingCartCacheModels = shoppingCartCache.Select(x => x.ToModel()).ToList();
                    foreach (var shoppingCartCacheModel in ShoppingCartCacheModels)
                    {
                        if (shoppingCartCacheModel.Currency != null)
                        {
                            var exchangerates = _exchangeratesService.GetRateByCode(shoppingCartCacheModel.Currency);
                            if (exchangerates != null)
                            {
                                shoppingCartCacheModel.Exchangerate = decimal.ToInt32(exchangerates.Result);
                            }
                        }
                        shoppingCartCacheModel.Image = shoppingCartCacheModel.Images.FirstOrDefault();
                        var listService = service.Where(x => shoppingCartCacheModel.ServiceCode.Contains(x.Code)).ToList();
                        shoppingCartCacheModel.ServiceCharge = listService;
                    }
                }
                response.SetData(ShoppingCartCacheModels).Successful();
                return response;

            }, response);

            return response;
        }

        public async Task<ShoppingCartResponse> AddShoppingCart(ShoppingCartRequest request)
        {
            var response = new ShoppingCartResponse();

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
                    CreatedDate = DateTime.UtcNow
                };

                var responseHashset = await _shoppingCartCache.AddShoppingCartItem(ShoppingCartItem, _currentContext.UserId);
                if (!responseHashset) throw new ErrorCodeException(Common.ErrorCodeDefine.ERROR_CACHE_SHOPPING_CART);

                #endregion

                response.SetData(ShoppingCartItem.ToModel()).Successful();
                return response;

            }, response);

            return response;
        }

        public async Task<ShoppingCartResponse> DeleteShoppingCart(ShoppingCartDeleteRequest request)
        {
            var response = new ShoppingCartResponse();

            await TryCatchAsync(async () =>
            {
                #region Delete to redis

                var responseHashset = await _shoppingCartCache.DeleteListItem(request.Ids, _currentContext.UserId);
                if (!responseHashset) throw new ErrorCodeException(Common.ErrorCodeDefine.ERROR_CACHE_SHOPPING_CART);
                #endregion

                response.Successful();
                return response;

            }, response);

            return response;
        }

        public MemberShipLevelERP GetCustomerProfileErp(string AccountId)
        {
            var response = new MemberShipLevelERP();
            try
            {
                var id = Convert.ToInt32(AccountId);
                var levelDefault = _levelService.GetByLevelId(1);
                response.AccountId = _currentContext.UserId;
                var cuslevel = _customerProfileService.GetByKey(_currentContext.UserId, "LEVEL");
                var freeBuyUS = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_US");
                var freeBuyjp = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_JP");
                var freeBuykr = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_KR");
                var freeBuyuk = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_UK");
                var freeBuyge = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_GE");
                var freeBuycn = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_CN");
                var freeBuyvc = _customerProfileService.GetByKey(_currentContext.UserId, "FEEBUY_VC");
                var cusProfileFEE_STANDARD = _customerProfileService.GetByKey(_currentContext.UserId, "FEE_STANDARD");
                var cusProfileFEETRAN = _customerProfileService.GetByKey(_currentContext.UserId, "FEETRAN");
                var cusProPercentBulky = _customerProfileService.GetByKey(_currentContext.UserId, "PERCENT_BULKY");
                var cusProFeeTranBulky = _customerProfileService.GetByKey(_currentContext.UserId, "FEE_TRAN_BULKY");

                response.level1 = cuslevel != null ? Convert.ToInt32(cuslevel.Value) : levelDefault.Level1;
                response.FeebuyUs = freeBuyUS != null ? freeBuyUS.Value : levelDefault.FeebuyUs.Value.ToString();
                response.FeebuyJp = freeBuyjp != null ? freeBuyjp.Value : levelDefault.FeebuyJp.Value.ToString();
                response.FeebuyKr = freeBuykr != null ? freeBuykr.Value : levelDefault.FeebuyKr.Value.ToString();
                response.FeebuyUk = freeBuyuk != null ? freeBuyuk.Value : levelDefault.FeebuyUk.Value.ToString();
                response.FeebuyGe = freeBuyge != null ? freeBuyge.Value : levelDefault.FeebuyGe.Value.ToString();
                response.FeebuyCn = freeBuycn != null ? freeBuycn.Value : levelDefault.FeebuyCn.Value.ToString();
                response.FeebuyVc = freeBuyvc != null ? freeBuyvc.Value : levelDefault.FeebuyVc.Value.ToString();
                response.PercentBulky = cusProPercentBulky != null ? cusProPercentBulky.Value : levelDefault.PercentBulky.ToString();
                response.FeeTranBulky = cusProFeeTranBulky != null ? cusProFeeTranBulky.Value : levelDefault.FeeTranBulky.ToString();

                response.feetran = cusProfileFEETRAN != null ? cusProfileFEETRAN.Value : null;
                var data = _levelService.GetById(response.level1);
                response.fee_standard = cusProfileFEE_STANDARD != null ? cusProfileFEE_STANDARD.Value : null;
                response.title = response.level1 == data.Level1 ? data.Title : "";
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
            }
            return response;
        }

        public Task<OrderBuyForYouAddResponse> AddNewOrder(OrderBuyForYouAddRequest request)
        {
            var response = new OrderBuyForYouAddResponse();
            TryCatch(() =>
            {
                long? TotalShippingFee = 0;
                var customerProfile = GetCustomerProfileErp(_currentContext.UserId);
                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                var listOrderId = new List<int>();
                var listId = new List<string>();
                var ids = request.Orderdetail.Select(x => x.Id).ToList();
                listId.AddRange(ids);

                foreach (var item in request.Orderdetail)
                {
                    if (Common.Utility.CurrencyConverts.Contains(item.Currency))
                    {
                        item.Price = item.Price != null ? item.Price * 100 : 0;
                        item.Tax = item.Tax != null ? item.Tax * 100 : 0;
                        item.ShippingFee = item.ShippingFee != null ? item.ShippingFee * 100 : 0;
                    }

                    if (item.ShippingFee != null)
                    {
                        TotalShippingFee += (long)item.ShippingFee;
                        request.ShippingFee = TotalShippingFee;
                    }
                    else
                    {
                        request.ShippingFee = null;
                    }
                    if (item.Currency != null)
                    {
                        if (customerProfile != null)
                        {
                            if (item.Currency == "USD")
                            {
                                request.BuyFee = Convert.ToInt32(customerProfile.FeebuyUs);
                            }

                            if (item.Currency == "JPY")
                            {
                                request.BuyFee = Convert.ToInt32(customerProfile.FeebuyJp);
                            }

                            if (item.Currency == "KRW")
                            {
                                request.BuyFee = Convert.ToInt32(customerProfile.FeebuyKr);
                            }

                            if (item.Currency == "GBP")
                            {
                                request.BuyFee = Convert.ToInt32(customerProfile.FeebuyUk);
                            }

                            if (item.Currency == "EUR")
                            {
                                request.BuyFee = Convert.ToInt32(customerProfile.FeebuyGe);
                            }
                        }

                        try
                        {
                            using (WebClient webClient = new WebClient())
                            {
                                const string DEFAULT_CREATED_UID = "default";
                                var imageBytes = webClient.DownloadData(item.PreviewImage);
                                var uploadResult = _fileStorage.Upload(DEFAULT_CREATED_UID, "preview_image_" + item.OrderCode + ".jpg", imageBytes);
                                if (uploadResult.Status.Equals(true))
                                    item.DownloadImages = uploadResult.Result.FullUrl;
                            }
                        }
                        catch (Exception ex) { }
                        item.RefType = string.IsNullOrWhiteSpace(item.SourceName) ? OrderRefType.WEBLINK : item.SourceName == "AUCTION" ? OrderRefType.WEBLINK : item.SourceName;
                        request.OrderType = string.IsNullOrWhiteSpace(item.SourceName) ? OrderRefType.WEBLINK : item.SourceName == "AUCTION" ? OrderRefType.WEBLINK : item.SourceName;
                    }
                    else
                    {
                        item.RefType = OrderRefType.WEBLINK;
                        request.OrderType = OrderRefType.WEBLINK;

                        if (item.Currency == "USD")
                        {
                            request.BuyFee = Convert.ToInt32(customerProfile.FeebuyUs);
                        }

                        if (item.Currency == "JPY")
                        {
                            request.BuyFee = Convert.ToInt32(customerProfile.FeebuyJp);
                        }

                        if (item.Currency == "KRW")
                        {
                            request.BuyFee = Convert.ToInt32(customerProfile.FeebuyKr);
                        }

                        if (item.Currency == "GBP")
                        {
                            request.BuyFee = Convert.ToInt32(customerProfile.FeebuyUk);
                        }

                        if (item.Currency == "EUR")
                        {
                            request.BuyFee = Convert.ToInt32(customerProfile.FeebuyGe);
                        }
                    }

                    if (item.Currency != null)
                    {
                        var exchangerates = _exchangeratesService.GetRateByCode(item.Currency);
                        request.Exchangerate = exchangerates != null ? decimal.ToInt32(exchangerates.Result) : 0;
                        item.ExchangeRate = exchangerates != null ? decimal.ToInt32(exchangerates.Result) : 0;
                    }
                    if (request.Exchangerate == null)
                    {
                        response.Status = false;
                        response.ErrorCode = Common.ErrorCodeDefine.COULD_NOT_GET_EXCHANGE_RATE;
                    }
                    request.Currency = item.Currency;
                    request.WareHouse = item.Warehouse;

                    var model = request.ToModelAddRequest();
                    model.GuidId = Guid.NewGuid();
                    model.Supporter = customer.CareBy ?? string.Empty;
                    model.Total = (long)item.Price;
                    model.AccountId = _currentContext.UserId;
                    model.OrderDate = DateTime.UtcNow;
                    model.Note = "ITTEST-123";
                    _orderService.Add(model);
                    _unitOfWork.Commit();
                    listOrderId.Add(model.Id);

                    var orderDetail = new Orderdetail
                    {
                        OrderId = model.Id,
                        ProductName = item.ProductName,
                        ProductLink = item.ProductLink,
                        PreviewImage = item.Images,
                        Images = item.Images,
                        Amount = item.Amount,
                        Price = (long)item.Price,
                        Tax = (int)item.Tax,
                        ExchangeRate = item.ExchangeRate,
                        BuyFee = request.BuyFee,
                        RefType = item.RefType,
                        OrderDate = DateTime.UtcNow,

                    };
                    _orderDetailService.Add(orderDetail);
                    _unitOfWork.Commit();
                }
                var result = _orderService.GetByIds(listOrderId);
                var resultOrder = result.Select(x => x.ToModelAddResponse()).ToList();
                response.SetData(resultOrder).Successful();
                _shoppingCartCache.DeleteListItem(listId, _currentContext.UserId);
            }, response);
            return Task.FromResult(response);
        }

        public async Task<ShoppingCartCUDResponse> DeleteShoppingCartITem(ShoppingCartItemDeleteRequest request)
        {
            var response = new ShoppingCartCUDResponse();

            await TryCatchAsync(async () =>
            {
                #region Delete to redis

                var responseHashset = await _shoppingCartCache.DeleteItem(request.Id, _currentContext.UserId);
                if (!responseHashset) throw new ErrorCodeException(Common.ErrorCodeDefine.ERROR_CACHE_SHOPPING_CART);
                #endregion
                response.SetData(responseHashset).Successful();
                return response;

            }, response);

            return response;
        }

        #endregion
    }
}