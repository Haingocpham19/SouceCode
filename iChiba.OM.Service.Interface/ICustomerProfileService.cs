using System.Collections.Generic;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface ICustomerProfileService
    {
        CustomerProfile GetByKey(string accountId, string key);
    }
}