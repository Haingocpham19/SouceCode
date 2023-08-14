using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class FreezeAdapter
    {
        public static FreezeViewModel ToModel(this Freeze model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Freeze, FreezeViewModel>(model);
        }
    }
}
