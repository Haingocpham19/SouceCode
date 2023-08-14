using System.Collections.Generic;

namespace iChiba.Portal.CS.PublicApi.Driver.Request
{
    public class OrderAddRequest
    {
        public string OrderType { get; set; }
        public string RefType { get; set; }
        public string SellerId { get; set; }
        public int AddressId { get; set; }
        public int? PaymentType { get; set; }
        public string PaymentBankNumber { get; set; }
        public IList<ShoppingCartProduct> ShoppingCartProducts { get; set; }
    }

    public class ShoppingCartProduct
    {
        public string ProductId { get; set; }
        public string DdImportId { get; set; }
        public IList<int> OrderServiceIds { get; set; }
    }
}
