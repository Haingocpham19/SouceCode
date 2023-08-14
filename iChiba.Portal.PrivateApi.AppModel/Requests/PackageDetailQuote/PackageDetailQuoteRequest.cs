using Core.AppModel.Request;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class PackageDetailQuoteRequest : SortRequest
    {
        public string BillCode { get; set; }
        public string OrderCode { get; set; }
        public string PoNumber { get; set; }
        public bool? PaymentStatus { get; set; }
        public List<int> QuoteType { get; set; }
        public int? Status { get; set; }
    }

    public class PackageDetailQuoteInfoRequest
    {
        public int PackageDetailQuoteId { get; set; }
    }
}
