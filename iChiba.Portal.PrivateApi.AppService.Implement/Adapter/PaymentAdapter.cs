using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class PaymentAdapter
    {
        public static PaymentViewModel ToModel(this Payment model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Payment, PaymentViewModel>(model);
        }
    }
}
