using iChiba.Portal.Cache.Model;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ILocationNodeCache : IBaseHashCache<LocationNode, int>
    {
        Task<bool> HashSet(LocationNode model);
    }
}
