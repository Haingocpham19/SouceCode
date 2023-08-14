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
    public class FreezeAppService : BaseAppService, IFreezeAppService
    {
        private readonly HttpClient httpClient;

        public FreezeAppService(ILogger<FreezeAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<PagingResponse<IList<Freeze>>> GetList(FreezeListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Freeze>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Freeze>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseResponse> TemporaryDepositVIP(BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;


                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
  

                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;


        }



        public async Task<BaseResponse> TemporaryDepositVIPCancel(BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url); ;
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Freeze>> CurrentTemporaryDepositVIP(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<Freeze>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url); ;
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                 
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<Freeze>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<bool>> CheckTemporaryDepositVIP(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<bool>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url; 
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url); ;
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<bool>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
