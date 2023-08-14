using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class NavigationCache : BaseHashCache<Navigation, int>, INavigationCache
    {
        private const string KEY = "PortalNavigation";

        public NavigationCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<Navigation>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<Navigation>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<Navigation> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
