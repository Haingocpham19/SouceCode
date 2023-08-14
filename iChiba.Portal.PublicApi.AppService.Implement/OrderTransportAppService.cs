using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Ichiba.Cdn.Model;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using iChiba.Portal.PublicApi.AppModel.Response;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class OrderTransportAppService : BaseAppService, IOrderTransportAppService
    {
        private readonly HttpClient httpClient;

        public OrderTransportAppService(ILogger<OrderTransportAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }

        public async Task<BaseEntityResponse<IList<OrderServiceList>>> GetAllOrderService(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<OrderServiceList>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<OrderServiceList>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<ProductTypeList>>> GetAllProductType(string keyword, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<ProductTypeList>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "?keyword=" + keyword;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<ProductTypeList>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<PagingResponse<IList<OrderList>>> GetListByAccount(OrderTransportListRequest request, BaseApiRequest baseApi)
        {
            var response = new PagingResponse<IList<OrderList>>();

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
                response = JsonConvert.DeserializeObject<PagingResponse<IList<OrderList>>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<string>> Add(OrderTransportRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<string>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<string>>(stringResult);

                return response;
            }, response);

            return response;
        }


        public async Task<BaseResponse> Update(OrderTransportRequest request, BaseApiRequest baseApi)
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

        public async Task<BaseEntityResponse<OrderTransport>> GetDetail(int id, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<OrderTransport>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "/" + id;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<OrderTransport>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<OrderTransport>> GetDetailByTrackingNumber(OrderTransportTrackRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<OrderTransport>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<OrderTransport>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouses(BaseApiRequest baseApi)
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

        public async Task<BaseEntityResponse<IList<Warehouse>>> GetAllWarehouseTransportActive(BaseApiRequest baseApi)
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

        public async Task<BaseEntityResponse<IList<Ddimport>>> GetAllTransportDDImports(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<Ddimport>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<Ddimport>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<CountOrderTransport>>> CountOrderTranportList(OrderTransportCountRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<CountOrderTransport>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<CountOrderTransport>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<CountOrderTransportByStatus>>> CountOrderTranportListByStatus(OrderTransportByStatus request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<CountOrderTransportByStatus>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<CountOrderTransportByStatus>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<FileUploadResponse> UploadToCdn(UploadToCdnRequest request, BaseApiRequest baseApi)
        {
            var response = new FileUploadResponse();

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
                response = JsonConvert.DeserializeObject<FileUploadResponse>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseResponse> Delete(int id, BaseApiRequest baseApi)
        {
            var response = new BaseResponse();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url + "?id=" + id;

                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseResponse>(stringResult);

                return response;
            }, response);

            return response;
        }






        public async Task<BaseEntityResponse<IList<ShippingRoute>>> GetAllShippingRouteWarehouses(BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<ShippingRoute>>();

            await TryCatchAsync(async () =>
            {
                var url = baseApi.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                requestMessage.Headers.Add("Authorization", "Bearer " + baseApi.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);
                res.EnsureSuccessStatusCode();
                var stringResult = await res.Content.ReadAsStringAsync();
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<ShippingRoute>>>(stringResult);

                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<IList<PackageTrackingList>>> GetPackageTracking(PackageTrackingGetByTrackingRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<IList<PackageTrackingList>>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<IList<PackageTrackingList>>>(stringResult);
                return response;
            }, response);

            return response;
        }

        public async Task<BaseEntityResponse<bool>> ExistsTracking(OrderTransportRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<bool>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<bool>>(stringResult);
                return response;
            }, response);

            return response;
        }


        public async Task<BaseEntityResponse<bool>> CheckExitsTracking(OrderTransportRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<bool>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<bool>>(stringResult);
                return response;

            }, response);

            return response;
        }



        public async Task<BaseEntityResponse<bool>> ExistsTrackingForEdit(OrderTransportRequest request, BaseApiRequest baseApi)
        {
            var response = new BaseEntityResponse<bool>();

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
                response = JsonConvert.DeserializeObject<BaseEntityResponse<bool>>(stringResult);
                return response;
            }, response);

            return response;
        }
    }
}
