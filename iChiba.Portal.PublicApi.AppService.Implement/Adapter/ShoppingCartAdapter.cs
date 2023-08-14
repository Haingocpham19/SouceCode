using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class ShoppingCartAdapter
    {
        public static AppModel.Model.ShoppingCart ToModel(this ShoppingCart model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ShoppingCart, AppModel.Model.ShoppingCart>(model);
        }

        public static AppModel.Model.ShoppingCartItem ToModel(this ShoppingCartItem model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ShoppingCartItem, AppModel.Model.ShoppingCartItem>(model);
        }
    }
}
