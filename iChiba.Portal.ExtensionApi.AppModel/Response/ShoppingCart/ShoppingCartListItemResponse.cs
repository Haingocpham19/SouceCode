using Core.AppModel.Response;
using iChiba.Portal.ExtensionApi.AppModel.Models.ShoppingCat;
using System.Collections.Generic;

namespace iChiba.Portal.ExtensionApi.AppModel.Response
{
    public class ShoppingCartListItemResponse : BaseEntityResponse<IList<ShoppingCartItemViewModel>>
    {
        public ShoppingCartListItemResponse()
        {
            Data = new List<ShoppingCartItemViewModel>();
        }
    }
    public class ShoppingCarResponse : BaseEntityResponse<bool>
    {
       
    }
}
