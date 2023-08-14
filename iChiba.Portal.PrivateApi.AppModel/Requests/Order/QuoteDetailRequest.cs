using Core.AppModel.Request;
using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderPriceQuotesSearchRequest : SortRequest
    {
        public bool DistributionTab { get; set; } = false;
        public bool IsAdmin { get; set; } = false;
        public List<int> Types { get; set; }
        public string WarehouseCode { get; set; }
        public string OrderCode { get; set; }
        public List<string> OrderTypes { get; set; }
        public string DeliveryBillCode { get; set; }
        public string CustomerId { get; set; }
        public List<string> CustomerIds { get; set; }
        public List<string> SalerIds { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string EmployeeHandling { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public DateTime? ShipmentFromDate { get; set; }
        public DateTime? ShipmentToDate { get; set; }
        public DateTime? ShippedFromDate { get; set; }
        public DateTime? ShippedToDate { get; set; }
        public int? StatusShipment { get; set; }
        public bool? PaymentStatus { get; set; }
        public string PoNumber { get; set; }
        public EnumDefine.ShippingType? ShippingType { get; set; }
        public EnumDefine.ShippingUnitType? ShippingUnitType { get; set; }
        public EnumDefine.PackageDetailStatus PackageDetailStatus { get; set; }
        public bool? OrderByApprovalDate { get; set; }
        public bool? OrderByTransportedDate { get; set; }
        public string OrderType { get; set; }

        public void ValidRequest()
        {
            OrderCode = OrderCode?.Trim();
            DeliveryBillCode = DeliveryBillCode?.Trim();
            PoNumber = PoNumber?.Trim();
            CustomerPhone = CustomerPhone?.Trim();
            CustomerName = CustomerName?.Trim();
            EmployeeHandling = EmployeeHandling?.Trim();
        }
    }

}
