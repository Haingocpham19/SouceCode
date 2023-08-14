using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iChiba.OM.Specification.Implement
{
    public class SupplierGetByKeyWord : SpecificationBase<Supplier>
    {
        public SupplierGetByKeyWord(string keyword)
           : base(m => string.IsNullOrEmpty(keyword)
              && (m.Code.Contains(keyword) || m.TaxCode.Contains(keyword) || m.Phone.Contains(keyword))
              && m.Active == true)
        {

        }
    }
    public class SupplierGetByAccoutIds : SpecificationBase<Supplier>
    {
        public SupplierGetByAccoutIds(params string[] accIds)
           : base(m => accIds.Contains(m.AccountId))
        {

        }
    }

    public class SupplierGetBycode : SpecificationBase<Supplier>
    {
        public SupplierGetBycode(string code)
           : base(m => ((string.IsNullOrWhiteSpace(code) || m.Code.Equals(code)) && (m.Buyer==1)))
        {

        }
    }

    public class SupplierGets : SpecificationBase<Supplier>
    {
        public SupplierGets(string code)
           : base(m => ((string.IsNullOrWhiteSpace(code) || m.Code.Equals(code)) && (m.Buyer == 1)))
        {

        }

        public SupplierGets()
          : base(m => (m.Buyer == 1))
        {

        }
    }

    public class GetSupplierGetByAccountId : SpecificationBase<Supplier>
    {
        public GetSupplierGetByAccountId(string accountId)
           : base(m => ((m.AccountId.Equals(accountId)) && (m.Buyer == 1)))
        {

        }
    }
}

