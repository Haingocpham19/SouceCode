using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class WarehouseAppService : BaseAppService, IWarehouseAppService
    {
        private readonly HttpClient httpClient;

        public WarehouseAppService(ILogger<WarehouseAppService> logger, 
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }



        public async Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouseActive(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Warehouse>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Warehouse>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Warehouse>> GetDetail(BaseApiRequest baseApi, int id)
        {
            var response = new BaseEntityResponse<Warehouse>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Warehouse>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Warehouse>> GetByCode(BaseApiRequest baseApi, string code)
        {
            var response = new BaseEntityResponse<Warehouse>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + code;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Warehouse>>(stringResult);
                return response;
            }, response);

            return response;
        }
    }
}
