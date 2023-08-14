using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iChiba.OM.Specification.Implement
{
    public class SupplierGetBy : SpecificationBase<Supplier>
    {
        public SupplierGetBy(string keyword, string code, string taxcode, bool? active, DateTime? startTime, DateTime? EndTime, string phone)
           : base(m => string.IsNullOrWhiteSpace(keyword)
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (string.IsNullOrWhiteSpace(taxcode) || m.TaxCode.Contains(taxcode))
              && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
              && (active == null || m.Active == active)
           )
        {

        }
        public SupplierGetBy(params string[] uid)
           : base(m => uid.Contains(m.Uid))
        {

        }
        public SupplierGetBy(string uid)
          : base(m => uid==m.Uid)
        {

        }
    }
    public class SupplierSyncGetBy : SpecificationBase<Supplier>
    {
        public SupplierSyncGetBy(string keyword, string code, string taxcode, bool? active, DateTime? startTime, DateTime? EndTime, string phone)
           : base(m => string.IsNullOrWhiteSpace(keyword)
              && (string.IsNullOrWhiteSpace(code) || m.Code.Contains(code))
              && (string.IsNullOrWhiteSpace(taxcode) || m.TaxCode.Contains(taxcode))
              && (string.IsNullOrWhiteSpace(phone) || m.Phone.Contains(phone))
              && (active == null || m.Active == active)
                && (m.Code != null)
           )
        {

        }
    }

    public class SupplierSearchByCode : SpecificationBase<Supplier>
    {
        public SupplierSearchByCode(string keyword)
            : base(m => m.Code.Contains(keyword))
        {
        }
    }

    public class SupplierGetSingerByCode : SpecificationBase<Supplier>
    {
        public SupplierGetSingerByCode(string code)
            : base(m => m.Code.Contains(code))
        {
        }
    }


    public class SupplierSearchById : SpecificationBase<Supplier>
    {
        public SupplierSearchById(params int[] ids)
            : base(m => ids.Contains(m.Id))
        {
        }
    }

    public class SupplierSearchByArrCode : SpecificationBase<Supplier>
    {
        public SupplierSearchByArrCode(params string[] code)
            : base(m => code.Contains(m.Code))
        {
        }
    }

    public class SupplierGetByCodes : SpecificationBase<Supplier>
    {
        public SupplierGetByCodes(params string[] code)
            : base(m => code.Contains(m.Code) && (m.Buyer == 1))
        {
        }
    }


    public class SupplierSearchBylstCode : SpecificationBase<Supplier>
    {
        public SupplierSearchBylstCode(List<string> codes,string code)
            : base(m => (codes == null || codes.Count == 0 || codes.Contains(m.Code)) && (m.Buyer == 1) && (string.IsNullOrWhiteSpace(code) || m.Code.Equals(code)))
        {
        }
    }


    public class SupplierGetByObjectCode : SpecificationBase<Supplier>
    {
        public SupplierGetByObjectCode(params string[] objectCodes)
            : base(m => objectCodes.Contains(m.Code))
        {
        }
    }

    public class SupplierSearchByPhone : SpecificationBase<Supplier>
    {
        public SupplierSearchByPhone(string keyword)
            : base(m => m.Phone.Contains(keyword))
        {
        }
    }

    public class SupplierSearchByEmail : SpecificationBase<Supplier>
    {
        public SupplierSearchByEmail(string keyword)
            : base(m => m.Email.Contains(keyword))
        {
        }
    }

    public class SupplierSearchByName : SpecificationBase<Supplier>
    {
        public SupplierSearchByName(string keyword)
            : base(m => m.Name.Contains(keyword))
        {
        }
    }

    public class SupplierGetByCode : SpecificationBase<Supplier>
    {
        public SupplierGetByCode(string code)
            : base(m => m.Code.Equals(code))
        {
        }
    }

    public class SupplierGetByAccountId : SpecificationBase<Supplier>
    {
        public SupplierGetByAccountId(string accountId)
            : base(m => m.AccountId.Equals(accountId))
        {
        }
    }
    public class SupplierGetByBuyer : SpecificationBase<Supplier>
    {
        public SupplierGetByBuyer(string keyword)
            : base(m => (string.IsNullOrWhiteSpace(keyword)
            || m.Name.Contains(keyword) 
            || m.Country.Contains(keyword) 
            || m.Email.Contains(keyword) 
            || m.BankName.Contains(keyword))
            && (m.Buyer==1)
            )
            
        {
        }
    }
}

