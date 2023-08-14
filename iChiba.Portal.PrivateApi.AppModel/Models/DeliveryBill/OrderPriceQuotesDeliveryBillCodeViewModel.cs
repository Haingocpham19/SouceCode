using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderPriceQuotesDeliveryBillCodeViewModel
    {
        public string DeliveryBillCode { get; set; }
        public decimal TotalShippingFee { get; set; }
        public decimal Total { get; set; }
        public decimal? ShipmentMoneyCollect { get; set; }
        public int TotalOrder { get; set; }
        public List<OrderPriceQuotesViewModel> OrderPriceQuotesCustomer { get; set; }
        public OrderPriceQuotesDeliveryBillCodeViewModel()
        {
            OrderPriceQuotesCustomer = new List<OrderPriceQuotesViewModel>();
        }
    }

    public class OrderPriceQuotesViewModel
    {
        public string CustomerId { get; set; }
        public string CustomerUsername { get; set; }
        public string CustomerName { get; set; }
        public string CustomerCode { get; set; }
        public string CustomerPhone { get; set; }
        public string DisplayName => (!string.IsNullOrEmpty(CustomerCode) ? CustomerCode + "-" : string.Empty) + $"{CustomerUsername}";
        public string CustomerEmail { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string EmployeeSupport { get; set; }
        public string FullAddress => $"{CustomerAddress}, {CustomerWard}, {CustomerDistrict}, {CustomerProvince}";
        public AspNetUser Supporter { get; set; }
        public int TotalOrder { get; set; }
        public List<OrderPriceQuotesByAddressViewModel> PackageDetailAddress { get; set; }
    }

    public class OrderPriceQuotesByAddressViewModel
    {
        public string CustomerId { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerWard { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string FullAddress { get; set; }
        public List<PackageExploitedViewModel> Packages { get; set; }
        public List<PackageDetailViewModel> Orders { get; set; }
        public int ShippingType { get; set; }
        public int ShippingUnitType { get; set; }
        public EnumDefine.ShippingServiceType ShippingService { get; set; }
        public bool? PaymentCod { get; set; } = true;
        public bool Crate { get; set; }
    }

    public class PackageExploitedViewModel
    {
        public int Id { get; set; }
        public int? RefId { get; set; }
        public string TrackingCode { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Weight { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public int NoOfPiece { get; set; }
        public string ImageBalanceScale { get; set; }
        public decimal CodFee { get; set; }
        public decimal DimensionWeight { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public string CreatedByName { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public int? ContainerId { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public int? FlightId { get; set; }
        public string FlightCode { get; set; }
        public int? BinLocationId { get; set; }
        public string Region { get; set; }
        public int? ParentId { get; set; }
        public string ServiceChargeCode { get; set; }
        public decimal DifferenceGWDW => Weight - (Width * Height * Length) / 6000;
        public int TotalOrder { get; set; }
        public bool PaymentStatus { get; set; }
        public string TrackingNote { get; set; }
        public string Note { get; set; }
        public FlightViewModel Flight { get; set; }
        public List<PackageExploitedViewModel> PackageChild { get; set; }
        public List<PackageDetailExploitedViewModel> PackageDetails { get; set; }
        public BinLocationViewModel BinLocation { get; set; }
    }
    public class NotExploitPackageDetailViewModel
    {
        public string OrderCode { get; set; }
        public string TrackingCode { get; set; }
        public string TrackingNote { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public DateTime? DateArrival { get; set; }
        public string Mawb { get; set; }
        public string FlightName { get; set; }
        public decimal? Weight { get; set; }
    }

    public class BinLocationViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int WarehouseId { get; set; }
        public string WarehouseCode { get; set; }
        public int? Row { get; set; }
        public int? Column { get; set; }
        public decimal? Weight { get; set; }
        public decimal? Length { get; set; }
        public decimal? Width { get; set; }
        public decimal? Height { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string Type { get; set; }
        //public string TypeName => Type > 0 ? Type.GetDisplayName() : "-";
        public int TotalPackage { get; set; }
    }
}
