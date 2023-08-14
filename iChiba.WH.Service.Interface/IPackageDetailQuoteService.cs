using Core.Common;
using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IPackageDetailQuoteService
    {
        IEnumerable<PackageDetailQuote> Gets(string accountId, string billCode, string poNumber, bool? paymentStatus, List<int> quoteType, int? status, Sorts sorts = null, Paging paging = null);
        PackageDetailQuote GetById(int id);
        IEnumerable<PackageDetailQuote> GetById(List<int> ids);
        PackageDetailQuote GetByCode(string code);
        IEnumerable<PackageDetailQuote> GetByCode(List<string> codes);
    }
}
