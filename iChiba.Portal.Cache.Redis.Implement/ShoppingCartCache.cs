using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class ShoppingCartCache : BaseHashCache<ShoppingCarts, string>, IShoppingCartCache
    {
        private const string KEY = "PCS-Shopping-Cart1";
        //
        public ShoppingCartCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<bool> AddListShoppingCart(List<ShoppingCartItem> shoppingCartItem, string userId)
        {
            var res = await GetAllItemByUserId(userId);
            if (res != null)
            {
                var cart = new ShoppingCart();
                foreach (var item in shoppingCartItem)
                {
                    cart.Items.Add(item);
                }
                foreach (var cartItem in res.Carts.Values)
                {
                    foreach (var item in cartItem.Items)
                    {
                        cart.Items.Add(item);
                    }
                }
                res.Carts.Clear();
                res.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                return await StringSet(res, userId);
            }
            else
            {
                var shoppingCarts = new ShoppingCarts();
                var cart = new ShoppingCart();
                foreach (var item in shoppingCartItem)
                {
                    cart.Items.Add(item);
                }
                shoppingCarts.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                return await StringSet(shoppingCarts, userId);
            }

        }

        public async Task<IList<ShoppingCarts>> GetAllShoppingCart()
        {
            return await redisStorage.HashGetAll<ShoppingCarts>(key);
        }


        public Task<ShoppingCarts[]> GetAll()
        {
            return redisStorage.HashGetAll<ShoppingCarts>(key);
        }
        public async Task<List<ShoppingCartItem>> GetAllShoppingCartItem(string userId)
        {
            var shoppingCards = await GetAllItemByUserId(userId);
            var result = shoppingCards.Current.Items;
            if (result.Count > 0)
                return (List<ShoppingCartItem>)result;
            return null;
        }

        public async Task<bool> HashSet(ShoppingCarts model)
        {
            return await redisStorage.HashSet(key, model.IdentityRefId, model);
        }

        public async Task<bool> HashSet(ShoppingCartItem model)
        {
            try
            {
                var response = await redisStorage.HashSet(key, model.Id, model);
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }



        public async Task<IList<ShoppingCartItem>> GetByAccountId(string accountId)
        {
            List<ShoppingCartItem> response = new List<ShoppingCartItem>();
            var shoppingCards = await GetAllItemByUserId(accountId);
            if (shoppingCards != null)
            {
                var result = shoppingCards.Carts;
                foreach (var item in result)
                {
                    response.AddRange(item.Value.Items);
                }
                return response;
            }
            return null;
        }

        public Task<List<ShoppingCartItem>> GetAllShoppingCartItem()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> StringSet(ShoppingCarts model, string userId)
        {
            TimeSpan timeSpan = new TimeSpan(7, 0, 0, 0);
            var checkUserId = GetAllItemByUserId(userId);
            if (checkUserId != null)
            {
                await redisStorage.KeyDelete(userId + key);
                return await redisStorage.StringSet(userId + key, model, timeSpan);
            }
            else
            {
                return await redisStorage.StringSet(userId + key, model, timeSpan);
            }
        }

        public async Task<ShoppingCarts> GetAllItemByUserId(string userId)
        {
            return await redisStorage.StringGet<ShoppingCarts>(userId + key);
        }

        public async Task<bool> DeleteListItem(List<string> itemId, string userId)
        {
            var result = await GetAllItemByUserId(userId);
            if (result != null)
            {
                var cart = new ShoppingCart();
                List<ShoppingCartItem> res = new List<ShoppingCartItem>();
                List<ShoppingCartItem> resDelete = new List<ShoppingCartItem>();
                foreach (var item in result.Carts)
                {
                    res.AddRange(item.Value.Items);
                    resDelete.AddRange(item.Value.Items);
                }
                foreach (var item in res)
                {
                    foreach (var id in itemId)
                    {
                        if (item.Id == id)
                            resDelete.Remove(item);
                    }
                }
                if (resDelete.Count > 0)
                {
                    foreach (var item in resDelete)
                    {
                        cart.Items.Add(item);
                    }
                    result.Carts.Clear();
                    result.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                    return await StringSet(result, userId);
                }
                else
                {
                    return await DeleteKey(userId);
                }
            }
            return false;
        }

        public async Task<bool> DeleteItem(string id, string userId)
        {
            var result = await GetAllItemByUserId(userId);
            if (result != null)
            {
                var cart = new ShoppingCart();
                List<ShoppingCartItem> res = new List<ShoppingCartItem>();
                List<ShoppingCartItem> resDelete = new List<ShoppingCartItem>();
                foreach (var item in result.Carts)
                {
                    res.AddRange(item.Value.Items);
                    resDelete.AddRange(item.Value.Items);
                }
                foreach (var item in res)
                {
                    if (item.Id == id)
                        resDelete.Remove(item);
                }
                if (resDelete.Count > 0)
                {
                    foreach (var item in resDelete)
                    {
                        cart.Items.Add(item);
                    }
                    result.Carts.Clear();
                    result.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                    return await StringSet(result, userId);
                }
                else
                {
                    return await DeleteKey(userId);
                }
            }
            return false;
        }

        public async Task<bool> DeleteKey(string userId)
        {
            return await redisStorage.KeyDelete(userId + key);
        }

        public async Task<bool> AddShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId)
        {
            var res = await GetAllItemByUserId(userId);
            if (res != null)
            {
                bool checkDuplicate = false;
                foreach (var itemCart in res.Carts.Values)
                {
                    foreach (var item in itemCart.Items)
                    {
                        if (item.Id == shoppingCartItem.Id)
                        {
                            checkDuplicate = true;
                            item.Quantity += shoppingCartItem.Quantity;
                        }
                    }
                }
                if (checkDuplicate)
                {
                    return await StringSet(res, userId);
                }
                else
                {
                    var cart = new ShoppingCart();
                    cart.Items.Add(shoppingCartItem);
                    foreach (var cartItem in res.Carts.Values)
                    {
                        foreach (var item in cartItem.Items)
                        {
                            cart.Items.Add(item);
                        }
                    }
                    res.Carts.Clear();
                    res.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                    return await StringSet(res, userId);
                }
            }
            else
            {
                var shoppingCarts = new ShoppingCarts();
                var cart = new ShoppingCart();
                cart.Items.Add(shoppingCartItem);
                shoppingCarts.Carts.Add(ShoppingCarts.CURRENT_CART_KEY, cart);
                return await StringSet(shoppingCarts, userId);
            }
        }

        public async Task<bool> UpdateShoppingCartItem(ShoppingCartItem shoppingCartItem, string userId)
        {
            var res = await GetAllItemByUserId(userId);
            if (res != null)
            {
                bool checkDuplicate = false;
                foreach (var itemCart in res.Carts.Values)
                {
                    foreach (var item in itemCart.Items)
                    {
                        if (item.Id == shoppingCartItem.Id)
                        {
                            checkDuplicate = true;
                            item.Quantity += shoppingCartItem.Quantity;
                        }
                    }
                }
                if (checkDuplicate)
                {
                    return await StringSet(res, userId);
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

    }
}
