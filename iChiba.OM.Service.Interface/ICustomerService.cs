using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface ICustomerService
    {
        Customer GetByAccountId(string accountId);
    }
}
