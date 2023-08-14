using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IShoppingCartService
    {
        Task<ShoppingCarts[]> GetAll();
        Task<bool> HashSet(ShoppingCarts model);
        Task<ShoppingCarts> GetById(string identityRefId);
        Task<IList<ShoppingCarts>> GetByIds(params string[] identityRefIds);
        Task HashDelete(string identityRefId);
    }
}
