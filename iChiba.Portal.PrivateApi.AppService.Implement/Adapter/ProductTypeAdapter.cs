using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ProductTypeAdapter
    {
        public static ProductTypeViewModel ToModel(this ProductType model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ProductType, ProductTypeViewModel>(model);
        }
    }
}
