using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class PackageDetailQuoteViewModel
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public decimal? TotalWeight { get; set; }
        public decimal TotalShippingFee { get; set; }
        public decimal Total { get; set; }
        public string WarehouseCode { get; set; }
        public int WarehouseId { get; set; }
        public string CustomerId { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerWard { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public int Status { get; set; }
        public string ShipmentCode { get; set; }
        public int? ShipmentType { get; set; }
        public int? ShipmentEstimate { get; set; }
        public decimal? ShipmentMoneyCollect { get; set; }
        public int? Type { get; set; }
        public int? ShippingUnitType { get; set; }
        public int? BinLocationId { get; set; }
        public string EmployeeHandling { get; set; }
        public string Note { get; set; }
        public string ReasonCancelDeliveryBillQuote { get; set; }
        public int? ProcessedDeliveryBillQuote { get; set; }
        public string PoNumber { get; set; }
        public bool? PaymentStatus { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryBy { get; set; }
        public DateTime? TransportedDate { get; set; }
        public string TransportedBy { get; set; }
        public decimal? Paid { get; set; }
        public decimal? Unpaid { get; set; }
        public decimal? ShipmentActuallyMoneyCollect { get; set; }
        public decimal? TotalOrderWeight { get; set; }
        public string Supporter { get; set; }
        public bool? Cod { get; set; }
        public int? ShippingService { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string CustomerFullAddress { get; set; }
        public decimal TotalAmountOrder { get; set; }
        public string ProcessEmployee { get; set; }
        public string Saler { get; set; }
        public string Customer { get; set; }
        public List<PackageDetailViewModel> PackageDetails { get; set; }
        public List<PackageDetailViewModel> PackageDetailDisplays { get; set; }
    }
}
