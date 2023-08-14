using System;

namespace iChiba.Portal.PublicApi.AppModel.Response
{
    public class PackageTrackingList
    {
        public int Id { get; set; }
        public string Tracking { get; set; }
        public string FromWarehouseCode { get; set; }
        public string FromWarehouseName { get; set; }
        public int Status { get; set; }
        public string Description { get; set; }
        public string Note { get; set; }
        public DateTime NotifyDate { get; set; }
        public string NotifyDateDisplay => NotifyDate.ToLocalTime().ToString("dd/MM/yyyy HH:mm");
        public DateTime CreatedDate { get; set; }
        public string ToWarehouseCode { get; set; }
        public string ToWarehouseName { get; set; }
    }
}
