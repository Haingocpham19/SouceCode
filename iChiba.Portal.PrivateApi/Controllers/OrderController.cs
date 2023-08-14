using Core.AppModel.Response;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.Common.Helpers;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Interface;
using Ichiba.Partner.Api.Driver.Request;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Net;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.Controllers
{
    public class OrderController : BaseController
    {
        private readonly IWebHostEnvironment env;
        private readonly IOrderService _orderService;
        private readonly ICurrentContext _currentContext;
        private readonly IOrderAppService _orderAppService;
        private readonly ICustomerAppService _customerAppService;
        private readonly IFileAppService _fileAppService;
        private readonly IProductFromUrlAppService _productFromUrlAppService;
        private readonly IExchangeratesAppService _exchangeratesAppService;

        public OrderController(
            ILogger<CustomerController> logger,
            IOrderService orderService,
            ICurrentContext currentContext,
            IOrderAppService orderAppService,
            ICustomerAppService customerAppService,
            IExchangeratesAppService exchangeratesAppService,
            IFileAppService fileAppService,
            IProductFromUrlAppService productFromUrlAppService
            ) : base(logger)
        {
            _orderService = orderService;
            _currentContext = currentContext;
            _orderAppService = orderAppService;
            _fileAppService = fileAppService;
            _customerAppService = customerAppService;
            _productFromUrlAppService = productFromUrlAppService;
            _exchangeratesAppService = exchangeratesAppService;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderListResponse))]
        public async Task<IActionResult> GetListOrder(OrderRequest request)
        {
            try
            {
                var response = await _orderAppService.GetListOrder(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(OrderResponse))]
        public async Task<IActionResult> GetOrderDetail(OrderDetailRequest request)
        {
            try
            {
                var response = await _orderAppService.GetOrderDetail(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(PackageDetailQuoteListResponse))]
        public async Task<IActionResult> GetListPackageDetailQuote(PackageDetailQuoteRequest request)
        {
            try
            {
                var response = await _orderAppService.GetListPackageDetailQuote(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<IList<OrderMessageViewModel>>))]
        public async Task<IActionResult> GetMessages(OrderMessageRequest request)
        {
            try
            {
                var response = await _orderAppService.GetMessages(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        //public async Task<IActionResult> ImportTransOrder()
        //{
        //    Stream stream = null;
        //    try
        //    {
        //        var file = Request.Form.Files[0];
        //        if (file == null)
        //            throw new ArgumentNullException("file");

        //        var jData = Request.Form["JData"].ToString();
        //        if (string.IsNullOrWhiteSpace(jData))
        //            throw new ArgumentNullException("JData");

        //        var info = JsonConvert.DeserializeObject<OrderTransportRequest>(jData);

        //        stream = file.OpenReadStream();
        //        var wb = new Workbook(stream);
        //        stream.Close();
        //        var ws = wb.Worksheets["Data"];

        //        var ranCode = wb.Worksheets.GetRangeByName("Config.Code");
        //        if (ws == null || ranCode == null || !ranCode.Value.Equals("Import_TransportOrders"))
        //            throw new Exception("File không hợp lệ");

        //        var dtExport = ws.Cells.ExportDataTableAsString(6, 0, ws.Cells.MaxDataRow + 1, 8, true);
        //        var dtData = dtExport.Clone();
        //        dtData.TableName = "Data";
        //        dtData.NormalizeImportFrom(dtExport);

        //        var dtError = dtData.Clone();
        //        dtError.Columns.Add("__Index");
        //        dtError.TableName = "Data";
        //        if (!await ValidateImportData(dtData, dtError))
        //        {
        //            var dsError = new DataSet();
        //            dsError.Tables.Add(dtError);

        //            var tmpErrorPath = Path.Combine(env.WebRootPath, "Templates/Import/Order/Import_TransportOrder_Error.xlsx");
        //            var wbError = new Workbook(tmpErrorPath);

        //            var wdError = new WorkbookDesigner(wbError);
        //            wdError.SetDataSource(dsError);
        //            wdError.Process();
        //            wdError.Workbook.CalculateFormula();

        //            var msError = new MemoryStream();
        //            wbError.Save(msError, SaveFormat.Xlsx);
        //            msError.Seek(0, SeekOrigin.Begin);

        //            var errorFileDownloadName = $"Import_TransportOrder_Error.xlsx";
        //            var provider = new FileExtensionContentTypeProvider();
        //            if (!provider.TryGetContentType(errorFileDownloadName, out var contentType))
        //            {
        //                contentType = "application/octet-stream";
        //            }

        //            return File(msError, contentType, errorFileDownloadName);
        //        }

        //        // TODO-Notify
        //        var models = new List<OrderTransportRequest>();
        //        var items = GetImportModels(dtData, info);
        //        var grpTracking = items.GroupBy(
        //            g => g.Tracking,
        //            (key, g) => new
        //            {
        //                Tracking = key,
        //                Data = g
        //            });
        //        foreach (var xTracking in grpTracking)
        //        {
        //            var m = new OrderTransportRequest
        //            {
        //                AccountId = info.AccountId,
        //                Tracking = !string.IsNullOrEmpty(xTracking.Tracking) ? xTracking.Tracking : null,
        //                Note = info.Note,
        //                OrderServices = info.OrderServices,
        //                ShippingRouteId = info.ShippingRouteId,
        //                ShippingRouteCode = info.ShippingRouteCode,
        //                Warehouse = info.Warehouse,
        //                Currency = info.Currency,
        //                DdimportType = info.DdimportType,
        //                TransportPaymentType = info.TransportPaymentType,
        //                CustomerName = info.CustomerName,
        //                CustomerPhone = info.CustomerPhone,
        //                CustomerProvince = info.CustomerProvince,
        //                CustomerDistrict = info.CustomerDistrict,
        //                CustomerWard = info.CustomerWard,
        //                CustomerAddress = info.CustomerAddress
        //            };

        //            var packages = new List<OrderPackageAddRequest>();
        //            var grpPackage = xTracking.Data.GroupBy(
        //                g => g.PackageIndex,
        //                (key, g) => new
        //                {
        //                    PackageIndex = key,
        //                    Data = g
        //                })
        //                .OrderBy(o => o.PackageIndex);
        //            foreach (var xPack in grpPackage)
        //            {
        //                var pkg = new OrderPackageAddRequest();
        //                foreach (var xPackData in xPack.Data)
        //                {
        //                    var prod = new OrderPackageProductAddRequest
        //                    {
        //                        Name = xPackData.ProductName,
        //                        NameCustom = xPackData.ProductTypeName,
        //                        Qty = xPackData.Quantity,
        //                        Price = xPackData.Price
        //                    };
        //                    pkg.PackageProducts.Add(prod);
        //                }

        //                packages.Add(pkg);
        //            }

        //            m.Packages = packages;
        //            models.Add(m);
        //        }

        //        await _orderAppService.AddRange(models);

        //        return Ok(new BaseResponse
        //        {
        //            Status = true
        //        });
        //    }
        //    catch (Exception ex)
        //    {
        //        stream?.Close();

        //        logger.LogError(ex, ex.Message);
        //        return BadRequest();
        //    }
        //}

        private Task<bool> ValidateImportData(DataTable dtData, DataTable dtError)
        {
            var isError = false;
            var iRowExcel = 8;
            var lstTracking = new HashSet<string>();
            foreach (DataRow row in dtData.Rows)
            {
                var tracking = row["Tracking"].ToString();
                if (!string.IsNullOrWhiteSpace(tracking) && OrderHelper.RegexTracking.IsMatch(tracking))
                    lstTracking.Add(tracking);
            }

            var existsListTracking = _orderService.ExistsListTracking(lstTracking);

            foreach (DataRow row in dtData.Rows)
            {
                var rowError = dtError.NewRow();

                var tracking = row["Tracking"].ToString();
                if (string.IsNullOrWhiteSpace(tracking))
                {
                    rowError["Tracking"] += "Tracking không được để trống";
                    isError = true;
                }
                else if (!OrderHelper.RegexTracking.IsMatch(tracking))
                {
                    rowError["Tracking"] += "Tracking chỉ cho phép ký tự chữ, số và từ 6 đến 20 ký tự";
                    isError = true;
                }
                else if (existsListTracking.Contains(tracking))
                {
                    rowError["Tracking"] += $"Tracking {tracking} đã tồn tại";
                    isError = true;
                }

                var packageIndex = row["PackageIndex"].ToString();
                if (packageIndex.IsEmptyCellValue())
                {
                    rowError["PackageName"] += "Kiện hàng không được để trống";
                    isError = true;
                }
                else
                {
                    var parsed = int.TryParse(packageIndex, out int result);
                    if (!parsed)
                    {
                        rowError["PackageName"] += "Kiện hàng không hợp lệ";
                        isError = true;
                    }
                }

                var prodName = row["ProductName"].ToString();
                if (string.IsNullOrWhiteSpace(prodName))
                {
                    rowError["ProductName"] += "Tên sản phẩm không được để trống";
                    isError = true;
                }

                var quantity = row["Quantity"].ToString();
                if (string.IsNullOrWhiteSpace(quantity))
                {
                    rowError["Quantity"] += "Số lượng không được để trống";
                    isError = true;
                }
                else
                {
                    var parsed = int.TryParse(quantity, out int result);
                    if (!parsed)
                    {
                        rowError["Quantity"] += "Số lượng không hợp lệ";
                        isError = true;
                    }
                }

                var price = row["Price"].ToString();
                if (string.IsNullOrWhiteSpace(price))
                {
                    rowError["Price"] += "Đơn giá không được để trống";
                    isError = true;
                }
                else
                {
                    var parsed = long.TryParse(price, out long result);
                    if (!parsed)
                    {
                        rowError["Price"] += "Đơn giá định dạng không hợp lệ";
                        isError = true;
                    }
                }

                if (isError)
                {
                    rowError["__Index"] = iRowExcel;
                    dtError.Rows.Add(rowError);
                }

                iRowExcel++;
            }

            return Task.FromResult(!isError);
        }

        private IList<OrderTransportRequest> GetImportModels(DataTable dtData, OrderTransportRequest info)
        {
            var result = new List<OrderTransportRequest>();
            foreach (DataRow row in dtData.Rows)
            {
                var tracking = row["Tracking"].ToString();
                var packageIndex = int.Parse(row["PackageIndex"].ToString());
                var prodName = row["ProductName"].ToString();

                int? prodTypeId = null;
                var strProdTypeId = row["ProductTypeId"].ToString().NormalizeCellValue();
                if (!string.IsNullOrEmpty(strProdTypeId))
                    prodTypeId = int.Parse(strProdTypeId);

                var prodTypeName = row["ProductTypeName"].ToString().NormalizeCellValue();
                var quantity = int.Parse(row["Quantity"].ToString());
                // TODO-Decimal
                var price = long.Parse(row["Price"].ToString());

                var m = new OrderTransportRequest
                {
                    //AccountId = info.AccountId,
                    Tracking = !string.IsNullOrEmpty(tracking) ? tracking : null,
                    PackageIndex = packageIndex,
                    ProductName = prodName,
                    ProductTypeId = prodTypeId.HasValue ? prodTypeId.Value : default(int),
                    ProductTypeName = prodTypeName,
                    Quantity = quantity,
                    Price = price,
                    //Note = info.Note,
                    //OrderServices = info.OrderServices,
                    //ShippingRouteId = info.ShippingRouteId,
                    //ShippingRouteCode = info.ShippingRouteCode,
                    //Warehouse = info.Warehouse,
                    //Currency = info.Currency,
                    //DdimportType = info.DdimportType,
                    //TransportPaymentType = info.TransportPaymentType,
                    //CustomerName = info.CustomerName,
                    //CustomerPhone = info.CustomerPhone,
                    //CustomerProvince = info.CustomerProvince,
                    //CustomerDistrict = info.CustomerDistrict,
                    //CustomerWard = info.CustomerWard,
                    //CustomerAddress = info.CustomerAddress
                };
                result.Add(m);
            }

            return result;
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseEntityResponse<ProductDetail>))]
        public async Task<IActionResult> GetProductUrl(ProductDetailFromUrlRequest request)
        {
            try
            {
                var data = await _productFromUrlAppService.Detail(request);
                return Ok(data);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);
                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartListResponse))]
        public async Task<IActionResult> GetListShoppingCart(ShoppingCartRequest request)
        {
            try
            {
                var response = await _orderAppService.GetListShoppingCart(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartResponse))]
        public async Task<IActionResult> AddShoppingCart(ShoppingCartRequest request)
        {
            try
            {
                var response = await _orderAppService.AddShoppingCart(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartResponse))]
        public async Task<IActionResult> DeleteShoppingCart(ShoppingCartDeleteRequest request)
        {
            try
            {
                var response = await _orderAppService.DeleteShoppingCart(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }


        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(ShoppingCartCUDResponse))]
        public async Task<IActionResult> DeleteShoppingCartItem(ShoppingCartItemDeleteRequest request)
        {
            try
            {
                var response = await _orderAppService.DeleteShoppingCartITem(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Unauthorized)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK, Type = typeof(BaseResponse))]
        public async Task<IActionResult> AddNewOrder(OrderBuyForYouAddRequest request)
        {
            try
            {
                var response = await _orderAppService.AddNewOrder(request);

                return Ok(response);
            }
            catch (Exception ex)
            {
                logger.LogError(ex, ex.Message);

                return BadRequest();
            }
        }
    }
}