using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class CustomerWalletAdapter
    {
        public static CustomerWalletViewModel ToModel(this CustomerWallet model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CustomerWallet, CustomerWalletViewModel>(model);
        }
    }
}
