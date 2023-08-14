using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface IAdvBannerService
    {
        Task<IList<AdvBanner>> GetBykey(string keyBanner, string languageId);
    }
}
