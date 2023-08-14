using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public partial class OrderTransport
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Tracking { get; set; }
        public DateTime? TrackingDate { get; set; }
        public string AccountId { get; set; }
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
        public string AccountName { get; set; }
        public string Images { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Hight { get; set; }
        public int? Length { get; set; }
        public IList<OrderPackageList> Packages { get; set; }
        public IList<int> OrderServices { get; set; }
        public IList<OrderServiceSelected> Services { get; set; }
        public int? Status { get; set; }
        public int TrackingStatus { get; set; }
        public string TrackingStatusText { get; set; }
        public DateTime OrderDate { get; set; }
        public long? Paid { get; set; }
        public long? StandardFee { get; set; }
        public long? TotalPayment { get; set; }
        public long? Total { get; set; }
        public long? TotalServiceFee { get; set; }
        public long? Surcharge { get; set; }
        public int ExchangeRate { get; set; }
        public int? DataType { get; set; }
        public string DdimportType { get; set; }
        public int? TransportPaymentType { get; set; }
        public int? ToWarehouseId { get; set; }
        public string ToWarehouseCode { get; set; }

        public string CancelApproveBy { get; set; }
        public DateTime? CancelApproveDate { get; set; }
        public string CancelBy { get; set; }
        public DateTime? CancelDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public DateTime? QuoteDate { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public string DeliveryPartner { get; set; }
        public string DeliveryCode { get; set; }
        public string PurchaseBy { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public OrderTransport()
        {
            Packages = new List<OrderPackageList>();
            OrderServices = new List<int>();
        }
    }

    public class CountOrderTransport
    {
        public int TrackingStatus { get; set; }
        public int Total { get; set; }
    }

    public class CountOrderTransportByStatus
    {
        public int Status { get; set; }
        public int Total { get; set; }
    }

    public class OrderServiceSelected
    {
        public string Name { get; set; }
        public long? Price { get; set; }
        public string Unit { get; set; }
        public long? PricePayment { get; set; }
        public string ViewName => $"{Name} ({Price ?? 0} {Unit})";
    }
}
