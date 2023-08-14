using Core.AppModel.Response;
using Core.Resilience.Http;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using iChiba.Portal.CS.PublicApi.Driver.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public class ProofPaymentConfig
    {
        public string Add { get; set; }
        public string GetByOrderIds { get; set; }
    }

    public class ProofPaymentClient : BaseClient
    {
        private readonly ProofPaymentConfig proofPaymentConfig;

        public ProofPaymentClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            ProofPaymentConfig proofPaymentConfig)
            : base(httpClient, authorizeClient)
        {
            this.proofPaymentConfig = proofPaymentConfig;
        }

        public async Task<BaseResponse> Add(ProofPaymentAddRequest request)
        {
            var url = proofPaymentConfig.Add;
            var response = await PostAsync<BaseResponse, ProofPaymentAddRequest>(url, request);

            return response;
        }

        public async Task<BaseEntityResponse<IList<ProofPayment>>> GetByOrderIds(ProofPaymentGetByOrderIdsRequest request)
        {
            var url = proofPaymentConfig.GetByOrderIds;
            var response = await PostAsync<BaseEntityResponse<IList<ProofPayment>>, ProofPaymentGetByOrderIdsRequest>(url, request);

            return response;
        }
    }
}
