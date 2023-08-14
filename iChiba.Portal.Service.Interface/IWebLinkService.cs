using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IWebLinkService
    {
        Task<IList<WebLink>> GetAll(string languageId);
        Task<IList<WebLink>> GetById(int id);
        Task<IList<IList<WebLink>>> GetByIds(int[] ids, string languageId);
        Task<bool> HashSet(int groupId, IList<WebLink> model, string languageId);
        Task<IList<WebLink>> HashGet(int groupId, string languageId);
    }
}
