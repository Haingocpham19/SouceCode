
using System.Collections.Generic;
using System.Linq;
using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class CustomerProfileService : ICustomerProfileService
    {
        private readonly ICustomerProfileRepository _customerProfileRepository;

        public CustomerProfileService(ICustomerProfileRepository customerProfileRepository)
        {
            _customerProfileRepository = customerProfileRepository;
        }

        public CustomerProfile GetByKey(string accountId, string key)
        {
            throw new System.NotImplementedException();
        }
    }
}
