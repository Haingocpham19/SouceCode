using AutoMapper;
using iChiba.Portal.ExtensionApi.AppModel.Model.ProductDetail;
using Ichiba.Partner.Api.Driver.Response;
namespace iChiba.Portal.ExtensionApi.AppService.Implement.Adapter.ProductDetailFrom
{
    public static class ProductDetailFromUrlAdapter
    {
        public static ProductDetailViewModel ToModel(this ProductDetail model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ProductDetail, ProductDetailViewModel>(model);
        }
    }
}
