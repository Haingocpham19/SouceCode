using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class AdvBannerAdapter
    {
        public static AppModel.Model.AdvBanner ToModel(this AdvBanner model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<AdvBanner, AppModel.Model.AdvBanner>(model);
        }
    }
}
