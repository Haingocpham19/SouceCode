using iChiba.WH.Model;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class PackageViewModel
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }
        public int? RefId { get; set; }
        public int? RefPackageId { get; set; }
        public string TrackingCode { get; set; }
        public string TrackingNote { get; set; }
        public string Note { get; set; }
        public string Code { get; set; }
        //public int CounterCode => GetCounterCode();
        public string Name { get; set; }
        public int? WeightType { get; set; }
        public decimal Weight { get; set; }
        public decimal WeightJp { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal LengthJp { get; set; }
        public decimal WidthJp { get; set; }
        public decimal HeightJp { get; set; }
        public decimal DifferenceGWDW => (decimal)(Weight - (Width * Height * Length) / 6000);
        public decimal DimensionWeight { get; set; }
        public decimal CodFee { get; set; }
        public string CodProof { get; set; }
        public int NoOfPiece { get; set; }
        public string ImageBalanceScale { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public string CreatedBy { get; set; }
        public int? FlightId { get; set; }
        public string FlightName { get; set; }
        public string FlightCode { get; set; }
        public string CreatedByName { get; set; }
        public int Status { get; set; }
        //public EnumDefine.PackageProperty Property { get; set; }
        //public string StatusName => Status.GetDisplayName();
        //public EnumDefine.PackageStatus[] Statuses => ((EnumDefine.PackageStatus[])Enum.GetValues(typeof(EnumDefine.PackageStatus))).Where(item => (item & Status) == item).ToArray();
        //public string[] StatusesName => Statuses.Select(x => x.GetDisplayName()).ToArray();
        public int? BinLocationId { get; set; }
        public string Region { get; set; }
        public string ServiceChargeCode { get; set; }
        //public EnumDefine.WarningLevel WarningLevel { get; set; } = EnumDefine.WarningLevel.Normal;
        //public List<string> ServiceChargeCodeList => GetsServiceChargeCode();
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        //public Warehouse Warehouse { get; set; }
        public int ContainerId { get; set; }
        public string ContainerCode { get; set; }
        public string ContainerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerName { get; set; }
        public int HawbId { get; set; }
        public string EmployeeHandling { get; set; }
        public string ProcessedEmployee { get; set; }
        public string ProcessedEmployeName { get; set; }
        public string ShipperName { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string ProcessedDateString => ProcessedDate == null ? string.Empty : ProcessedDate.Value.ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
        public string LastBinLocation { get; set; }
        //public ContainerViewModel Container { get; set; }
        //public PackageDetail PackageDetail { get; set; }
        //public List<PackageViewModel> PackageChild { get; set; }
        public List<PackageDetailViewModel> PackageDetails { get; set; }
        public BinLocation BinLocation { get; set; }
        //public List<ServiceChargeViewModel> ServiceCharges { get; set; }
        public List<ProductViewModel> Products { get; set; }
        public FlightViewModel Flight { get; set; }

        //public List<string> GetsServiceChargeCode()
        //{
        //    return !string.IsNullOrEmpty(this.ServiceChargeCode) ? this.ServiceChargeCode.Split(new char[] { ',' }).ToList() : new List<string>();
        //}

        //public int GetCounterCode()
        //{
        //    if (!string.IsNullOrEmpty(Code))
        //    {
        //        var arrCode = this.Code.Substring(this.Code.Length - 4, 4);
        //        if (arrCode.Length > 1) return Extensions.AsInt(arrCode) + 1;
        //        return 100;
        //    }

        //    return 100;
        //}

        //public List<SubTrackingViewModel> SubTrackings { get; set; }
        //public bool? DisabledExploited { get; set; }
    }
}
