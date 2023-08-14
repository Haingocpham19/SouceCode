using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderPackageProductAdapter
    {
        public static OrderPackageProductViewModel ToModel(this OrderPackageProduct model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderPackageProduct, OrderPackageProductViewModel>(model);
        }
        public static OrderPackageProduct ToModel(this OrderPackageProductAddRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderPackageProductAddRequest, OrderPackageProduct>(model);
        }
    }
}
