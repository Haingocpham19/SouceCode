using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class CategoryServiceAdapter
    {
        public static AppModel.Model.CategoryService ToModel(this CategoryService model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CategoryService, AppModel.Model.CategoryService>(model);
        }
    }
}
