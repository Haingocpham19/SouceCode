using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Order
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Title { get; set; }
        //public string Operator { get; set; }
        //public string Saler { get; set; }
        //public string AccountId { get; set; }
        public string Code { get; set; }
        public long? ShippingUnit { get; set; }
        public long? Total { get; set; }
        public string Tracking { get; set; }
        public DateTime? TrackingDate { get; set; }
        public int? TrackingStatus { get; set; }
        public int? Status { get; set; }
        public string StatusNote { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public string DdimportType { get; set; }
        public int? PaymentType { get; set; }
        public int? PaymentDuration { get; set; }

        public int? PaymentDurationDay { get; set; }
        public int? PaymentDurationMinutes { get; set; }
        public int? PaymentDurationSeconds { get; set; }

        public int? DeliveryType { get; set; }
        public DateTime? DeliveryExpected { get; set; }
        public DateTime? DeliveryDate { get; set; }
        public DateTime? DeliveredDate { get; set; }
        public string DeliveryCode { get; set; }
        public string DeliveryPartner { get; set; }
        public long? DeliveryFee { get; set; }
        public int? DeliveryDiscount { get; set; }
        public long? Surcharge { get; set; }
        public string SurchargeNote { get; set; }
        public string CustomerDistrict { get; set; }
        public string CustomerWard { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerName { get; set; }
        public string CustomerProvince { get; set; }
        public string Note { get; set; }
        public int? MinPayment { get; set; }
        public long? Paid { get; set; }
        public int PaidPercent { get; set; }
        //public string Hash { get; set; }
        public long? BuyFee { get; set; }
        public long? ShippingFee { get; set; }
        public long? ShippingFeeToLocal { get; set; }

        public List<Orderdetail> Orderdetail { get; set; }
        public long TotalDeposit { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Hight { get; set; }
        public int? Length { get; set; }
        public int? ExchangeRate { get; set; }
        public int? ShippingUnitGlobal { get; set; }
        public string Warehouse { get; set; }
        public string State { get; set; }
        public DateTime? PurchaseDate { get; set; }

        public OrderPaymentDetail OrderPaymentDetail { get; set; }
        public Ddimport Ddimport { get; set; }
        public Bankic BankIc { get; set; }
        public virtual ICollection<OrderServiceMapping> OrderServiceMapping { get; set; }
        public IList<OrderService> OrderServices { get; set; }
        public IList<OrderService> Services { get; set; }
        public int? CustomerRatting { get; set; }
        public DateTime? CustomerRattingDate { get; set; }
        public string Currency { get; set; }
        public long? BuyServiceFee { get; set; }
    }
}
