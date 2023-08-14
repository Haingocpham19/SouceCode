using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class NavigationService : INavigationService
    {

        private readonly INavigationCache navigationCache;

        public NavigationService(INavigationCache navigationCache)
        {
            this.navigationCache = navigationCache;
        }

        public Task<IList<Navigation>> GetAll(string languageId)
        {
            return navigationCache.GetAll(languageId);
        }
    }
}
