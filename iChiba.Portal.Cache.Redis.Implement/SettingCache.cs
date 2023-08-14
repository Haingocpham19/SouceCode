using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class SettingCache : BaseHashCache<Settings, string>, ISettingCache
    {
        private const string KEY = "PortalSettings";

        public SettingCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<Settings>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<Settings>>(keyLanguage);
        }

        public async Task<bool> HashSet(Settings model, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.HashSet(keyLanguage, model.Key.ToString(), model);
        }
    }
}
