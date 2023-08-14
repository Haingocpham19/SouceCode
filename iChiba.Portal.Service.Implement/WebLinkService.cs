using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class WebLinkService : IWebLinkService
    {
        private readonly IWebLinkCache webLinkCache;

        public WebLinkService(IWebLinkCache webLinkCache)
        {
            this.webLinkCache = webLinkCache;
        }

        public async Task<IList<WebLink>> GetAll(string languageId)
        {
            return await webLinkCache.GetAll(languageId);
        }
        public Task<IList<WebLink>> GetById(int id)
        {
            return webLinkCache.GetById(id);
        }

        public Task<IList<IList<WebLink>>> GetByIds(int[] ids, string languageId)
        {
            return webLinkCache.GetByIds(ids, languageId);
        }

        public Task<bool> HashSet(int groupId, IList<WebLink> model, string languageId)
        {
            return webLinkCache.HashSet(groupId, model, languageId);
        }

        public Task<IList<WebLink>> HashGet(int groupId, string languageId)
        {
            return webLinkCache.HashGet(groupId, languageId);
        }
    }
}
