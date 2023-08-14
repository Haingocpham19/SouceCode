using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class OrderServiceAppService : BaseAppService, IOrderServiceAppService
    {
        private readonly HttpClient httpClient;

        public OrderServiceAppService(ILogger<OrderServiceAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<OrderService>>> GetListAll(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<OrderService>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<OrderService>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<OrderService>> GetById(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<OrderService>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); ;
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<OrderService>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Dictionary<int, List<OrderService>>>> GetServiceActiveByOrderIds(string orderIds, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Dictionary<int, List<OrderService>>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url + "/" + orderIds;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Dictionary<int, List<OrderService>>>>(stringResult);

                return response;
            }, response);

            return response;
        }

    }
}
