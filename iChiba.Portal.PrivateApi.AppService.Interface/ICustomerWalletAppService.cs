using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface ICustomerWalletAppService
    {
        Task<CustomerWalletResponse> GetCustomerWalletInfo();
        Task<DepositsHistoryResponse> GetListDepositsTransaction(WalletTransactionRequest request);
        Task<FreezeHistoryResponse> GetListFreezeTransaction(WalletTransactionRequest request);
        Task<WithdrawalHistoryResponse> GetListWithdrawalTransaction(WalletTransactionRequest request);
        Task<WalletTransactionResponse> GetWalletTransactionHistory(WalletTransactionRequest request);
        Task<DebtResponse> GetDebtInfo();
    }
}
