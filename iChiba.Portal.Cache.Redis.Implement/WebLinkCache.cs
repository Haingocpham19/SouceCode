using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class WebLinkCache : BaseHashCache<IList<WebLink>, int>, IWebLinkCache
    {
        private const string KEY = "PCS-Web-Link";

        public WebLinkCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<WebLink>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}";
            return await redisStorage.StringGet<IList<WebLink>>(keyLanguage);
        }

        public async Task<bool> HashSet(int groupId, IList<WebLink> model, string languageId)
        {
            var keyLanguage = $"{key}";
            return await redisStorage.HashSet(keyLanguage, groupId.ToString(), model);
        }

        public async Task<IList<WebLink>> HashGet(int groupId, string languageId)
        {
            var keyLanguage = $"{key}";
            return await redisStorage.HashGet<IList<WebLink>>(keyLanguage, groupId.ToString());
        }


        public async Task<IList<IList<WebLink>>> GetByIds(int[] groupids, string languageId)
        {
            var weblinkByGroupIds = new List<IList<WebLink>>();

            foreach (var groupId in groupids)
            {
                var keyLanguage = $"{key}";
                var weblinkByGroups = await redisStorage.HashGet<IList<WebLink>>(keyLanguage, groupId.ToString());
                weblinkByGroupIds.Add(weblinkByGroups);
            }

            return weblinkByGroupIds;
        }

    }
}
