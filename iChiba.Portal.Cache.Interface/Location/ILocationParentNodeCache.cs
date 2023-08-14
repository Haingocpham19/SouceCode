using iChiba.Portal.Cache.Model;
using System.Threading.Tasks;

namespace iChiba.Portal.Cache.Interface
{
    public interface ILocationParentNodeCache : IBaseHashCache<LocationParentNode, int>
    {
        Task<bool> HashSet(LocationParentNode model);
    }
}
