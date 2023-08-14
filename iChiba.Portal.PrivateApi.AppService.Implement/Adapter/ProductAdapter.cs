using AutoMapper;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ProductAdapter
    {
        public static ProductViewModel ToModel(this Product model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Product, ProductViewModel>(model);
        }
    }
}
