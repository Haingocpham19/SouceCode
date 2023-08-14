using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class OrderMessagesAdapter
    {
        public static OrderMessageViewModel ToModel(this OrderMessage model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<OrderMessage, OrderMessageViewModel>(model);
        }
    }
}
