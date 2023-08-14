using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationsParentNodeCacheService
    {
        Task<LocationParentNode> GetById(int id);
        Task<IList<LocationParentNode>> GetByIds(params int[] ids);
        Task<bool> HashSet(LocationParentNode model);
        Task HashDelete(int id);
    }
}
