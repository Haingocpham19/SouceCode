using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderServiceMappingAdapter
    {

        public static OrderServiceMappingViewModel ToModel(this OrderServiceMapping model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderServiceMapping, OrderServiceMappingViewModel>(model);
        }
    }
}
