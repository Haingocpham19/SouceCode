using AutoMapper;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class ServiceAdapter
    {
        public static AppModel.Model.Service ToModel(this Cache.Model.Service model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Cache.Model.Service, AppModel.Model.Service>(model);
        }
    }
}
