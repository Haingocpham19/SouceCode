using AutoMapper;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.ExtensionApi.AppModel.Models.ShoppingCat;
namespace iChiba.Portal.ExtensionApi.AppService.Implement.Adapter
{
    public static class ShoppingCardAdapter
    {
        public static ShoppingCartItem ToModel(this ShoppingCartItemViewModel model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map< ShoppingCartItemViewModel, ShoppingCartItem>(model);
        }
        public static ShoppingCartItemViewModel ToViewModel(this ShoppingCartItem  model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map< ShoppingCartItem, ShoppingCartItemViewModel>(model);
        }
    }
}
