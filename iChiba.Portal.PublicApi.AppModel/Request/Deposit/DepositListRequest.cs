using Core.AppModel.Request;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class DepositListRequest: SortRequest
    {
        public int? PayStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
