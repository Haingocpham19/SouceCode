using System.Collections.Generic;

namespace Ichiba.Partner.Api.Driver.Response
{
    public class ProductDetail
    {
        public string Domain { get; set; }
        public string Currency { get; set; }
        public string SourceName { get; set; }
        public string Id { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string SellerId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsOutOfStock { get; set; }
        public IList<string> Images { get; set; }
        public IList<ProductAttribute> Attributes { get; set; }
    }

    public class ProductAttribute
    {
        public string Name { get; set; } // Type of Attribute
        public IList<ProductAttributeItem> Items { get; set; }
    }
    public class ProductAttributeItem
    {
        public string Value { get; set; }
        public string Link { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
    }
}
