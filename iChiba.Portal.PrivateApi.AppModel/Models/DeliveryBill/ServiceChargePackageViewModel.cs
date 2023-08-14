using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
   public class ServiceChargePackageViewModel
    {
        public int PackageDetailId { get; set; }
        public string PackageDetailCode { get; set; }
        public int ServiceChargeId { get; set; }
        public string ServiceChargeName { get; set; }
        public decimal? Percent { get; set; }
        public decimal? Price { get; set; }
        public string Images { get; set; }
        public string PreviewImage => !string.IsNullOrEmpty(Images) && Images.Split(',').Length > 0 ? Images.Split(',')[0] : string.Empty;
        public string Note { get; set; }
        public DateTime? EstimateTime { get; set; }
        public int Status { get; set; }
        public string StatusName => Status == 2 ? "Hoàn thành" : "Chưa hoàn thành";
        public bool StatusBit => Status == 2;
    }
}
