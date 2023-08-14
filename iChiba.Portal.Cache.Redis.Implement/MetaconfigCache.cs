using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class MetaconfigCache : IMetaconfigCache
    {
        private const string KEY = "PortalMetaconfig";
        private readonly IRedisStorage redisStorage;

        public MetaconfigCache(IRedisStorage redisStorage)
        {
            this.redisStorage = redisStorage;
        }

        public async Task<IList<Metaconfig>> GetAll(string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";
            return await redisStorage.StringGet<IList<Metaconfig>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<Metaconfig> models, string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
