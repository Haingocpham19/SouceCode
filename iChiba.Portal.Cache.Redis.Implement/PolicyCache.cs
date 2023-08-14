using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class PolicyCache : BaseHashCache<Policy, int>, IPolicyCache
    {
        private const string KEY = "PortalPolicy";

        public PolicyCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<Policy>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<Policy>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<Policy> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
