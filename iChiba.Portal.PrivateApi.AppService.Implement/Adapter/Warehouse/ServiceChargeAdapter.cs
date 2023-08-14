using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.WH.Model;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class ServiceChargeAdapter
    {
        public static ServiceChargeViewModel ToModel(this ServiceCharge model)
        {
            return model == null ? null : Mapper.Map<ServiceCharge, ServiceChargeViewModel>(model);
        }
    }
}
