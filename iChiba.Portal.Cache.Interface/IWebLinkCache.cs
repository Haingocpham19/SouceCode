using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IWebLinkCache : IBaseHashCache<IList<WebLink>, int>
    {
        Task<IList<WebLink>> GetAll(string languageId);
        Task<bool> HashSet(int groupId,IList<WebLink> model, string languageId);
        Task<IList<WebLink>> HashGet(int groupId, string languageId);
        Task<IList<IList<WebLink>>> GetByIds(int[] groupids, string languageId);
    }
}
