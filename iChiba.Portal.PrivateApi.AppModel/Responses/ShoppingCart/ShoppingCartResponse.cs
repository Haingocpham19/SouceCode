using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class ShoppingCartListResponse : PagingResponse<IList<ShoppingCartViewModel>>
    {
        public string ContentHtml { get; set; }
        public ShoppingCartListResponse()
        {
            Data = new List<ShoppingCartViewModel>();
        }
    }
    public class ShoppingCartResponse : BaseEntityResponse<ShoppingCartViewModel>
    {
    }
    public class ShoppingCartCUDResponse : BaseEntityResponse<bool>
    {
    }
}
