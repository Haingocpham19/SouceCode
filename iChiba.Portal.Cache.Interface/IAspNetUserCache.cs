using System.Threading.Tasks;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.Cache.Interface
{
    public interface IAspNetUserCache : IBaseHashCache<AspNetUser, string>
    {
        Task<bool> HashSet(AspNetUser model);
    }
}
