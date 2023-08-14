using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IPaymentAppService
    {
        Task<PaymentTransactionHistoryListResponse> GetPaymentTransactionHistory(PaymentTransactionHistoryRequest request);
    }
}
