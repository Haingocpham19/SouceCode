using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderTransportCountRequest
    {
        public List<int> TrackingStatuses { get; set; }
    }

    public class OrderTransportByStatus
    {
        public List<int> Statuses { get; set; }
    }
}
