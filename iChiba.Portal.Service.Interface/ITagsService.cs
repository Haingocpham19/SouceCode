using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface ITagsService
    {
        Task<IList<Tags>> GetAll(string languageId);
        Task<IList<Tags>> GetByIds(IList<int> tagsId, string languageId);
    }
}
