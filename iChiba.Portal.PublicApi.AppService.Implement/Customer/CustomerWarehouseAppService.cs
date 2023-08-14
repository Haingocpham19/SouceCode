using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class CustomerWarehouseAppService : BaseAppService, ICustomerWarehouseAppService
    {
        private readonly HttpClient httpClient;

        public CustomerWarehouseAppService(ILogger<CustomerWarehouseAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<CustomerWarehouse>>> GetWarehousesByCustomer(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<CustomerWarehouse>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<CustomerWarehouse>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Add(CustomerWarehouseAddRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

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
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Delete(int warehouseId, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "?warehouseId=" + warehouseId;

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
