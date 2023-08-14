using Core.AppModel.Response;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class CustomerBankinfoAppService : BaseAppService, ICustomerBankinfoAppService
    {
        private readonly HttpClient httpClient;

        public CustomerBankinfoAppService(ILogger<CustomerBankinfoAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<CustomerBankinfo>>> GetList(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<IList<CustomerBankinfo>>();

            await TryCatchAsync(async () =>
            {
             
                 var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<CustomerBankinfo>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<CustomerBankinfo>> GetById(int id, BaseApiRequest request)
        {
            var response = new BaseEntityResponse<CustomerBankinfo>();

            await TryCatchAsync(async () =>
            {
                var url = request.Url + "/" + id;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<CustomerBankinfo>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Add(CustomerBankinfoAddRequest request, BaseApiRequest apiRequest)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

                  
                var url = apiRequest.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + apiRequest.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Update(CustomerBankinfoUpdateRequest request, BaseApiRequest apiRequest)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(request);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");

 
                 var url = apiRequest.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + apiRequest.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Delete(int id, BaseApiRequest apiRequest)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = apiRequest.Url + "/" + id;
        
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + apiRequest.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
