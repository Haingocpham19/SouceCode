using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationService
    {
        Task<Location> GetById(int id);
        Task<IList<Location>> GetByIds(params int[] ids);
        Task<bool> HashSet(Location model);
        Task HashDelete(int id);
        Task<IList<Location>> GetFromIdToRoot(int id);

    }
}
