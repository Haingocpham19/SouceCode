using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;
using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartCache shoppingCartCache;

        public ShoppingCartService(IShoppingCartCache shoppingCartCache)
        {
            this.shoppingCartCache = shoppingCartCache;
        }

        public Task<ShoppingCarts[]> GetAll()
        {
            return shoppingCartCache.GetAll();
        }

        public Task<bool> HashSet(ShoppingCarts model)
        {
            return shoppingCartCache.HashSet(model);
        }

        public Task<ShoppingCarts> GetById(string identityRefId)
        {
            return shoppingCartCache.GetById(identityRefId);
        }

        public Task<IList<ShoppingCarts>> GetByIds(params string[] identityRefIds)
        {
            return shoppingCartCache.GetByIds(identityRefIds);
        }

        public Task HashDelete(string identityRefId)
        {
            return shoppingCartCache.HashDelete(identityRefId);
        }
    }
}
