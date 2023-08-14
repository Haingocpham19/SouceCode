using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class LocationAdapter
    {
        public static AppModel.Model.Location ToModel(this Location model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Location, AppModel.Model.Location>(model);
        }
    }
}
