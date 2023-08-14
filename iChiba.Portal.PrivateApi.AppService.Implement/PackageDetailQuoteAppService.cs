using Core.CustomException;
using iChiba.OM.Service.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Common;
using iChiba.Portal.CustomException;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using iChiba.Portal.PrivateApi.AppService.Implement.Adapter;
using iChiba.Portal.PrivateApi.AppService.Interface;
using iChiba.WH.Service.Interface;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static iChiba.Portal.Common.EnumDefine;
using ErrorCodeDefine = iChiba.Portal.CustomException.ErrorCodeDefine;

namespace iChiba.Portal.PrivateApi.AppService.Implement
{
    public class PackageDetailQuoteAppService : BaseAppService, IPackageDetailQuoteAppService
    {
        private readonly ICurrentContext _currentContext;
        private readonly IHostingEnvironment _environment;
        private readonly IPackageDetailQuoteService _packageDetailQuoteService;
        private readonly IPackageDetailService _packageDetailService;
        private readonly IProductService _productService;
        private readonly IPackageService _packageService;
        private readonly IFlightService _flightService;
        private readonly IAspNetUserCache _aspNetUserCache;
        private readonly ICustomerService _customerService;
        private readonly IExportExcelAppService _exportExcelAppService;

        public PackageDetailQuoteAppService(
            ILogger<PackageDetailQuoteAppService> logger,
            IAspNetUserCache aspNetUserCache,
            ICurrentContext currentContext,
            IHostingEnvironment environment,
            IPackageDetailQuoteService packageDetailQuoteService,
            IPackageDetailService packageDetailService,
            IProductService productService,
            IPackageService packageService,
            IFlightService flightService,
            ICustomerService customerService,
            IExportExcelAppService exportExcelAppService
        ) : base(logger)
        {
            _currentContext = currentContext;
            _aspNetUserCache = aspNetUserCache;
            _environment = environment;
            _packageDetailQuoteService = packageDetailQuoteService;
            _packageDetailService = packageDetailService;
            _productService = productService;
            _packageService = packageService;
            _flightService = flightService;
            _customerService = customerService;
            _exportExcelAppService = exportExcelAppService;
        }

        public Task<PackageDetailQuoteResponse> GetPackageDetailQuoteInfo(PackageDetailQuoteInfoRequest request)
        {
            var response = new PackageDetailQuoteResponse();

            TryCatch(() =>
            {

                var packageDetailQuote = _packageDetailQuoteService.GetById(request.PackageDetailQuoteId);
                if (packageDetailQuote == null) throw new ErrorCodeException(Common.ErrorCodeDefine.NOT_FOUND);

                var packageDetails = _packageDetailService.GetByDeliveryBillCode(packageDetailQuote.Code).ToList();

                var packageDetailIds = packageDetails.Select(x => x.Id).ToList();
                var products = _productService.GetByPackageDetaiId(packageDetailIds).ToList();
                if (packageDetails[0].OrderType == OrderCsType.TRANSPORT)
                {
                    products = products.Where(x => x.DataType == 1).ToList();
                }

                var packageIds = packageDetails.Select(x => (int)x.PackageId).ToList();
                var packages = _packageService.GetById(packageIds).ToList();
                var packageChilds = _packageService.GetByParentId(packageIds).ToList();
                var flightIds = packages.Select(x => (int)x.FlightId).Distinct().ToList();
                if (packageChilds.Count > 0)
                {
                    flightIds.AddRange(packageChilds.Select(x => (int)x.FlightId).Distinct().ToList());
                }

                var flights = _flightService.GetById(flightIds.Distinct().ToList()).ToList();

                var packageDetailViewModels = packageDetails.Select(x =>
                {
                    var item = x.ToModel();
                    var product = products.Where(m => m.PackageDetailId == item.Id).ToList();
                    item.Products = product.Select(m => m.ToModel()).ToList();
                    var package = packages.FirstOrDefault(m => m.Id == item.PackageId).ToModel();
                    package.Flight = flights.FirstOrDefault(c => c.Id == package.FlightId)?.ToModel() ?? null;
                    item.TrackingCode = package?.TrackingCode ?? null;
                    item.TrackingNote = package.TrackingNote;
                    var packageChild = packageChilds.Where(m => m.ParentId == package.Id).ToList();
                    if (packageChild.Count > 0)
                    {
                        item.Packages = packageChilds.Where(m => m.ParentId == package.Id).Select(m => {
                            var child = m.ToModel();
                            child.Flight = flights.FirstOrDefault(c => c.Id == m.FlightId)?.ToModel() ?? null;
                            return child;
                        }).ToList();
                        item.Packages.Add(package);
                    }
                    else
                    {
                        item.Packages = new List<PackageViewModel> { package };
                    }
                    return item;
                }).ToList();

                var data = packageDetailQuote.ToModel();
                data.PackageDetails = packageDetailViewModels;

                data.TotalAmountOrder = packageDetailViewModels.Sum(m => m.TotalAmount ?? 0);
                data.TotalShippingFee = packageDetailViewModels.SelectMany(m => m.Products).Sum(m => (m.PriceWeight ?? 0) * (m.WeightQuote ?? 0));
                var deliveryFee = packageDetailViewModels.Sum(m => m.ShippingFeeDomestic ?? 0);
                if (deliveryFee > 0)
                {
                    data.ShipmentMoneyCollect = 0;
                }
                data.Total = data.TotalAmountOrder + (data.ShipmentMoneyCollect ?? 0);
                data.ProcessEmployee = _aspNetUserCache.GetById(data.EmployeeHandling)?.Result?.FullName ?? null;
                data.Saler = _aspNetUserCache.GetById(data.Supporter)?.Result?.FullName ?? null;
                var customer = _customerService.GetByAccountId(data.CustomerId);
                data.Customer = $"{customer?.Code ?? null} - {customer?.Fullname ?? null}";

                response.SetData(data).Successful();
            }, response);

            return Task.FromResult(response);
        }

        public Task<Stream> ExportOrderPriceQuotes(PackageDetailQuoteInfoRequest request)
        {
            try
            {
                var response = this.GetPackageDetailQuoteInfo(request).Result;
                if (response == null || response.Data == null || response.Status == false) throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);

                var packageDetailQuote = response.Data;

                if (packageDetailQuote.Type == PackageDetailQuotesType.ECommerce.GetHashCode())
                {
                    var pathFileExport = Path.Combine(_environment.WebRootPath, "WH_OrderPriceQuotes_ECM.xlsx");
                    var fileInfo = new FileInfo(pathFileExport);
                    using (var excelPackage = new ExcelPackage(fileInfo, true))
                    {
                        var workSheetOne = excelPackage.Workbook.Worksheets.FirstOrDefault();
                        _exportExcelAppService.BindingOrderPriceQuotesEcm(workSheetOne, packageDetailQuote);
                        excelPackage.Save();
                        return Task.FromResult(excelPackage.Stream);
                    }
                }
                else
                {
                    var pathFileExport = Path.Combine(_environment.WebRootPath, "WH_OrderPriceQuotes_VC.xlsx");
                    var fileInfo = new FileInfo(pathFileExport);
                    using (var excelPackage = new ExcelPackage(fileInfo, true))
                    {
                        var workSheetOne = excelPackage.Workbook.Worksheets.FirstOrDefault();
                        _exportExcelAppService.BindingOrderPriceQuotesTransport(workSheetOne, packageDetailQuote);
                        excelPackage.Save();
                        return Task.FromResult(excelPackage.Stream);
                    }
                }
            }
            catch(Exception ex)
            {
                logger.LogError(ex, ex.Message);
                throw new ErrorCodeException(ErrorCodeDefine.NOT_FOUND);
            }
        }
    }
}
