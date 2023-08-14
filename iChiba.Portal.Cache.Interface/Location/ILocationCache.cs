using iChiba.Portal.Cache.Model;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ILocationCache : IBaseHashCache<Location, int>
    {
        Task<bool> HashSet(Location model);
    }
}
