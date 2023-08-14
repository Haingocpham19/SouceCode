using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class CategoryServiceService : ICategoryServiceService
    {

        private readonly ICategoryServiceCache categoryServiceCache;

        public CategoryServiceService(ICategoryServiceCache categoryServiceCache)
        {
            this.categoryServiceCache = categoryServiceCache;
        }

        public Task<IList<CategoryService>> GetAll(string languageId)
        {
            return categoryServiceCache.GetAll(languageId);
        }
    }
}
