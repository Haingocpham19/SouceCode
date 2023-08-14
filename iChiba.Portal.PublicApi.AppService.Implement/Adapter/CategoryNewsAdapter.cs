using AutoMapper;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.PublicApi.AppService.Implement.Adapter
{
    public static class CategoryNewsAdapter
    {
        public static AppModel.Model.CategoryNews ToModel(this CategoryNews model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CategoryNews, AppModel.Model.CategoryNews>(model);
        }
    }
}
