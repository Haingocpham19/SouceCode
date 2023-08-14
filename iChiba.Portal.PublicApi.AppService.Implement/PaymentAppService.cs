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
    public class PaymentAppService : BaseAppService, IPaymentAppService
    {
        private readonly HttpClient httpClient;

        public PaymentAppService(ILogger<PaymentAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }


        public async Task<BaseResponse> PayOrder(PaymentPayOrderRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> CancelOrder(PaymentCancelOrderRequest request, BaseApiRequest baseApi)
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
        public async Task<BaseEntityResponse<IList<Payment>>> GetListByRef(PaymentListByRefRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Payment>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Payment>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<PagingResponse<IList<Payment>>> GetListByAccount(PaymentListByAccountRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Payment>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Payment>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<PagingResponse<IList<Payment>>> GetListByPaymentType(PaymentListByPaymentTypeRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<Payment>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<Payment>>>(stringResult);
                return response;
            }, response);

            return response;
        }
    }
}
