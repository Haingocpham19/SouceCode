using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IWebLinkGroupService
    {
        Task<IList<WebLinkGroup>> GetAll(string languageId); 
        Task<WebLinkGroup> GetById(int id);
        Task<IList<WebLinkGroup>> GetByIds(params int[] ids);
    }
}
