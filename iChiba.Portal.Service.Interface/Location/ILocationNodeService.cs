using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationNodeService
    {
        Task<LocationNode> GetById(int id);
        Task<IList<LocationNode>> GetByIds(params int[] ids);
        Task<bool> HashSet(LocationNode model);
        Task HashDelete(int id);
    }
}
