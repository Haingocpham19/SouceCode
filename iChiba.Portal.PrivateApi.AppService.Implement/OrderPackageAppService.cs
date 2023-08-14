using Core.AppModel.Response;
using Core.CustomException;
using Core.Repository.Interface;
using iChiba.OM.Model;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.Portal.Service.Interface;
using iChiba.WH.Service.Interface;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class OrderPackageAppService : BaseAppService, IOrderPackageAppService
    {
        private const string ORDER_SERVICE_BUY_FEE = "SV08";

        private readonly IUnitOfWork _unitOfWork;
        private readonly ICurrentContext _currentContext;
        private readonly IOrderPackageService _orderPackageService;
        private readonly IOrderPackageProductService _orderPackageProductService;
        private readonly IUploadFileAppService _uploadFileAppService;
        private readonly IProductTypeService _productTypeService;
        private readonly IProductTypeGroupService _productTypeGroupService;
        private readonly IExchangeratesService _exchangeratesService;
        private readonly ICodImportService _codImportService;
        private readonly IOrderService _orderService;
        private readonly IOrderServiceService _orderServiceService;
        private readonly ISupplierService _supplierService;
        private readonly ICustomerService _customerService;
        private readonly IPackageService _packageService;
        private readonly IOrderServiceMappingService _orderServiceMappingService;
        private readonly IOrderPurchaseLogService _orderPurchaseLogService;
        private readonly IOrderPurchaseService _orderPurchaseService;

        public OrderPackageAppService(
            ILogger<OrderPackageAppService> logger,
            IUnitOfWork unitOfWork,
            IOrderPackageService OrderPackageService,
            IUploadFileAppService uploadFileAppService,
            IOrderPackageProductService orderPackageProductService,
            IProductTypeService productTypeService,
            IProductTypeGroupService productTypeGroupService,
            ICurrentContext currentContext,
            IExchangeratesService exchangeratesService,
            ICodImportService codImportService,
            IOrderService orderService,
            IOrderServiceService orderServiceService,
            ISupplierService supplierService,
            ICustomerService customerService,
            IPackageService packageService,
            IOrderServiceMappingService orderServiceMappingService,
            IOrderPurchaseLogService orderPurchaseLogService,
            IOrderPurchaseService orderPurchaseService
        ) : base(logger)
        {
            _unitOfWork = unitOfWork;
            _currentContext = currentContext;
            _uploadFileAppService = uploadFileAppService;
            _orderPackageService = OrderPackageService;
            _orderPackageProductService = orderPackageProductService;
            _productTypeService = productTypeService;
            _productTypeGroupService = productTypeGroupService;
            _exchangeratesService = exchangeratesService;
            _orderService = orderService;
            _orderServiceService = orderServiceService;
            _codImportService = codImportService;
            _supplierService = supplierService;
            _customerService = customerService;
            _packageService = packageService;
            _orderServiceMappingService = orderServiceMappingService;
            _orderPurchaseLogService = orderPurchaseLogService;
            _orderPurchaseService = orderPurchaseService;
        }

        public Task<PagingResponse<IList<OrderPackageList>>> GetList(OrderPackageListRequest request)
        {
            var response = new PagingResponse<IList<OrderPackageList>>();

            TryCatch(() =>
            {
                var sorts = request.Sorts;
                var paging = request.ToPaging();
                var data = _orderPackageService.Gets(request.OrderId, request.Keyword, sorts, paging);
                var responseData = data
                    .Select(m => m.ToOrderPackageList())
                    .ToList();

                response.FromPaging(paging)
                    .SetData(responseData)
                    .Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseEntityResponse<OrderPackageList>> GetDetail(int id)
        {
            var response = new BaseEntityResponse<OrderPackageList>();

            TryCatch(() =>
            {
                var data = _orderPackageService.GetById(id);

                if (data == null)
                {
                    throw new ErrorCodeParameterException(ErrorCodeDefine.NOT_FOUND,
                        new Dictionary<string, string>()
                        {
                            { nameof(id), id.ToString() }
                        });
                }

                var responseData = data.ToOrderPackageList();

                response.SetData(responseData)
                    .Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseResponse> Add(OrderPackageAddRequest request)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var model = request.ToModel();
                _orderPackageService.Add(model);
                _unitOfWork.Commit();
                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseResponse> Update(OrderPackageUpdateRequest request)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var currentModel = _orderPackageService.GetById(request.Id);

                if (currentModel == null)
                {
                    throw new ErrorCodeParameterException(ErrorCodeDefine.NOT_FOUND,
                        new Dictionary<string, string>()
                        {
                            { nameof(request.Id), request.Id.ToString() }
                        });
                }
                var model = request.ToModel();
                _orderPackageService.Update(model);
                _unitOfWork.Commit();
                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<BaseResponse> Delete(int id)
        {
            var response = new BaseResponse();

            TryCatch(() =>
            {
                var currentModel = _orderPackageService.GetById(id);

                if (currentModel == null)
                {
                    throw new ErrorCodeParameterException(ErrorCodeDefine.NOT_FOUND,
                        new Dictionary<string, string>()
                        {
                            { nameof(id), id.ToString() }
                        });
                }

                _orderPackageService.Delete(currentModel);

                _unitOfWork.Commit();
                response.Successful();
            }, response);

            return Task.FromResult(response);
        }

        public async Task<OrderPackageImportResponse> ImportOrderPackage(OrderPackageImportRequest request)
        {
            var response = new OrderPackageImportResponse();
            await TryCatchAsync(async () =>
            {
                var fullPathFile = _uploadFileAppService.UploadFile(request.FileData, request.FileName, "UploadFile");
                if (string.IsNullOrEmpty(fullPathFile)) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND_FILE);
                var fileInfo = new FileInfo(fullPathFile);

                var excel = new ExcelPackage(fileInfo, true);
                var workSheets = excel.Workbook.Worksheets;
                if (workSheets == null) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND_FILE);

                var orderPackageModels = ConvertOrderPackageExcelToOrderPackageModel(workSheets);

                foreach (var orderPackageModel in orderPackageModels)
                {
                    var orderPackage = new OrderPackage()
                    {
                        Code = orderPackageModel.Code,
                    };
                    _orderPackageService.Add(orderPackage);
                    _unitOfWork.Commit();
                    foreach (var orderPackageProductModel in orderPackageModel.OrderPackageProducts)
                    {
                        var OrderPackageProduct = new OrderPackageProduct()
                        {
                            Name = orderPackageProductModel.Name,
                            PackageId = orderPackage.Id,
                        };
                        _orderPackageProductService.Add(OrderPackageProduct);
                    }
                    _unitOfWork.Commit();
                }
                response.Successful();
                return response;
            }, response);

            return response;




        }

        private List<OrderPackageViewModel> ConvertOrderPackageExcelToOrderPackageModel(ExcelWorksheets workSheets)
        {
            var orderPackages = new List<OrderPackageViewModel>();

            foreach (var workSheet in workSheets)
            {
                var orderPackage = new OrderPackageViewModel();
                for (var row = 4; row <= workSheet.Dimension.End.Row; row++)
                {
                    var stt = workSheet.Cells[$"A{row}"]?.Value?.ToString() ?? string.Empty;
                    var trackingCode = workSheet.Cells[$"B{row}"]?.Value?.ToString() ?? string.Empty;
                    var weight = workSheet.Cells[$"C{row}"]?.Value?.ToString() ?? string.Empty;
                    try
                    {
                        var orderPackageProduct = new OrderPackageProductAddRequest
                        {
                        };

                        orderPackage = new OrderPackageViewModel
                        {
                            Code = string.Empty,
                            OrderPackageProducts = new List<OrderPackageProductAddRequest>()
                        };

                        var length = workSheet.Cells[$"G{row}"]?.Value?.ToString();
                        var width = workSheet.Cells[$"H{row}"]?.Value?.ToString();
                        var height = workSheet.Cells[$"I{row}"]?.Value?.ToString();

                        orderPackage.Length = !string.IsNullOrEmpty(length) ? int.Parse(length) : 0;
                        orderPackage.Width = !string.IsNullOrEmpty(width) ? int.Parse(width) : 0;
                        orderPackage.Height = !string.IsNullOrEmpty(height) ? int.Parse(height) : 0;
                        orderPackage.Weight = !string.IsNullOrEmpty(weight) ? decimal.Parse(weight) : 0;

                        orderPackage.OrderPackageProducts.Add(orderPackageProduct);
                        orderPackages.Add(orderPackage);
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        throw new ErrorCodeException("FILE_FORMAT_INCORRECT");
                    }
                }
            }
            return orderPackages;
        }

        public Task<ProductTypeListResponse> GetListProductType()
        {
            var response = new ProductTypeListResponse();

            TryCatch(() =>
            {
                var productTypes = _productTypeService.Gets().Select(x => x.ToModel()).ToList();
                var productTypeGroups = _productTypeGroupService.Gets().Select(x => x.ToModel()).ToList();

                var data = new ProductTypeList
                {
                    ProductTypes = productTypes,
                    ProductTypeGroups = productTypeGroups
                };

                response.SetData(data).Successful();

            }, response);

            return Task.FromResult(response);
        }

        public Task<OrderListResponse> AddOrderTransport(List<OrderTransportAddRequest> request)
        {
            var response = new OrderListResponse();

            TryCatch(() =>
            {
                if (request.Count <= 0) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                var exchangeRate = _exchangeratesService.GetRateByCode(request[0].Currency).Result;
                var orderServiceModel = _orderServiceService.GetByCode(ORDER_SERVICE_BUY_FEE);
                var trackings = request.Select(x => x.Tracking).ToList();
                var codImports = _codImportService.GetsByTrackings(trackings).ToList();
                var supplierCodes = codImports.Select(x => x.Supplier).ToArray();
                var suppliers = supplierCodes.Length <= 0 ? new List<Supplier>()
                    : _supplierService.SupplierGetByCodes(supplierCodes);
                var customer = _customerService.GetByAccountId(_currentContext.UserId);
                var packages = _packageService.GetByTrackingCode(trackings);
                var serviceCodes = request[0].OrderServices;
                var orderServices = _orderServiceService.GetByCode(serviceCodes);

                request.ForEach(orderRequest =>
                {
                    var order = new Order
                    {
                        Tracking = orderRequest.Tracking.Trim().ToUpper(),
                        AccountId = _currentContext.UserId,
                        CustomerAddress = orderRequest.CustomerAddress,
                        CustomerDistrict = orderRequest.CustomerDistrict,
                        CustomerName = orderRequest.CustomerName,
                        CustomerPhone = orderRequest.CustomerPhone,
                        CustomerProvince = orderRequest.CustomerProvince,
                        CustomerWard = orderRequest.CustomerWard,
                        Currency = orderRequest.Currency,
                        Warehouse = orderRequest.Warehouse,
                        ShippingRouteCode = orderRequest.ShippingRouteCode,
                        ShippingRouteId = orderRequest.ShippingRouteId,
                        Surcharge = Utility.PostPriceForUS(orderRequest.Currency, (float?)orderRequest.Surcharge),
                        TransportPaymentType = 1,
                        DdimportType = "DDP_CONSUMPTION",
                        OrderType = OrderCsType.TRANSPORT,
                        OrderDate = DateTime.UtcNow,
                        BuyFee = orderServiceModel?.Price ?? 0,
                        Status = 1,
                        TrackingStatus = 1,
                        ExchangeRate = (int)exchangeRate,
                        Supporter = customer.CareBy
                    };

                    var codImport = codImports.FirstOrDefault(x => x.Tracking == order.Tracking);
                    if (codImport != null)
                    {
                        order.Surcharge = (long)codImport.Cod;
                        order.SurchargeDate = DateTime.UtcNow;
                        if (!string.IsNullOrEmpty(codImport.Supplier))
                        {
                            var supplier = suppliers.FirstOrDefault(x=>x.Code == codImport.Supplier);
                            if (supplier != null)
                            {
                                order.SurchargePay = supplier.AccountId;
                            }
                        }
                    }

                    var package = packages.FirstOrDefault(x => x.TrackingCode == order.Tracking);
                    if (package != null) order.Mawb = package.FlightCode;

                    _orderService.Add(order);
                    _unitOfWork.Commit();

                    if (orderRequest.OrderServices.Count > 0)
                    {
                        var listServiceMapping = orderServices.Select(item => new OrderServiceMapping
                        {
                            OrderId = order.Id,
                            OrderServiceId = item.Id,
                            Price = item.Price,
                            Status = item.Status
                        }).ToList();

                        _orderServiceMappingService.AddRange(listServiceMapping);
                    }
                    AddPackageAndPackageProduct(order.Id, orderRequest.Packages);
                });

                var orders = _orderService.GetByTracking(trackings);
                codImports.ForEach(item =>
                {
                    var order = orders.FirstOrDefault(x => x.Tracking == item.Tracking);
                    if (order != null)
                    {
                        item.Mawb = order.Mawb;
                        item.OrderCode = order.Code;
                        item.Note = "Tạo đơn hàng thành công";
                        item.CustomerCode = customer.Code;
                        item.Warehouse = order.Warehouse;
                        item.Currency = order.Currency;
                        item.ExchangeRate = order.ExchangeRate;
                        _codImportService.Update(item);
                        UpdateSurcharge(order.Id, order.Surcharge, order.ExchangeRate, order.SurchargePay);
                    }
                });

                _unitOfWork.Commit();
                var orderViewModels = orders.Select(x => x.ToModel()).ToList();
                response.SetData(orderViewModels).Successful();

            }, response);

            return Task.FromResult(response);
        }

        private void AddPackageAndPackageProduct(int orderId, List<OrderPackageAddRequest> orderPackages)
        {
            foreach (var item in orderPackages)
            {
                var modelPackage = item.ToModel();
                modelPackage.OrderId = orderId;
                modelPackage.OrderPackageProduct = item.PackageProducts.Select(x =>
                {
                    var product = x.ToModel();
                    product.DataType = 0;
                    return product;
                }).ToList();

                _orderPackageService.Add(modelPackage);
            }
        }

        private void UpdateSurcharge(int orderId, long? surcharge, int? exchangeRate, string payBy)
        {
            var createdBy = payBy;
            var orderPurchaseLogSurcharge = GetLastSurcharge(orderId);
            var orderPurchaseSyncStatus = new OrderPurchaseSyncStatus[]
            {
                OrderPurchaseSyncStatus.Sync,
                OrderPurchaseSyncStatus.Synced
            }
            .Select(item => item.GetHashCode())
            .ToArray();

            if (orderPurchaseLogSurcharge == null)
            {
                var orderPurchaseLog = new OrderPurchaseLog()
                {
                    ActionBy = payBy,
                    ActionDate = DateTime.UtcNow,
                    ActionType = OrderPurchaseLogActionType.SURCHARGE,
                    CreatedBy = createdBy,
                    OrderId = orderId,
                    Price = null,
                    Tax = null,
                    ShippingFee = null,
                    ExchangeRate = exchangeRate,
                    Surcharge = surcharge,
                    Status = OrderPurchaseLogStatus.Active.GetHashCode()
                };

                _orderPurchaseLogService.Add(orderPurchaseLog);

                return;
            }

            var isSynced = _orderPurchaseService.HasLogIdAndSyncStatus(orderPurchaseLogSurcharge.Id, orderPurchaseSyncStatus);

            if (isSynced)
            {
                var orderPurchaseLogCancel = new OrderPurchaseLog()
                {
                    ActionBy = orderPurchaseLogSurcharge.ActionBy,
                    ActionDate = DateTime.UtcNow.AddMilliseconds(10),
                    ActionType = OrderPurchaseLogActionType.CANCEL_SURCHARGE,
                    CreatedBy = createdBy,
                    OrderId = orderPurchaseLogSurcharge.OrderId,
                    Price = orderPurchaseLogSurcharge.Price,
                    Tax = orderPurchaseLogSurcharge.Tax,
                    ShippingFee = orderPurchaseLogSurcharge.ShippingFee,
                    ExchangeRate = orderPurchaseLogSurcharge.ExchangeRate,
                    Surcharge = orderPurchaseLogSurcharge.Surcharge,
                    Status = OrderPurchaseLogStatus.Active.GetHashCode()
                };
                var orderPurchaseLog = new OrderPurchaseLog()
                {
                    ActionBy = payBy,
                    ActionDate = DateTime.UtcNow.AddMilliseconds(20),
                    ActionType = OrderPurchaseLogActionType.SURCHARGE,
                    CreatedBy = createdBy,
                    OrderId = orderId,
                    Price = null,
                    Tax = null,
                    ShippingFee = null,
                    ExchangeRate = exchangeRate,
                    Surcharge = surcharge,
                    Status = OrderPurchaseLogStatus.Active.GetHashCode()
                };

                _orderPurchaseLogService.Add(orderPurchaseLogCancel);
                _orderPurchaseLogService.Add(orderPurchaseLog);
            }
            else
            {
                var orderPurchase = _orderPurchaseService.GetByLogId(orderPurchaseLogSurcharge.Id);

                if (orderPurchase != null)
                {
                    if (orderPurchase.SyncAccStatus != null && orderPurchaseSyncStatus.Contains(orderPurchase.SyncAccStatus.Value))
                    {
                        throw new ErrorCodeException("ORDER_SURCHAGE_SYNCED_CANT_UPDATE");
                    }

                    orderPurchase.Surcharge = surcharge;
                    orderPurchase.ActionBy = payBy;
                    orderPurchase.ActionDate = DateTime.UtcNow;

                    _orderPurchaseService.Update(orderPurchase);
                }

                orderPurchaseLogSurcharge.Surcharge = surcharge;
                orderPurchaseLogSurcharge.ActionBy = payBy;
                orderPurchaseLogSurcharge.ActionDate = DateTime.UtcNow;

                _orderPurchaseLogService.Update(orderPurchaseLogSurcharge);
            }
        }

        private OrderPurchaseLog GetLastSurcharge(int orderId)
        {
            var activeStatus = OrderPurchaseLogStatus.Active.GetHashCode();
            var lastCancelActive = _orderPurchaseLogService.GetLastByOrderId(orderId,
                activeStatus,
                OrderPurchaseLogActionType.CANCEL_BUY);

            if (lastCancelActive == null)
            {
                return _orderPurchaseLogService.GetLastAfter(orderId,
                   OrderPurchaseLogActionType.SURCHARGE);
            }

            return _orderPurchaseLogService.GetLastAfter(orderId,
                lastCancelActive.Id,
                lastCancelActive.ActionDate,
                OrderPurchaseLogActionType.SURCHARGE);
        }
    }
}
