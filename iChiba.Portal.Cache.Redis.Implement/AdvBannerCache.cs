using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class AdvBannerCache : BaseHashCache<IList<AdvBanner>, int>, IAdvBannerCache
    {
        private const string KEY = "PortalBanner";

        public AdvBannerCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<AdvBanner>> GetByKey(string keyBanner, string languageId)
        {
            var keyLanguage = $"{keyBanner}-{languageId}";
            return await redisStorage.StringGet<IList<AdvBanner>>(keyLanguage);
        }

        public async Task<bool> StringSet(string keyBanner, IList<AdvBanner> model, string languageId)
        {
            var keyLanguage = $"{keyBanner}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, model);
        }
    }
}
