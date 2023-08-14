using Core.AppModel.Response;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class BankinfoAppService : BaseAppService, IBankinfoAppService
    {
        private readonly HttpClient httpClient;

        public BankinfoAppService(ILogger<BankinfoAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<Bankinfo>>> GetListAll(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Bankinfo>>();

            await TryCatchAsync(async () =>
            {
                
                 var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Bankinfo>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<Bankinfo>> GetById(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankinfo>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;
            

         
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); ;
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankinfo>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Bankinfo>> GetByAccountNumber(string accountNumber, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankinfo>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + accountNumber;
                 

                
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankinfo>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Bankinfo>> GetByBankName(string bankName, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankinfo>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + bankName;



                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankinfo>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Bankinfo>>> GetListByForDepositOrDrawal(BaseApiRequest baseApi, string bankType)
        {
            var response = new BaseEntityResponse<IList<Bankinfo>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url + "?bankType=" + bankType;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Bankinfo>>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
