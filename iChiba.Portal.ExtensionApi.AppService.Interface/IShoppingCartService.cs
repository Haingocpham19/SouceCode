using iChiba.Portal.ExtensionApi.AppModel.Request;
using iChiba.Portal.ExtensionApi.AppModel.Response;
using System.Threading.Tasks;

namespace iChiba.Portal.ExtensionApi.AppService.Interface
{
    public interface IShoppingCartService
    {
        public Task<ShoppingCarResponse> AddToCart(ShoppingCartRequest request);
        public Task<ShoppingCartListItemResponse> AddItemToCart(ShoppingCartItemRequest request);
        public Task<ShoppingCartListItemResponse> GetListShoppingCart();
        public Task<ShoppingCarResponse> DeleteListItemCart(ShoppingListIdRequest request);
        public Task<ShoppingCarResponse> DeleteItemCart(ShoppingItemIdRequest request);
    }
}
