using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderDetailAdapter
    {
        public static OrderDetailViewModel ToModel(this Orderdetail model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Orderdetail, OrderDetailViewModel>(model);
        }
    }
}
