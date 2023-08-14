using Core.Specification.Abstract;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using System.Linq;

namespace iChiba.OM.Service.Implement
{
    public class CustomerWalletService : ICustomerWalletService
    {
        private readonly ICustomerWalletRepository _customerWalletRepository;

        public CustomerWalletService(ICustomerWalletRepository customerWalletRepository)
        {
            _customerWalletRepository = customerWalletRepository;
        }

        public CustomerWallet GetByAccountId(string accountId)
        {
            var spec = new Specification<CustomerWallet>(m => !string.IsNullOrEmpty(accountId) && m.AccountId == accountId);
            return _customerWalletRepository.Find(spec).FirstOrDefault();
        }
    }
}
