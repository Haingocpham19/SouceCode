using iChiba.Portal.Common;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class ShoppingCart
    {
        public string IdentityRefId { get; set; }
        public DateTime CreatedDate { get; set; }
        public IList<ShoppingCartItem> Items { get; set; }
        public long Amount { get; set; }
        public long BuyFee { get; set; }

        public long AmountVND { get; set; }
        public long BuyFeeVND { get; set; }

        public long ShippingFee { get; set; }
        public long ShippingFeeVND { get; set; }

        public string AmountDisplay => Amount.StringDisplayLong();
        public string BuyFeeDisplay => BuyFee.StringDisplayLong();

        public string AmountVNDDisplay => AmountVND.StringDisplayLong();
        public string BuyFeeVNDDisplay => BuyFeeVND.StringDisplayLong();
    }

    public class ShoppingCartItem
    {
        public string Id { get; set; }
        public IDictionary<string, string> Attributes { get; set; }
        public string PreviewImage { get; set; }
        public IList<string> Images { get; set; }
        public int Quantity { get; set; }
        public int Weight { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Length { get; set; }
        public long Price { get; set; }
        public int Tax { get; set; }
        public string Ref { get; set; }
        public string RefType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string ProductName { get; set; }
        public string ProductLink { get; set; }
        public string NoteOrder { get; set; }
        public string SellerId { get; set; }

        public int ShippingFee { get; set; }
        public long ShippingFeeVND { get; set; }

        public long Amount { get; set; }
        public long BuyFee { get; set; }

        public long PriceVND { get; set; }
        public long AmountVND { get; set; }
        public long BuyFeeVND { get; set; }
        public string Currency { get; set; } // ngoại tệ

        public string PriceDisplay => Price.StringDisplayLong();
        public string AmountDisplay => Amount.StringDisplayLong();
        public string BuyFeeDisplay => BuyFee.StringDisplayLong();

        public string PriceVNDDisplay => PriceVND.StringDisplayLong();
        public string AmountVNDDisplay => AmountVND.StringDisplayLong();
        public string BuyFeeVNDDisplay => BuyFeeVND.StringDisplayLong();
    }
}
