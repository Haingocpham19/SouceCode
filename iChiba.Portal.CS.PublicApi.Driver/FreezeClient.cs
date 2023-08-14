using Core.AppModel.Response;
using Core.Resilience.Http;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using iChiba.Portal.CS.PublicApi.Driver.Response;
using System.Threading.Tasks;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public class FreezeConfig
    {
        public string CheckAllowBidOrTemporaryDepositProduct { get; set; }
        public string TemporaryDepositProductCancel { get; set; }
    }

    public class FreezeClient : BaseClient
    {
        private readonly FreezeConfig freezeConfig;

        public FreezeClient(IHttpClient httpClient, 
            IAuthorizeClient authorizeClient,
            FreezeConfig freezeConfig) 
            : base(httpClient, authorizeClient)
        {
            this.freezeConfig = freezeConfig;
        }

        public async Task<BaseEntityResponse<FreezeCheckAllowBidOrTemporaryDepositProduct>> CheckAllowBidOrTemporaryDepositProduct(FreezeCheckAllowBidOrTemporaryDepositProductRequest request)
        {
            var url = freezeConfig.CheckAllowBidOrTemporaryDepositProduct;
            var response = await PostAsync<BaseEntityResponse<FreezeCheckAllowBidOrTemporaryDepositProduct>, FreezeCheckAllowBidOrTemporaryDepositProductRequest>(url, request);

            return response;
        }

        public async Task<BaseResponse> TemporaryDepositProductCancel(FreezeTemporaryDepositProductCancelRequest request)
        {
            var url = freezeConfig.TemporaryDepositProductCancel;
            var response = await PostAsync<BaseResponse, FreezeTemporaryDepositProductCancelRequest>(url, request);

            return response;
        }
    }
}
