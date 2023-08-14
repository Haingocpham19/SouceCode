using Core.Cache.Redis.Interface;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Redis.Implement
{
    public class TagsCache : ITagsCache
    {
        private const string KEY = "PortalTags";
        private readonly IRedisStorage redisStorage;

        public TagsCache(IRedisStorage redisStorage)
        {
            this.redisStorage = redisStorage;
        }

        public async Task<IList<Tags>> GetAll(string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";
            return await redisStorage.StringGet<IList<Tags>>(keyLanguage);
        }

        public async Task<bool> StringSet(IList<Tags> models, string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";
            return await redisStorage.StringSet(keyLanguage, models);
        }

        public async Task<IList<Tags>> GetByIds(IList<int> tagsId, string languageId)
        {
            var keyLanguage = $"{KEY}-{languageId}";
            var tags = await redisStorage.StringGet<IList<Tags>>(keyLanguage);
            return tags.Where(g => tagsId.Contains(g.Id)).ToList();
        }
    }
}
