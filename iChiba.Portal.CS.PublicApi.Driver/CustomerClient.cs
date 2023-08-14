using Core.AppModel.Response;
using Core.Resilience.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public class CustomerConfig
    {
        public string GetBuyFee { get; set; }
        public string GetBuyFeeByCurrency { get; set; }
        public string GetMaxBid { get; set; }
    }

    public class CustomerClient : BaseClient
    {
        private readonly CustomerConfig customerConfig;

        public CustomerClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            IOptions<CustomerConfig> customerConfig)
            : base(httpClient, authorizeClient)
        {
            this.customerConfig = customerConfig.Value;
        }

        public async Task<BaseEntityResponse<int>> GetBuyFee()
        {
            var url = customerConfig.GetBuyFee;
            var response = await PostAsync<BaseEntityResponse<int>, object>(url, null);

            return response;
        }
        public async Task<BaseEntityResponse<int>> GetBuyFeeByCurrency(string currency)
        {
            var url = customerConfig.GetBuyFeeByCurrency + "/" + currency;
            var response = await PostAsync<BaseEntityResponse<int>, object>(url, null);

            return response;
        }

        public async Task<BaseEntityResponse<int>> GetMaxBid()
        {
            var url = customerConfig.GetMaxBid;
            var response = await PostAsync<BaseEntityResponse<int>, object>(url, null);

            return response;
        }
    }
}
