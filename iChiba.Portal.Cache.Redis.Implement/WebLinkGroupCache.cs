using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class WebLinkGroupCache : BaseHashCache<WebLinkGroup, int>, IWebLinkGroupCache
    {
        private const string KEY = "PCS-Web-Link-Group";

        public WebLinkGroupCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<WebLinkGroup>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}";
            return await redisStorage.StringGet<IList<WebLinkGroup>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<WebLinkGroup> models, string languageId)
        {
            var keyLanguage = $"{key}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
