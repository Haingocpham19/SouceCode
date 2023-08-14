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
    public class LevelTransportGroupAppService : BaseAppService, ILevelTransportGroupAppService
    {
        private readonly HttpClient httpClient;

        public LevelTransportGroupAppService(ILogger<LevelTransportGroupAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<LevelTransportGroup>>> GetByLevel(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<LevelTransportGroup>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id; ;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<LevelTransportGroup>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<IList<ProductTypeList>>> ProductTypeByGroup(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<ProductTypeList>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id; ;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<ProductTypeList>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<ProductTypeGroup>>> ProductTypeGroup(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<ProductTypeGroup>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url; ;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<ProductTypeGroup>>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
