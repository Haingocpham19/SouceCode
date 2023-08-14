using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class CategoryAboutService : ICategoryAboutService
    {

        private readonly ICategoryAboutCache categoryAboutCache;

        public CategoryAboutService(ICategoryAboutCache categoryAboutCache)
        {
            this.categoryAboutCache = categoryAboutCache;
        }

        public Task<IList<CategoryAbout>> GetAll(string languageId)
        {
            return categoryAboutCache.GetAll(languageId);
        }
    }
}
