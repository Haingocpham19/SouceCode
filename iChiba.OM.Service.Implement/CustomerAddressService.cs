using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using System.Collections.Generic;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class CustomerAddressService : ICustomerAddressService
    {
        private readonly ICustomerAddressRepository _customerAddressRepository;

        public CustomerAddressService(ICustomerAddressRepository customerAddressRepository)
        {
            _customerAddressRepository = customerAddressRepository;
        }

        public CustomerAddress Add(CustomerAddress model)
        {
            return _customerAddressRepository.Add(model);
        }

        public void Delete(CustomerAddress model)
        {
            _customerAddressRepository.Delete(model);
        }

        public IEnumerable<CustomerAddress> GetByCustomerId(int customerId)
        {
            var spec = new Specification<CustomerAddress>(m => m.CustomerId == customerId);
            return _customerAddressRepository.Find(spec);
        }

        public CustomerAddress GetById(int id)
        {
            var spec = new Specification<CustomerAddress>(m => m.Id == id);
            return _customerAddressRepository.Find(spec).FirstOrDefault();
        }

        public void Update(CustomerAddress model)
        {
            _customerAddressRepository.Update(model);
        }
    }
}
