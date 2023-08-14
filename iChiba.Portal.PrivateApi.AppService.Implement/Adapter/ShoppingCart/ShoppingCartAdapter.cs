using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ShoppingCartAdapter
    {

        public static ShoppingCartViewModel ToModel(this ShoppingCartItem model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ShoppingCartItem, ShoppingCartViewModel>(model);
        }
    }
}
