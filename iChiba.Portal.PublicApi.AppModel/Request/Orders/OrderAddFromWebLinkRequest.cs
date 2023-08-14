using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderAddFromWebLinkModel
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string PreviewImage { get; set; }
        public IList<string> Images { get; set; }
        public string Url { get; set; }
        public int Quantity { get; set; }
        public long Price { get; set; }
        public string OrderType { get; set; }
        public string SellerId { get; set; }
        public string Note { get; set; }
        public int Tax { get; set; }
    }

    public class OrderAddFromWebLinkRequest
    {
        public IList<OrderAddFromWebLinkModel> OrderList { get; set; }
        public OrderAddFromWebLinkRequest()
        {
            OrderList = new List<OrderAddFromWebLinkModel>();
        }
    }
}
