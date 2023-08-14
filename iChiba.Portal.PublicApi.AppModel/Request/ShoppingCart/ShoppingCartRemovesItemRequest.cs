namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ShoppingCartRemovesItemRequest
    {
        public string IdentityRefId { get; set; }
        public string RefType { get; set; }
        public string SellerId { get; set; }
    }
}
