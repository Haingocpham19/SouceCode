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
    public class CustomerAppService : BaseAppService, ICustomerAppService
    {
        private readonly HttpClient httpClient;

        public CustomerAppService(ILogger<CustomerAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<Customer>> GetDetail(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<Customer>();

            await TryCatchAsync(async () =>
            { 
                 var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode(); 
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<Customer>>(stringResult);
                var resData = data.Data;
                response.SetData(resData)
                    .Successful();
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<Customer>> GetDetailActivateTransport(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<Customer>();

            await TryCatchAsync(async () =>
            {
                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<Customer>>(stringResult);
                var resData = data.Data;
                response.SetData(resData)
                    .Successful();
                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Add(string group, BaseApiRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {

                var url = $"{request.Url}?group={group}";
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Update(BaseApiRequest request)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            { 
                 
                 var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<Dictionary<string, string>> GetCustomerLevel(BaseApiRequest request)
        {
            var response = new Dictionary<string, string>();

            try
            {
                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<Dictionary<string, string>>(stringResult);
            }
            catch (Exception ex)
            {
                logger.LogError(ex.Message, ex);
            }

            return response;
        }

        public async Task<BaseResponse> UpdateIdImages(CustomerVerifyUpdateRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> ActivateTransport(ActivateTransportRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> UpdateSurvey(UpdateSurveyRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> AddProfile(CustomerProfileRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseResponse> UpdateProfile(CustomerProfileRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseEntityResponse<CustomerProfileDetail>> GetProfileByKey(string key, BaseApiRequest request)
        {
            var response = new BaseEntityResponse<CustomerProfileDetail>();

            await TryCatchAsync(async () =>
            {
                var url = request.Url + "/" + key;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<CustomerProfileDetail>>(stringResult);
                var resData = data.Data;
                response.SetData(resData)
                    .Successful();
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<int>> GetBuyFee(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<int>();

            await TryCatchAsync(async () =>
            {
                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = null
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<int>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<long>> GetCashAvailable(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<long>();

            await TryCatchAsync(async () =>
            {


                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<long>>(stringResult);

                if (!data.Status)
                {
                    response.Fail(data.ErrorCode, data.Parameters);
                }
                else
                {
                    response.SetData(data.Data)
                        .Successful();
                }
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<CustomerWallet>> GetWallet(CustomerRequest request)
        {
            var response = new BaseEntityResponse<CustomerWallet>();

            await TryCatchAsync(async () =>
            {

                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<CustomerWallet>>(stringResult);
                var resData = data.Data;

                response.SetData(resData)
                    .Successful();

                response.ErrorCode = data.ErrorCode;
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<CustomerDebt>> GetDebt(BaseApiRequest request)
        {
            var response = new BaseEntityResponse<CustomerDebt>();

            await TryCatchAsync(async () =>
            {

                var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                var data = JsonConvert.DeserializeObject<BaseEntityResponse<CustomerDebt>>(stringResult);
                var resData = data.Data;

                response.SetData(resData)
                    .Successful();

                response.ErrorCode = data.ErrorCode;
                return response;
            }, response);

            return response;
        }
    }
}
