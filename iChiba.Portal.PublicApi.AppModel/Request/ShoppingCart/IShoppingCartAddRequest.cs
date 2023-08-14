using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public interface IShoppingCartAddRequest
    {
        IDictionary<string, string> Attributes { get; set; }
        string PreviewImage { get; set; }
        IList<string> Images { get; set; }
        int Quantity { get; set; }
        int Weight { get; set; }
        int Width { get; set; }
        int Height { get; set; }
        int Length { get; set; }
        long Price { get; set; }
        string Currency { get; set; }
        int Tax { get; set; }
        string Ref { get; set; }
        string RefType { get; set; }
        string ProductName { get; set; }
        string ProductLink { get; set; }
        string NoteOrder { get; set; }
        string SellerId { get; set; }
        int ShippingFee { get; set; }
    }
}
