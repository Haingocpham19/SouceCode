using System.Collections.Generic;
using iChiba.Event.Core.Domain;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public partial class OrderTransportRequest : INotifyHeader
    {
        public int Id { get; set; }
        public string NotifyRoutingKey { get; set; }
        public string NotifyAppId { get; set; }
        public string NotifyCode { get; set; }
        //public string Title { get; set; }
        public string Tracking { get; set; }
        public string NewTracking { get; set; }
        //public string AccountId { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string Note { get; set; }
        public int? ShippingRouteId { get; set; }
        public string ShippingRouteCode { get; set; }
        public string Warehouse { get; set; }
        public string Currency { get; set; }
        public string DdimportType { get; set; }
        public int? TransportPaymentType { get; set; }
        public IList<int> OrderServices { get; set; }
        public IList<OrderPackageAddRequest> Packages { get; set; }
        public string Images { get; set; }
        public OrderTransportRequest()
        {
            Packages = new List<OrderPackageAddRequest>();
            OrderServices = new List<int>();
        }
    }
}
