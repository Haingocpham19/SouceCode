using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class CategoryNewsCache : BaseHashCache<CategoryNews, int>, ICategoryNewsCache
    {
        private const string KEY = "PortalCategoryNews";

        public CategoryNewsCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<CategoryNews>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";

            return await redisStorage.StringGet<IList<CategoryNews>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<CategoryNews> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";

            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
