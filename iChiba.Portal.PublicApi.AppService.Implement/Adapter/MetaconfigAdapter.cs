using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class MetaconfigAdapter
    {
        public static AppModel.Model.Metaconfig ToModel(this Metaconfig model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Metaconfig, AppModel.Model.Metaconfig>(model);
        } 
    }
}
