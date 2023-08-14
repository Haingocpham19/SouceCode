using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Interface;
using iChiba.Portal.Cache.Model;
using iChiba.Portal.Service.Interface;

namespace iChiba.Portal.Service.Implement
{
    public class AdvBannerService : IAdvBannerService
    {
        private readonly IAdvBannerCache advBannerCache;

        public AdvBannerService(IAdvBannerCache advBannerCache)
        {
            this.advBannerCache = advBannerCache;
        }
        public Task<IList<AdvBanner>> GetBykey(string keyBanner, string languageId)
        {
            return advBannerCache.GetByKey(keyBanner, languageId);
        }
    }
}
