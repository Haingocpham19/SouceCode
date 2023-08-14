using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class WebLinkGroupService : IWebLinkGroupService
    {

        private readonly IWebLinkGroupCache webLinkGroupCache;

        public WebLinkGroupService(IWebLinkGroupCache WebLinkGroupCache)
        {
            this.webLinkGroupCache = WebLinkGroupCache;
        }

        public Task<IList<WebLinkGroup>> GetAll(string languageId)
        {
            return webLinkGroupCache.GetAll(languageId);
        }

        public Task<WebLinkGroup> GetById(int id)
        {
            return webLinkGroupCache.GetById(id);
        }

        public Task<IList<WebLinkGroup>> GetByIds(params int[] ids)
        {
            return webLinkGroupCache.GetByIds(ids);
        }
    }
}
