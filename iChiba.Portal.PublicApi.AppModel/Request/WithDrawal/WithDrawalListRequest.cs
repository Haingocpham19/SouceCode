using Core.AppModel.Request;
using System;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class WithDrawalListRequest : SortRequest
    {
        public int? WithDrawalStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
    }
}
