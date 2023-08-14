using iChiba.Portal.Common;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class Orderdetail
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductLink { get; set; }
        public string PreviewImage { get; set; }
        public string Images { get; set; }
        public string BarCode { get; set; }
        public string TrackingNumber { get; set; }
        public int? Amount { get; set; }
        public string AmountUnit { get; set; }
        //public int? Weight { get; set; }
        //public int? Width { get; set; }
        //public int? Hight { get; set; }
        //public int? Lenght { get; set; }
        public long? Price { get; set; }
        public string PriceDisplay => Price.Value > 0 ? Price.Value.StringDisplayLong() : "";
        public long? PriceVND => ExchangeRate != null ? Price * ExchangeRate : null;
        public string PriceVNDDisplay => PriceVND != null && PriceVND.Value > 0 ? PriceVND.Value.StringDisplayLong() : "";
        public long PriceInclude => Price.Value + Price.Value * Tax.Value / 100;
        public long? PriceIncludeVND => ExchangeRate != null ? PriceInclude * ExchangeRate : null;
        public string PriceIncludeVNDDisplay => PriceIncludeVND != null && PriceIncludeVND.Value > 0 ? PriceIncludeVND.Value.StringDisplayLong() : "";
        public string PriceIncludeDisplay => PriceInclude > 0 ? PriceInclude.StringDisplayLong() : "";
        public int? Tax { get; set; }
        public long? ShippingFee { get; set; }
        public int? ExchangeRate { get; set; }
        public long? ShippingFeeToLocal { get; set; }
        public long? ShippingFeeLocal { get; set; }
        public int? BuyFee { get; set; }
        public long? Surcharge { get; set; }
        public int? Status { get; set; }
        public string Note { get; set; }
        public string NoteOrder { get; set; }
        //public string Hash { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        //public string ProAttribute { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
        public Orderdetail()
        {
            Attributes = new Dictionary<string, string>();
        }
    }
}
