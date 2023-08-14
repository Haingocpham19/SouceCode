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
    public class BankicAppService : BaseAppService, IBankicAppService
    {
        private readonly HttpClient httpClient;

        public BankicAppService(ILogger<BankicAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<Bankic>>> GetListAll(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Bankic>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Bankic>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Bankic>>> GetListActiveDeposit(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Bankic>>();

            await TryCatchAsync(async () =>
            {

                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Bankic>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Bankic>> GetById(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankic>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;



                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankic>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Bankic>> GetByAccountNumber(string accountNumber, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankic>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + accountNumber;



                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankic>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Bankic>> GetByBankName(string bankName, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Bankic>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + bankName;



                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Bankic>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
