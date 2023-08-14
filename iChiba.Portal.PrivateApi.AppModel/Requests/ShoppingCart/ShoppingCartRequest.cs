using Core.AppModel.Request;
using Ichiba.Partner.Api.Driver.Response;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class ShoppingCartRequest
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

    public class ShoppingCartDeleteRequest
    {
        public string AccountId { get; set; }
        public List<string> Ids { get; set; }
    }

    public class ShoppingCartItemDeleteRequest
    {
        public string Id { get; set; }
    }
}
