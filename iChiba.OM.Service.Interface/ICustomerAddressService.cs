using iChiba.OM.Model;
using System.Collections.Generic;

namespace iChiba.OM.Service.Interface
{
    public interface ICustomerAddressService
    {
        IEnumerable<CustomerAddress> GetByCustomerId(int customerId);
        CustomerAddress GetById(int id);
        CustomerAddress Add(CustomerAddress model);
        void Update(CustomerAddress model);
        void Delete(CustomerAddress model);
    }
}
