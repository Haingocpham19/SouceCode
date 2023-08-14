using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class GuidelinesAdapter
    {
        public static AppModel.Model.Guidelines ToModel(this Guidelines model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Guidelines, AppModel.Model.Guidelines>(model);
        }
    }
}
