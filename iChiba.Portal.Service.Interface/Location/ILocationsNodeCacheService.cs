using System.Collections.Generic;
using System.Threading.Tasks;
using iChiba.Portal.Cache.Model;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationsNodeCacheService
    {
        Task<IList<LocationNode>> GetAll();
        Task<LocationNode> GetById(int id);
        Task<IList<LocationNode>> GetByIds(params int[] ids);
        Task<bool> HashSet(LocationNode model);
        Task HashDelete(int id);
    }
}
