using iChiba.WH.Model;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class ShoppingCartViewModel
    {
        public string AccountId { get; set; }
        public string Domain { get; set; }
        public string SourceName { get; set; }
        public string Currency { get; set; }
        public string Url { get; set; }
        public string Route { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string SellerId { get; set; }
        public decimal? Price { get; set; }
        public int? Quantity { get; set; }
        public bool IsOutOfStock { get; set; }
        public string NoteOrder { get; set; }
        public string TrackingNote { get; set; }
        public int Tax { get; set; }
        public int Exchangerate { get; set; }
        public IList<string> ServiceCode { get; set; }
        public IList<string> Images { get; set; }
        public string Image { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public IList<ProductAttribute> Attributes { get; set; }
        public IList<ServiceCharge> ServiceCharge { get; set; }
    }
}
