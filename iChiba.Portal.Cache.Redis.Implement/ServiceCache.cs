using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class ServiceCache : BaseHashCache<Service, int>, IServiceCache
    {
        private const string KEY = "PortalService";

        public ServiceCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<Service>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<Service>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<Service> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
