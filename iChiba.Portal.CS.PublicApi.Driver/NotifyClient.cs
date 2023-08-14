using System.Threading.Tasks;
using Core.Resilience.Http;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using iChiba.Portal.CS.PublicApi.Driver.Response;

namespace iChiba.Portal.CS.PublicApi.Driver
{
    public class NotifyConfigUrl
    {
        public string GetNotifyGroupByAppId { get; set; }
        public string AddOrUpdateCustomerNotifyConfig { get; set; }
    }

    public class NotifyClient : BaseClient
    {
        private readonly NotifyConfigUrl notifyConfigUrl;

        public NotifyClient(IHttpClient httpClient,
            IAuthorizeClient authorizeClient,
            NotifyConfigUrl notifyConfigUrl)
            : base(httpClient, authorizeClient)
        {
            this.notifyConfigUrl = notifyConfigUrl;
        }

        public async Task<GetNotifyGroupByAppIdResponse> GetNotifyGroupByAppId(GetNotifyGroupByAppIdRequest request)
        {
            var url = notifyConfigUrl.GetNotifyGroupByAppId;
            var response = await PostAsync<GetNotifyGroupByAppIdResponse, GetNotifyGroupByAppIdRequest>(url, request);
            return response;
        }

        public async Task<AddOrUpdateCustomerNotifyConfigResponse> AddOrUpdateCustomerNotifyConfig(AddOrUpdateCustomerNotifyConfigRequest request)
        {
            var url = notifyConfigUrl.AddOrUpdateCustomerNotifyConfig;
            var response = await PostAsync<AddOrUpdateCustomerNotifyConfigResponse, AddOrUpdateCustomerNotifyConfigRequest>(url, request);
            return response;
        }
    }
}