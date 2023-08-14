using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ShoppingCartOrderConfirmRequest
    {
        public string OrderType { get; set; }
        public string RefType { get; set; }
        public string SellerId { get; set; }
        public IList<string> ProductIds { get; set; }
    }
}
