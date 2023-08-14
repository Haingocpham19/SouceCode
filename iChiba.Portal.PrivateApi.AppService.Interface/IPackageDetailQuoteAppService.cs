using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IPackageDetailQuoteAppService
    {
        Task<PackageDetailQuoteResponse> GetPackageDetailQuoteInfo(PackageDetailQuoteInfoRequest request);
        Task<Stream> ExportOrderPriceQuotes(PackageDetailQuoteInfoRequest request);
    }
}
