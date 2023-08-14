using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class FlightViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal? Weight { get; set; }
        public decimal? WeightBulky { get; set; }
        public decimal? ActualWeight { get; set; }
        public string Departure { get; set; }
        public string Destination { get; set; }
        public string File { get; set; }
        public string WarehouseCode { get; set; }
        public int? WarehouseId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string CreatedWarehouseCode { get; set; }
        public int? CreatedWarehouseId { get; set; }
        public int? Type { get; set; }
        public bool? Lock { get; set; }
        public DateTime? DateArrival { get; set; }
        public DateTime? ExploitCompletedDate { get; set; }
    }
}
