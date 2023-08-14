using Core.AppModel.Request;
using System;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class PaymentTransactionHistoryRequest : SortRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public bool? IsRefund { get; set; }
        public int? Status { get; set; }
    }
}
