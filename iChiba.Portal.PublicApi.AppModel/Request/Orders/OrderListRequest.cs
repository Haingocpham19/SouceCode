using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderListRequest: SortRequest
    {
        public string Tracking { get; set; }
        public int Status { get; set; }
        public string OrderType { get; set; }
        public string PageViewOrder { get; set; }
        public IList<string> NotContainsOrderType { get; set; }
    }
}
