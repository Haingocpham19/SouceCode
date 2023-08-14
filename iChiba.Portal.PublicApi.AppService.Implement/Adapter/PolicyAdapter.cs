using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class PolicyAdapter
    {
        public static AppModel.Model.Policy ToModel(this Policy model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Policy, AppModel.Model.Policy>(model);
        }
    }
}
