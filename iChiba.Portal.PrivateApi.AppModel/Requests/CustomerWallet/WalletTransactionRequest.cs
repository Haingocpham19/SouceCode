using Core.AppModel.Request;
using System;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class WalletTransactionRequest : SortRequest
    {
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public int? Status { get; set; }
    }
}
