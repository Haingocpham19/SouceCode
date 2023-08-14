using Core.AppModel.Request;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderAddRequest
    {
        public string AccountId { get; set; }
        public string Title { get; set; }
        public long? ShippingFee { get; set; }
        public int? ShippingUnitGlobal { get; set; }
        public int? Exchangerate { get; set; }
        public int? buyFee { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string OrderType { get; set; }
        public string productName { get; set; }
        public string BidAccount { get; set; }
        public int? PaymentDuration { get; set; }
        public string Currency { get; set; }
        public string WareHouse { get; set; }
        public IList<OrderDetailList> Orderdetail { get; set; }
    }

}
