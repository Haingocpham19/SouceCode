using System;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderDetailViewModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string Code { get; set; }
        public string ProductName { get; set; }
        public string ProductType { get; set; }
        public string ProductOrigin { get; set; }
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
        public long? Price { get; set; }
        public long? PriceExpected { get; set; }
        public long? PriceBuy { get; set; }
        public int? Tax { get; set; }
        public DateTime? ShippingFeeDate { get; set; }
        public string ShippingFeeBy { get; set; }
        public long? ShippingFee { get; set; }
        public int? ExchangeRate { get; set; }
        public long? ShippingFeeToLocal { get; set; }
        public long? ShippingFeeLocal { get; set; }
        public int? BuyFee { get; set; }
        public long? Surcharge { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string Hash { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        public string NoteOrder { get; set; }
        public string ProAttribute { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? PaymentDuration { get; set; }
        public string BidAccount { get; set; }
        public int? PackageId { get; set; }
        public bool? BidStatus { get; set; }
        public string PaymentAccount { get; set; }
        public int? DownloadStatus { get; set; }
        public DateTime? DownloadDate { get; set; }
        public int? DownloadRetry { get; set; }
        public string DownloadImages { get; set; }
    }
}
