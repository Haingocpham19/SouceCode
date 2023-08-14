using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class RecruitmentAdapter
    {
        public static AppModel.Model.Recruitment ToModel(this Recruitment model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<Recruitment, AppModel.Model.Recruitment>(model);
        }
    }
}
