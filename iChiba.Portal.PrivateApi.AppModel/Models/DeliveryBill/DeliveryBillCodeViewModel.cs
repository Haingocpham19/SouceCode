using iChiba.Portal.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class DeliveryBillCodeViewModel
    {
        public string DeliveryBillCode { get; set; }
        public string PoNumber { get; set; }
        public string Note { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ShipmentDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public decimal TotalShippingFee { get; set; }
        public decimal Total { get; set; }
        public int ShippingType { get; set; }
        public int ShippingUnitType { get; set; }
        public decimal? ShipmentMoneyCollect { get; set; }
        public int TotalOrder { get; set; }
        public int Type { get; set; }
        public string EmployeeHandlingName { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerProvince { get; set; }
        public string CustomerWard { get; set; }
        public string EmployeeSupport { get; set; }
        public bool? PaymentStatus { get; set; }
        public long DeliveryFee { get; set; }
        public bool? COD { get; set; }
        public string WarehouseCode { get; set; }
        public EnumDefine.ShippingServiceType ShippingService { get; set; }
        public string FullAddress => $"{CustomerAddress}, {CustomerWard}, {CustomerDistrict}, {CustomerProvince}";
        public List<OrderPriceQuotesViewModel> OrderPriceQuotesCustomer { get; set; }
        public DeliveryBillCodeViewModel()
        {
            OrderPriceQuotesCustomer = new List<OrderPriceQuotesViewModel>();
        }
    }
}
