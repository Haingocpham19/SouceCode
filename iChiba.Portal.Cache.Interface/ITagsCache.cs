using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ITagsCache
    {
        Task<IList<Tags>> GetAll(string languageId);
        Task<bool> StringSet(IList<Tags> models, string languageId);
        Task<IList<Tags>> GetByIds(IList<int> tagsId, string languageId);
    }
}
