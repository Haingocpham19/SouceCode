using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface IAdvBannerCache : IBaseHashCache<IList<AdvBanner>, int>
    {
        Task<IList<AdvBanner>> GetByKey(string keyBanner, string languageId);
        Task<bool> StringSet(string key, IList<AdvBanner> model, string languageId);
    }
}
