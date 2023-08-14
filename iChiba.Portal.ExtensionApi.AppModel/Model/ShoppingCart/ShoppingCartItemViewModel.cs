using System;
using System.Collections.Generic;

namespace iChiba.Portal.ExtensionApi.AppModel.Models.ShoppingCat
{
    public class ShoppingCartItemViewModel
    {
        public string Id { get; set; }
        public IDictionary<string, string> Attributes { get; set; }

        public string PreviewImage { get; set; }

        public IList<string> Images { get; set; }

        public int? Quantity { get; set; }

        public int? Weight { get; set; }

        public int? Width { get; set; }

        public int? Height { get; set; }

        public int? Length { get; set; }

        public long? Price { get; set; }

        public int? Tax { get; set; }

        public string Ref { get; set; }

        public string RefType { get; set; }

        public DateTime? CreatedDate { get; set; }

        public string ProductName { get; set; }

        public string ProductLink { get; set; }

        public string NoteOrder { get; set; }

        public string SellerId { get; set; }

        public int? ShippingFee { get; set; }
        public string SourceName { get; set; }

        public string Currency { get; set; }
        public string AccountId { get; set; }
        public IList<string> ServiceCode { get; set; }
        public string TrackingNote { get; set; }
    }
}
