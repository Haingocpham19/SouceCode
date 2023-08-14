using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class CategoryServiceCache : BaseHashCache<CategoryService, int>, ICategoryServiceCache
    {
        private const string KEY = "PortalCategoryService";

        public CategoryServiceCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<CategoryService>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<CategoryService>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<CategoryService> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
