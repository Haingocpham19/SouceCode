using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class CustomerWalletResponse : BaseEntityResponse<CustomerWalletViewModel>
    {
        public CustomerWalletResponse()
        {
            Data = new CustomerWalletViewModel();
        }
    }

    public class WalletTransactionResponse : PagingResponse<IList<WalletTransactionViewModel>>
    {
        public WalletTransactionResponse()
        {
            Data = new List<WalletTransactionViewModel>();
        }
    }
}
