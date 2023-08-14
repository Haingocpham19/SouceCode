using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;
using iChiba.Portal.CS.PublicApi.Driver;
using iChiba.Portal.CS.PublicApi.Driver.Request;
using iChiba.Portal.CS.PublicApi.Driver.Response;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class NotifyAppService : BaseAppService, INotifyAppService
    {
        private readonly NotifyClient notifyClient;

        public NotifyAppService(ILogger<NotifyAppService> logger,
            NotifyClient notifyClient)
            : base(logger)
        {
            this.notifyClient = notifyClient;
        }

        public async Task<GetNotifyGroupByAppIdResponse> GetNotifyGroupByAppId(GetNotifyGroupByAppIdRequest request)
        {
            var response = new GetNotifyGroupByAppIdResponse();

            await TryCatchAsync(async () =>
            {
                response = await notifyClient.GetNotifyGroupByAppId(request);

                return response;
            }, response);

            return response;
        }

        public async Task<AddOrUpdateCustomerNotifyConfigResponse> AddOrUpdateCustomerNotifyConfig(AddOrUpdateCustomerNotifyConfigRequest request)
        {
            var response = new AddOrUpdateCustomerNotifyConfigResponse();

            await TryCatchAsync(async () =>
            {
                response = await notifyClient.AddOrUpdateCustomerNotifyConfig(request);

                return response;
            }, response);

            return response;
        }
    }
}