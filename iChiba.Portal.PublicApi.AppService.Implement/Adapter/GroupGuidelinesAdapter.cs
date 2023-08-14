using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class GroupGuidelinesAdapter
    {
        public static AppModel.Model.GroupGuidelines ToModel(this GroupGuidelines model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<GroupGuidelines, AppModel.Model.GroupGuidelines>(model);
        }
    }
}
