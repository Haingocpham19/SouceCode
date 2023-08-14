using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IWebLinkGroupCache : IBaseHashCache<WebLinkGroup, int>
    {
        Task<IList<WebLinkGroup>> GetAll(string languageId);
        Task<bool> StringSet(IList< WebLinkGroup> models, string languageId);
    }
}
