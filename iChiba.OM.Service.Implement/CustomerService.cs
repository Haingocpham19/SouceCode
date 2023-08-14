using Core.Common;
using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;
using System;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepository;

        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetByAccountId(string accountId)
        {
            return _customerRepository.Find(new CustomerGetByAccountId(accountId)).FirstOrDefault();
        }
    }
}
