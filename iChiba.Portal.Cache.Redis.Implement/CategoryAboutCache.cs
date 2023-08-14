using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class CategoryAboutCache : ICategoryAboutCache
    {
        private const string KEY = "PortalCategoryAbout";
        private readonly IRedisStorage redisStorage;

        public CategoryAboutCache(IRedisStorage redisStorage)
        {
            this.redisStorage = redisStorage;
        }

        public async Task<IList<CategoryAbout>> GetAll(string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";

            return await redisStorage.StringGet<IList<CategoryAbout>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<CategoryAbout> models, string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";

            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
