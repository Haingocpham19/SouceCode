using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IShoppingCartCache : IBaseHashCache<ShoppingCarts, string>
    {
        Task<bool> HashSet(ShoppingCarts model);
        Task<bool> StringSet(ShoppingCarts model, string userId);
        Task<bool> HashSet(ShoppingCartItem model);
        Task<ShoppingCarts[]> GetAll();
        Task<List<ShoppingCartItem>> GetAllShoppingCartItem(string userId);
        Task<IList<ShoppingCartItem>> GetByAccountId(string accountId);
        Task<bool> AddListShoppingCart(System.Collections.Generic.List<ShoppingCartItem> shoppingCartItem, string userId);
        Task<bool> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
        Task<bool> UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId);
        Task<ShoppingCarts> GetAllItemByUserId(string userId);
        Task<bool> DeleteListItem(List<string> listId, string userId);
        Task<bool> DeleteItem(string id, string userId);
        Task<bool> DeleteKey(string userId);
    }
}
