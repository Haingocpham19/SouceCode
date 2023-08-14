using Core.AppModel.Request;
using iChiba.Portal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class DeliveryBillListRequest : SortRequest
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
        public string SalesAccountId { get; set; }
        public int PackageDetailStatus { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ShipmentFromDate { get; set; }
        public DateTime? ShipmentToDate { get; set; }
        public DateTime? ShippedFromDate { get; set; }
        public DateTime? ShippedToDate { get; set; }
        public int? StatusShipment { get; set; }
        public bool? PaymentStatus { get; set; }
        public string OrderType { get; set; }
    }

    public class DeliveryBillExportRequest
    {
        public List<int> Ids { get; set; }
        public EnumDefine.ShippingType ShippingType { get; set; }
        public decimal? ShippingFee { get; set; }
        public EnumDefine.ExportTransportType ExportTransportType { get; set; }
        public EnumDefine.PackageDetailQuotesType PackageDetailQuotesType { get; set; }
        public EnumDefine.ShippingUnitType ShippingUnitType { get; set; }
        public EnumDefine.ShippingServiceType ShippingService { get; set; }

        public string PoNumber { get; set; }
        public string Note { get; set; }
        public int? BinLocationId { get; set; }
        public int? TypeExport { get; set; }
        public string Region { get; set; }
        public bool? COD { get; set; }

        public bool HasQuotes { get; set; }
        public string CustomerId { get; set; }
        public string WareHouseCode { get; set; }
    }
}
