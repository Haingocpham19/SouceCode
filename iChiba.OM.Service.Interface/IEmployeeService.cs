using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IEmployeeService
    {
        Employee GetByAccountId(string accountId);
    }
}
