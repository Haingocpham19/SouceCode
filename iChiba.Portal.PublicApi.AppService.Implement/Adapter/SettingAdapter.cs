using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class SettingAdapter
    {
        public static AppModel.Model.Settings ToModel(this Settings model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Settings, AppModel.Model.Settings>(model);
        }
    }
}
