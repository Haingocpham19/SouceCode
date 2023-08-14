using AutoMapper;
using iChiba.Portal.PublicApi.AppModel.Request;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class OrderAdapter
    {
        public static CS.PublicApi.Driver.Request.OrderAddRequest ToModel(this OrderAddRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderAddRequest, CS.PublicApi.Driver.Request.OrderAddRequest>(model);
        }
    }
}
