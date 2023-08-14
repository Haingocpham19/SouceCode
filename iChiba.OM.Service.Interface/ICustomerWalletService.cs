using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.OM.Service.Interface
{
    public interface ICustomerWalletService
    {
        CustomerWallet GetByAccountId(string accountId);
    }
}
