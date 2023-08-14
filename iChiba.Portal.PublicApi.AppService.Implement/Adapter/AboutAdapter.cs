using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class AboutAdapter
    {
        public static AppModel.Model.About ToModel(this About model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<About, AppModel.Model.About>(model);
        } 
    }
}
