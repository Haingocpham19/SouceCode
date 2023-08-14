using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Cache.Redis.Interface;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class AboutCache : BaseHashCache<About, int>, IAboutCache
    {
        private const string KEY = "PortalAbout";

        public AboutCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<About>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<About>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<About> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
