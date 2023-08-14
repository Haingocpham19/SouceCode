using iChiba.Portal.PrivateApi.AppModel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
   public class OrderBuyForYouAddRequest
    {
        public string AccountId { get; set; }
        public string Title { get; set; }
        public long? ShippingFee { get; set; }
        public int? ShippingUnitGlobal { get; set; }
        public int? Exchangerate { get; set; }
        public int? BuyFee { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string OrderType { get; set; }
        public string ProductName { get; set; }
        public string BidAccount { get; set; }
        public int? PaymentDuration { get; set; }
        public string Currency { get; set; }
        public string WareHouse { get; set; }
        public IList<OrderDetailList> Orderdetail { get; set; }
        public Guid GuidId { get; set; }
        public long Total { get; set; }
        public string Supporter { get; set; }
        public DateTime OrderDate { get; set; }
        public string Note { get; set; }
        public OrderBuyForYouAddRequest()
        {
            Orderdetail = new List<OrderDetailList>();
        }
    }
}
