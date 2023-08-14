using Core.AppModel.Request;
using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace Ichiba.WH.Api.Driver.Request
{
    public class WareHouseFormClientRequest : SortRequest
    {
        public List<int> Types { get; set; }
        public string WarehouseCode { get; set; }
        public string OrderCode { get; set; }
        public List<string> OrderTypes { get; set; }
        public List<string> CustomerIds { get; set; }
        public string CustomerId { get; set; }
        public string DeliveryBillCode { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public int PackageDetailStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ShipmentFromDate { get; set; }
        public DateTime? ShipmentToDate { get; set; }
        public DateTime? ShippedFromDate { get; set; }
        public DateTime? ShippedToDate { get; set; }
        public int? StatusShipment { get; set; }
        public bool? PaymentStatus { get; set; }
    }

    public class WareHouseFormClientSearchAllRequest : SortRequest
    {
        public List<int> Types { get; set; }
        public string WarehouseCode { get; set; }
        public string OrderCode { get; set; }
        public List<string> OrderTypes { get; set; }
        public List<string> CustomerIds { get; set; }
        public string CustomerId { get; set; }
        public string DeliveryBillCode { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public List<int> PackageDetailStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ShipmentFromDate { get; set; }
        public DateTime? ShipmentToDate { get; set; }
        public DateTime? ShippedFromDate { get; set; }
        public DateTime? ShippedToDate { get; set; }
        public int? StatusShipment { get; set; }
        public bool? PaymentStatus { get; set; }
    }

    public class WareHouseClientExportRequest
    {
        public List<int> Ids { get; set; }
        public int shippingType { get; set; }
        public decimal shippingFee { get; set; }
        public int exportTransportType { get; set; }
        public int packageDetailQuotesType { get; set; }
        public int shippingUnitType { get; set; }
        public int binLocationId { get; set; }
        public string region { get; set; }
        public bool hasQuotes { get; set; }
        public bool Cod { get; set; }
        public int? TypeExport { get; set; }
        public string CustomerId { get; set; }
        public string WareHouseCode { get; set; }
        public EnumDefine.ShippingServiceType ShippingService { get; set; }

    }

    public class OrderPriceQuotesGetByCodeRequest
    {
        public string DeliveryBillCode { get; set; }
    }
}
