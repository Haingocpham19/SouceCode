using System.Collections.Generic;
using System.Linq;
using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace iChiba.OM.Repository.Implement
{
    public class SupplierRepository : BaseRepository<CustomerDBContext, Supplier>, ISupplierRepository
    {
        public SupplierRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }

        public HashSet<string> ExistsListCode(IEnumerable<string> lstCode)
        {
            var lstQueryCode = new HashSet<string>();
            foreach (var x in lstCode)
            {
                if (!string.IsNullOrWhiteSpace(x))
                {
                    var code = x.Trim();
                    lstQueryCode.Add(code);
                }
            }

            return dbContext.Supplier.AsNoTracking()
                .Where(w => lstQueryCode.Any(
                    code => !string.IsNullOrEmpty(w.Code) && w.Code.Equals(code)))
                .Select(s => s.Code)
                .ToHashSet();
        }

        public IList<Supplier> GetByListCode(List<string> lstCode)
        {
            var lstQueryCode = new HashSet<string>();
            foreach (var x in lstCode)
            {
                if (!string.IsNullOrWhiteSpace(x))
                {
                    var code = x.Trim();
                    lstQueryCode.Add(code);
                }
            }

            return dbContext.Supplier.AsNoTracking()
                .Where(w => lstQueryCode.Any(
                    code => !string.IsNullOrEmpty(w.Code) && w.Code.Equals(code)))
                .ToList();
        }
    }
}
