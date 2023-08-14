using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class TagsAdapter
    {
        public static AppModel.Model.Tags ToModel(this Tags model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Tags, AppModel.Model.Tags>(model);
        }
    }
}
