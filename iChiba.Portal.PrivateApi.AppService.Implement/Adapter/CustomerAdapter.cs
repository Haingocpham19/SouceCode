using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class CustomerAdapter
    {
        public static CustomerViewModel ToModel(this Customer model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Customer, CustomerViewModel>(model);
        }
    }
}
