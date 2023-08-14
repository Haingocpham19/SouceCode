using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class DepositsAdapter
    {
        public static DepositsViewModel ToModel(this Deposits model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Deposits, DepositsViewModel>(model);
        }
    }
}
