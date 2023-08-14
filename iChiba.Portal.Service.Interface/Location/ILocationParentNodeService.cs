using iChiba.Portal.Cache.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.Service.Interface
{
    public interface ILocationParentNodeService
    {
        Task<LocationParentNode> GetById(int id);
        Task<IList<LocationParentNode>> GetByIds(params int[] ids);
        Task<bool> HashSet(LocationParentNode model);
        Task HashDelete(int id);
    }
}
