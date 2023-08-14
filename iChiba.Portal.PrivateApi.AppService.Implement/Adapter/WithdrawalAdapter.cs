using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class WithdrawalAdapter
    {
        public static WithdrawalViewModel ToModel(this Withdrawal model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Withdrawal, WithdrawalViewModel>(model);
        }
    }
}
