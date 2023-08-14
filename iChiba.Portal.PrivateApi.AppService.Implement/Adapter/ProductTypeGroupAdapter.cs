using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ProductTypeGroupAdapter
    {
        public static ProductTypeGroupViewModel ToModel(this ProductTypeGroup model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<ProductTypeGroup, ProductTypeGroupViewModel>(model);
        }
    }
}
