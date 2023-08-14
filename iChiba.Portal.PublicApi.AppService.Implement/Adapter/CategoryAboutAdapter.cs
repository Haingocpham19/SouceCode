using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class CategoryAboutAdapter
    {
        public static AppModel.Model.CategoryAbout ToModel(this CategoryAbout model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CategoryAbout, AppModel.Model.CategoryAbout>(model);
        }
    }
}
