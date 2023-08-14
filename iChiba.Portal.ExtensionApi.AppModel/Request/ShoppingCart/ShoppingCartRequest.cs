using iChiba.Portal.ExtensionApi.AppModel.Models.ShoppingCat;
using System.Collections.Generic;

namespace iChiba.Portal.ExtensionApi.AppModel.Request
{
    public class ShoppingCartRequest
    {
        public ShoppingCartRequest()
        {
            ShoppingCartItems = new List<ShoppingCartItemViewModel>();
        }
        public List<ShoppingCartItemViewModel> ShoppingCartItems { get; set; } 
    }
    public class ShoppingCartItemRequest
    {
        public string AccountId { get; set; }
        public string TrackingNote { get; set; }
        public string Domain { get; set; }
        public string SourceName { get; set; }
        public string Currency { get; set; }
        public string Url { get; set; }
        public string Route { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string SellerId { get; set; }
        public string Warehouse { get; set; }
        public string Note { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public int? Tax { get; set; }
        public decimal? Weight { get; set; }
        public bool IsOutOfStock { get; set; }
        public IList<string> Images { get; set; }
        public IList<string> ServiceCode { get; set; }
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
