namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class ShoppingCartRemoveItemRequest
    {
        public string IdentityRefId { get; set; }
        public string CartItemId { get; set; }
    }
}
