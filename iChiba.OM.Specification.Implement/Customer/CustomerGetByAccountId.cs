using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class CustomerGetByAccountId : SpecificationBase<Customer>
    {
        public CustomerGetByAccountId(string accountId)
            : base(m => m.AccountId.Equals(accountId)
            )
        {
        }
    }

    public class CustomerSingleBySpecGetByCode : SpecificationBase<Customer>
    {
        public CustomerSingleBySpecGetByCode(string code)
            : base(m => m.Code.Equals(code)
            )
        {
        }
    }

    public class CustomerSingleByCode : SpecificationBase<Customer>
    {
        public CustomerSingleByCode(string accountId)
            : base(m => m.Code != null && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId)))
        {
        }
    }

    public class CustomerListCustomerByCare : SpecificationBase<Customer>
    {
        public CustomerListCustomerByCare(string[] accounts,string accountId)
            : base(m => accounts.Contains(m.AccountId) && m.Code!=null && (string.IsNullOrWhiteSpace(accountId) || m.AccountId.Contains(accountId)))
        {
        }
    }

    public class CustomerGetByCode : SpecificationBase<Customer>
    {
        public CustomerGetByCode(params string[] code)
            : base(m => code.Contains(m.Code)
            )
        {
        }

        public CustomerGetByCode(int[] listCustomerId)
          : base(m => listCustomerId.Contains(m.Id)
          )
        {
        }
    }
}
