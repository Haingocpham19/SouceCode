using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class CategoryNewsService : ICategoryNewsService
    {

        private readonly ICategoryNewsCache categoryNewsCache;

        public CategoryNewsService(ICategoryNewsCache categoryNewsCache)
        {
            this.categoryNewsCache = categoryNewsCache;
        }

        public Task<IList<CategoryNews>> GetAll(string languageId)
        {
            return categoryNewsCache.GetAll(languageId);
        }
    }
}
