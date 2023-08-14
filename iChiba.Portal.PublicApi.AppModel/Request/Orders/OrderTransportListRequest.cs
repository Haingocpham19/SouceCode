using Core.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderTransportListRequest : SortRequest
    {
        public string Tracking { get; set; }
        public int? TrackingStatus { get; set; }
        public int? Status { get; set; }
        public int? ShippingRouteId { get; set; }
    }
}
