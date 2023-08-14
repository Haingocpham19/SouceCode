using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class TagsService : ITagsService
    {

        private readonly ITagsCache tagsCache;

        public TagsService(ITagsCache tagsCache)
        {
            this.tagsCache = tagsCache;
        }

        public Task<IList<Tags>> GetAll(string languageId)
        {
            return tagsCache.GetAll(languageId);
        }

        public Task<IList<Tags>> GetByIds(IList<int> tagsId, string languageId)
        {
            return tagsCache.GetByIds(tagsId, languageId);
        }
    }
}
