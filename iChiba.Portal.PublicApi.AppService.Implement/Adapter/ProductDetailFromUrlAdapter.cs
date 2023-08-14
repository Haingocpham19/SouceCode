using AutoMapper;
using Ichiba.Partner.Api.Driver.Response;
using PCS.Partner.Api.AppModel.Model;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class ProductDetailFromUrlAdapter
    {
        public static AppModel.Model.ProductDetail ToModel(this ProductDetail model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ProductDetail, AppModel.Model.ProductDetail>(model);
        }


        public static IList<AppModel.Model.ShipquocteNews> ToModel(this IList<ShipquocteNews> model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<IList<ShipquocteNews>, IList<AppModel.Model.ShipquocteNews>>(model);
        }
    }
}
