using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public partial class OrderTransportRequest
    {
        public int Id { get; set; }
        public string NotifyRoutingKey { get; set; }
        public string NotifyAppId { get; set; }
        public string NotifyCode { get; set; }
        public string Title { get; set; }
        public string Tracking { get; set; }
        public string NewTracking { get; set; }
        public string AccountId { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string Mawb { get; set; }
        public string CustomerWard { get; set; }
        public string Note { get; set; }
        public int? ShippingRouteId { get; set; }
        public string ShippingRouteCode { get; set; }
        public string Warehouse { get; set; }
        public string Currency { get; set; }
        public string DdimportType { get; set; }
        public int? TransportPaymentType { get; set; }
        public string Images { get; set; }
        public long? TotalPayment { get; set; }
        public IList<int> OrderServices { get; set; }
        public int PackageIndex { get; set; }
        public string ProductName { get; set; }
        public int ProductTypeId { get; set; }
        public string ProductTypeName { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public long? BuyFee { get; set; }
        public decimal? Surcharge { get; set; }
        public string SurchargePay { get; set; }
        public DateTime? SurchargeDate { get; set; }
        public IList<OrderPackageAddRequest> Packages { get; set; }
        public int? ExchangeRate { get; set; }
        public OrderTransportRequest()
        {
            Packages = new List<OrderPackageAddRequest>();
            OrderServices = new List<int>();
        }
    }

    public class OrderTransportAddRequest
    {
        public string Tracking { get; set; }
        public string AccountId { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string Mawb { get; set; }
        public string CustomerWard { get; set; }
        public string Note { get; set; }
        public int? ShippingRouteId { get; set; }
        public string ShippingRouteCode { get; set; }
        public string Warehouse { get; set; }
        public string Currency { get; set; }
        public decimal? Surcharge { get; set; }
        public List<string> OrderServices { get; set; }
        public List<OrderPackageAddRequest> Packages { get; set; }
        public OrderTransportAddRequest()
        {
            Packages = new List<OrderPackageAddRequest>();
            OrderServices = new List<string>();
        }
    }

    public class AddListOrderTransportRequest
    {
        public List<OrderTransportAddRequest> OrderTransportAddRequest { get; set; }
    }
}
