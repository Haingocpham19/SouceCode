using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class GroupGuidelinesCache : BaseHashCache<GroupGuidelines, int>, IGroupGuidelinesCache
    {
        private const string KEY = "PortalGroupGuidelines";

        public GroupGuidelinesCache(IRedisStorage redisStorage)
            : base(redisStorage, KEY)
        {
        }

        public async Task<IList<GroupGuidelines>> GetAll(string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringGet<IList<GroupGuidelines>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<GroupGuidelines> models, string languageId)
        {
            var keyLanguage = $"{key}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }
    }
}
