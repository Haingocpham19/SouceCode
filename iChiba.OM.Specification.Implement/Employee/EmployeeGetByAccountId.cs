using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class EmployeeGetByAccountId : SpecificationBase<Employee>
    {
        public EmployeeGetByAccountId(string accountId)
            : base(m => m.AccountId.Equals(accountId)
            )
        {
        }
    }
}
