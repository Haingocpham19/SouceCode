using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class AboutService : IAboutService
    {

        private readonly IAboutCache aboutCache;

        public AboutService(IAboutCache aboutCache)
        {
            this.aboutCache = aboutCache;
        }

        public Task<IList<About>> GetAll(string languageId)
        {
            return aboutCache.GetAll(languageId);
        }
    }
}
