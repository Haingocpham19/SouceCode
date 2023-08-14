using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class OrderList
    {
        public int Id { get; set; }
        public Guid GuidId { get; set; }
        public string Title { get; set; }
        //public string Operator { get; set; }
        //public string AccountId { get; set; }
        public string Code { get; set; }
        public long? ShippingUnit { get; set; }
        public long? Total { get; set; }
        public string Tracking { get; set; }
        public int? Status { get; set; }
        //public string StatusNote { get; set; }
        public int? TrackingStatus { get; set; }
        public string TrackingStatusName { get; set; }
        public string OrderType { get; set; }
        public DateTime OrderDate { get; set; }
        public int? PaymentType { get; set; }
        public int? PaymentDuration { get; set; }
        public int PaymentDurationDay
        {
            get
            {
                if (!PaymentDuration.HasValue) PaymentDuration = 0;
                var enddate = OrderDate.AddDays(PaymentDuration.Value);
                var durday = (int)Math.Round((enddate - DateTime.Now).TotalDays);
                return durday;
            }
        }
        public int PaymentDurationMinutes
        {
            get
            {
                if (!PaymentDuration.HasValue) PaymentDuration = 0;
                var enddate = OrderDate.AddDays(PaymentDuration.Value);
                var durday = (int)Math.Round((enddate - DateTime.UtcNow).TotalMinutes);
                return durday;
            }
        }
        public int PaymentDurationSeconds
        {
            get
            {
                if (!PaymentDuration.HasValue) PaymentDuration = 0;
                var enddate = OrderDate.AddDays(PaymentDuration.Value);
                var durday = (int)Math.Round((enddate - DateTime.UtcNow).TotalSeconds);
                return durday;
            }
        }
        //public int? DeliveryType { get; set; }
        //public DateTime? DeliveryExpected { get; set; }
        //public DateTime? DeliveryDate { get; set; }
        public long? DeliveryFee { get; set; }
        //public int? DeliveryDiscount { get; set; }
        public long? TotalPayment { get; set; }
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
        public long AmountVND { get; set; }
        public int PaidPercent
        {
            get
            {
                if (!this.Paid.HasValue) return 0;
                var temp = (double)Paid / (double)AmountVND;
                return (int)(Math.Round(temp, 2) * 100);
            }
        }
        public long? PaymentAwaiting { get; set; }
        //public string Hash { get; set; }
        public long? BuyFee { get; set; }
        public long? ShippingFee { get; set; }
        public long? ShippingFeeToLocal { get; set; }
        public List<OrderdetailList> Orderdetail { get; set; }
        public long TotalDeposit { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Hight { get; set; }
        public int? Length { get; set; }
        public int? ExchangeRate { get; set; }
        public int? ShippingUnitGlobal { get; set; }
        public int? ShippingRouteId { get; set; }
        public string ShippingRouteCode { get; set; }
        public string Warehouse { get; set; }
        public string Saler { get; set; }
        public string EmpployeeSupport { get; set; }
        public string EmpployeePhoneNumber { get; set; }

        //public OrderPaymentDetail OrderPaymentDetail { get; set; }

        public IList<OrderServiceList> Services { get; set; }

        public OrderList()
        {
            Orderdetail = new List<OrderdetailList>();
            Services = new List<OrderServiceList>();
        }
    }
}
