using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class NavigationAdapter
    {
        public static AppModel.Model.Navigation ToModel(this Navigation model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Navigation, AppModel.Model.Navigation>(model);
        }
    }
}
