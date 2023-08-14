using Core.AppModel.Request;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderRequest : SortRequest
    {
        public string OrderCode { get; set; }
        public string Tracking { get; set; }
        public string OrderType { get; set; }
        public List<string> State { get; set; }
        public List<int> Status { get; set; }
        public List<string> QuoteCodes { get; set; }
    }

}
