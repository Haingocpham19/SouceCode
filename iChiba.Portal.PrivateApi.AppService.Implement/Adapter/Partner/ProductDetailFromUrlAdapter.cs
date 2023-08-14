using AutoMapper;
using Ichiba.Partner.Api.Driver.Response;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ProductDetailFromUrlAdapter
    {
        public static AppModel.Models.ProductDetail ToModel(this ProductDetail model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ProductDetail, AppModel.Models.ProductDetail>(model);
        }
    }
}
