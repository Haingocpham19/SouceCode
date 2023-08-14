using iChiba.Portal.PublicApi.Driver.Interface;
using System.Threading.Tasks;
using Core.Resilience.Http;
using Microsoft.Extensions.Options;
using iChiba.Portal.Common.Configuration;
using iChiba.Event.Api.AppModel.Model;
using iChiba.Shared.Models;

namespace iChiba.Portal.PublicApi.Driver.Implement
{
    public class NotifyClient : BaseClient, INotifyClient
    {
        private readonly IOptions<NotifyApiUriConfig> _notifyApiUriConfig;

        public NotifyClient(
            IHttpClient httpClient,
            AuthorizeClient authorizeClient,
            IOptions<NotifyApiUriConfig> notifyApiUriConfig)
            : base(httpClient, authorizeClient)
        {
            _notifyApiUriConfig = notifyApiUriConfig;
        }

        public async Task<IChibaResponse> Send(NotifyModel request)
        {
            var url = _notifyApiUriConfig.Value.Send;
            var response = await PostAsync<IChibaResponse, NotifyModel>(url, request);
            return response;
        }

        public async Task<IChibaResponse> SubscribeToTopic(SubscribeNotifyModel request)
        {
            var url = _notifyApiUriConfig.Value.SubscribeToTopic;
            var response = await PostAsync<IChibaResponse, SubscribeNotifyModel>(url, request);
            return response;
        }

        public async Task<IChibaResponse> UnsubscribeFromTopic(SubscribeNotifyModel request)
        {
            var url = _notifyApiUriConfig.Value.UnsubscribeFromTopic;
            var response = await PostAsync<IChibaResponse, SubscribeNotifyModel>(url, request);
            return response;
        }
    }
}
