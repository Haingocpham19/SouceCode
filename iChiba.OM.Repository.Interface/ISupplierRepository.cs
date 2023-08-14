using System.Collections.Generic;
using Core.Repository.Interface;
using iChiba.OM.Model;

namespace iChiba.OM.Repository.Interface
{
    public interface ISupplierRepository : IRepository<Supplier>
    {
        HashSet<string> ExistsListCode(IEnumerable<string> lstCode);
        IList<Supplier> GetByListCode(List<string> lstCode);
    }
}
