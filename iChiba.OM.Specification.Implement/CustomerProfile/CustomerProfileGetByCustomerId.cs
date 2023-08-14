using System.Collections.Generic;
using Core.Specification.Abstract;
using iChiba.OM.Model;
namespace iChiba.OM.Specification.Implement
{
    public class CustomerProfileGetByCustomerId: SpecificationBase<CustomerProfile>
    {
        public CustomerProfileGetByCustomerId(string customerId)
            : base(m => m.AccountId.Equals(customerId))
        {

        }
        
        public CustomerProfileGetByCustomerId(List<string> customerIds)
            : base(m => customerIds.Contains(m.AccountId))
        {

        }
    }
    public class CustomerProfileByKey : SpecificationBase<CustomerProfile>
    {
        public CustomerProfileByKey(string accountid, string key)
            : base(m => m.AccountId == accountid && m.Key.Equals(key))
        {
        }

    }
}
