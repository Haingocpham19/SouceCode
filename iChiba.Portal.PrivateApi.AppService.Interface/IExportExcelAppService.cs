using iChiba.Portal.PrivateApi.AppModel.Models;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IExportExcelAppService
    {
        void BindingOrderPriceQuotesTransport(ExcelWorksheet worksheet, PackageDetailQuoteViewModel data);
        void BindingOrderPriceQuotesEcm(ExcelWorksheet worksheet, PackageDetailQuoteViewModel data);
    }
}
