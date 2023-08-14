using Core.AppModel.Response;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class DepositAppService : BaseAppService, IDepositAppService
    {
        private readonly HttpClient httpClient;

        public DepositAppService(ILogger<DepositAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<PagingResponse<IList<Deposit>>> GetList(DepositListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Deposit>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Deposit>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Deposit>> GetById(DepositDetailRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Deposit>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Deposit>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Deposit>> GetByOrderCodeInNote(DepositGetByOrderCodeInNoteRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Deposit>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Deposit>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<int>> Add(DepositAddRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<int>();

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

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<int>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Delete(int id, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;


                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Deposit>> GetWaiting(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Deposit>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;



                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Deposit>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Cancel(DepositCancelRequest request, BaseApiRequest baseApi)
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

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);
                return response;
            }, response);

            return response;
        }


        public async Task<BaseResponse> UpdatePayImage(DepositUpdatePayImageRequest request, BaseApiRequest baseApi)
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


                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
