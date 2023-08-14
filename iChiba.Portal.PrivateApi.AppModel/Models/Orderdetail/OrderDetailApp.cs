using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderDetailList
    {
        public string Id { get; set; }
        public int OrderId { get; set; }
        public string SourceName { get; set; }
        public string ProductName { get; set; }
        public string ProductLink { get; set; }
        public string PreviewImage { get; set; }
        public string Images { get; set; }
        public string BarCode { get; set; }
        public string TrackingNumber { get; set; }
        public int? Amount { get; set; }
        public string AmountUnit { get; set; }
        public int? Weight { get; set; }
        public int? Width { get; set; }
        public int? Hight { get; set; }
        public int? Lenght { get; set; }
        public float? Price { get; set; }
        public float? Tax { get; set; }
        public float? ShippingFee { get; set; }
        public int? ExchangeRate { get; set; }
        public float? ShippingFeeToLocal { get; set; }
        public float? ShippingFeeLocal { get; set; }
        public DateTime? ShippingFeeDate { get; set; }
        public string ShippingFeeBy { get; set; }
        public int? BuyFee { get; set; }
        public long? Surcharge { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string NoteOrder { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string ProAttribute{ get; set; }
        public long? PriceExpected { get; set; }
        public string Currency { get; set; }
        public string CurrencyDisplay { get; set; }
        public string OrderDateStr
        {
            get
            {
                if (this.OrderDate.HasValue) return this.OrderDate.Value.ToString("dd/MM/yyyy HH:mm");
                else return "";
            }
        }
        public int? PaymentDuration { get; set; }
        public string PaymentDurationDate
        {
            get
            {
                return "";
            }
        }

        public string ProductType { get; set; }
        public string ProductOrigin { get; set; }
        public string CustomerName { get; set; }
        public string AccountId { get; set; }
        public string AccountName { get; set; }
        public string EmpployeeSupport { get; set; }
        public string OrderCode { get; set; }
        public string OrderTracking { get; set; }
        public int? OrderStatus { get; set; }
        public string OrderState { get; set; }
        public string FullName { get; set; }
        public string Warehouse { get; set; }
        public long? ShippingFree { get; set; }
        public long? BuyFree { get; set; }
        public long? Total { get; set; }
        public long? ShippingUnitGlobal { get; set; }
        public string bidAccount { get; set; }
        public string PaymentAccount { get; set; }
        public string PaymentAccountDisplay { get; set; }
        public string DownloadImages { get; set; }
        //payment
        public float? PriceUS => Common.Utility.GetPriceForUS("USD", (long)Price);
    }
}
