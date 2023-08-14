using Core.Specification.Abstract;
using iChiba.OM.Model;
using System.Linq;

namespace iChiba.OM.Specification.Implement
{
    public class CustomerGetByIds: SpecificationBase<Customer>
    {
        public CustomerGetByIds(params int[] ids)
            : base(m => ids.Contains(m.Id))
        {
        }
    }

    public class CustomerGetByAccountIds : SpecificationBase<Customer>
    {
        public CustomerGetByAccountIds(params string[] accountIds)
            : base(m => accountIds.Contains(m.CareBy))
        {
        }
    }


    public class CustomerGetByAccountIdsDefault : SpecificationBase<Customer>
    {
        public CustomerGetByAccountIdsDefault(params string[] accountIds)
            : base(m => accountIds.Contains(m.AccountId))
        {
        }
    }

    public class CustomerGetByObjectCode : SpecificationBase<Customer>
    {
        public CustomerGetByObjectCode(params string[] objectCode)
            : base(m => objectCode.Contains(m.Code))
        {
        }
    }

    public class CustomerGetBySales: SpecificationBase<Customer>
    {
        public CustomerGetBySales(params string[] Id)
            : base(m => Id.Contains(m.CareBy))
        {
        }
        public CustomerGetBySales(string keyword,params string[] Id)
            : base(m => Id.Contains(m.CareBy) && (m.Fullname.Contains(keyword) || m.Email.Contains(keyword) || m.Phone.Contains(keyword)||  m.IdName.Contains(keyword)))
        {
        }
    }


    public class CustomerSearchByCode : SpecificationBase<Customer>
    {
        public CustomerSearchByCode(string keyword)
            : base(m => m.Code.Contains(keyword))
        {
        }
    }

    public class CustomerSearchByPhone : SpecificationBase<Customer>
    {
        public CustomerSearchByPhone(string keyword)
            : base(m => m.Phone.Contains(keyword))
        {
        }
    }

    public class CustomerSearchByUsername : SpecificationBase<Customer>
    {
        public CustomerSearchByUsername(string keyword)
            : base(m => m.Username.Contains(keyword))
        {
        }
    }

    public class CustomerSearchByEmail : SpecificationBase<Customer>
    {
        public CustomerSearchByEmail(string keyword)
            : base(m => m.Email.Contains(keyword))
        {
        }
    }

    public class CustomerSearchByFullName : SpecificationBase<Customer>
    {
        public CustomerSearchByFullName(string keyword)
            : base(m => m.Fullname.Contains(keyword))
        {
        }
    }
}
