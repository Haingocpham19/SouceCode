using Core.AppModel.Response;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class WithDrawalAppService : BaseAppService, IWithDrawalAppService
    {
        private readonly HttpClient httpClient;

        public WithDrawalAppService(ILogger<WithDrawalAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<PagingResponse<IList<WithDrawal>>> GetList(WithDrawalListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<WithDrawal>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<WithDrawal>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<WithDrawal>> GetById(WithDrawalDetailRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<WithDrawal>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<WithDrawal>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<int>> Add(WithDrawalAddRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> Cancel(WithDrawalCancelRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseEntityResponse<WithDrawal>> GetWaiting(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<WithDrawal>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                Uri uri = new Uri(url);
                httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.PostAsync(uri, null);
                res.EnsureSuccessStatusCode();

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<WithDrawal>>(stringResult);

                return response;
            }, response);

            return response;
        }
    }
}
