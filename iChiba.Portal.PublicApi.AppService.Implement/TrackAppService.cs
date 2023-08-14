using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class TrackAppService : BaseAppService, ITrackAppService
    {
        private readonly HttpClient httpClient;

        public TrackAppService(ILogger<TrackAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<TrackOrderResponse>> Order(TrackOrderRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<TrackOrderResponse>();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<TrackOrderResponse>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<TrackOrderResponse>> PublicOrder(TrackOrderRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<TrackOrderResponse>();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<TrackOrderResponse>>(stringResult);
                return response;
            }, response);

            return response;
        }
    }
}
