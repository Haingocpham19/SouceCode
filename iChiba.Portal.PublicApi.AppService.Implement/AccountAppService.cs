using iChiba.Portal.CustomException;
using iChiba.Portal.PublicApi.AppModel.Model;
using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppModel.Response;
using iChiba.Portal.PublicApi.AppService.Interface;
using iChibaShopping.Core.AppService.Implement;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.AppService.Implement
{
    public class AccountAppService : BaseAppService, IAccountAppService
    {
        private readonly HttpClient httpClient;

        public AccountAppService(ILogger<AccountAppService> logger,
            HttpClient httpClient)
            : base(logger)
        {
            this.httpClient = httpClient;
        }
        public async Task<Object> CheckEmail(BaseApiRequest request,string email)
        {
               
        
            var url = request.Url + "?email=" + email;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

            res.EnsureSuccessStatusCode();
            var stringResult = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Object>(stringResult); 
            return data;  
        }
        public async Task<Object> CheckPhone(BaseApiRequest request, string phone)
        {
             

            var url = request.Url + "?phone=" + phone;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

            res.EnsureSuccessStatusCode();
            var stringResult = await res.Content.ReadAsStringAsync();
            var data = JsonConvert.DeserializeObject<Object>(stringResult);
            return data;
        }
        public async Task<bool> CheckUsername(BaseApiRequest request, string username)
        {

            

            var url = request.Url + "?username=" + username;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

            res.EnsureSuccessStatusCode();
            var stringResult = await res.Content.ReadAsStringAsync(); 
            return bool.Parse(stringResult);
        }
        public async Task<int> AccessFailedCount(BaseApiRequest request, string username)
        {

         

            var url = request.Url + "?username=" + username;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

            res.EnsureSuccessStatusCode();
            var stringResult = await res.Content.ReadAsStringAsync();
            return Int32.Parse(stringResult);
        }
        public async Task<bool> LockoutEnabled(BaseApiRequest request, string username)
        {

   

            var url = request.Url + "?username=" + username;
                var requestMessage = new HttpRequestMessage(HttpMethod.Get, url); 
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken); 
                var res = await httpClient.SendAsync(requestMessage);

            res.EnsureSuccessStatusCode();
            var stringResult = await res.Content.ReadAsStringAsync();
            return bool.Parse(stringResult);
        }
       

        public async Task<AccountProfileUpdateResponse> UpdateProfile(BaseApiRequest request, ProfileUpdateRequest model)
        {
            var response = new AccountProfileUpdateResponse();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json");
 
                 var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);


                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    response.Fail(res.StatusCode.ToString(), null);
                }
                else
                {
                    response.Successful();
                }

                return response;
            }, response);

            return response;
        }


        public async Task<AccountUpdatePasswordResponse> ChangePassword(BaseApiRequest request, ChangePasswordRequest model)
        {
            var response = new AccountUpdatePasswordResponse();

            await TryCatchAsync(async () =>
            {
                var json = JsonConvert.SerializeObject(model);
                var stringContent = new StringContent(json, UnicodeEncoding.UTF8, "application/json"); 
              
                 var url = request.Url;
                var requestMessage = new HttpRequestMessage(HttpMethod.Post, url)
                {
                    Content = stringContent
                };
                requestMessage.Headers.Add("Authorization", "Bearer " + request.Accesstoken);
                var res = await httpClient.SendAsync(requestMessage);

                if (res.StatusCode != System.Net.HttpStatusCode.OK)
                {
                    response.Fail(res.StatusCode.ToString(), null);
                }
                else
                {
                    var stringResult = await res.Content.ReadAsStringAsync();
                    var data = JsonConvert.DeserializeObject<Object>(stringResult);
                    response.Data = data;
                    response.Successful();
                } 
                return response;
            }, response);

            return response;
        }

      
        public async Task<AccountVerifyOTPResponse> VerifyAccountKit(AccountVerifyOTPRequest request)
        {
            var response = new AccountVerifyOTPResponse();
            await TryCatchAsync(async () =>
            {
                var accessToken = "AA";
                var appAccessToken = string.Join("|", accessToken, request.AppId, request.AccountKitAppSecret);
                var url = $"https://graph.accountkit.com/{request.AccountKitVersion}/access_token?grant_type=authorization_code&code={request.Code}&access_token={appAccessToken}";

                using (HttpClient client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                    var res = await client.SendAsync(requestMessage);
                    var content = await res.Content.ReadAsStringAsync();
                    var verifyOTPResponse = JsonConvert.DeserializeObject<AccountVerifyOTP>(content);

                    if (string.IsNullOrWhiteSpace(verifyOTPResponse.access_token))
                    {
                        response.Fail(ErrorCodeDefine.ERROR_VERIFY_PHONE, null);
                        return response;
                    }

                    // check token
                    var resUser = await VerifyTokenAndGetUserName(verifyOTPResponse.access_token, request.AccountKitVersion);

                    if (string.IsNullOrEmpty(resUser))
                    {
                        response.Fail(ErrorCodeDefine.ERROR_VERIFY_PHONE, null);
                        return response;
                    }

                    response.SetData(resUser).Successful();
                }
                return response;
            }, response);
            return response;
        }

        private async Task<string> VerifyTokenAndGetUserName(string accessToken, string accountKitVersion)
        {
            try
            {
                var url = $"https://graph.accountkit.com/{accountKitVersion}/me?access_token={accessToken}";

                using (HttpClient client = new HttpClient())
                {
                    var requestMessage = new HttpRequestMessage(HttpMethod.Get, url);
                    var response = await client.SendAsync(requestMessage);
                    var content = await response.Content.ReadAsStringAsync();
                    var userResponse = JsonConvert.DeserializeObject<UserResponse>(content);
                    var userName = string.Empty;

                    if (userResponse.email != null)
                    {
                        userName = userResponse.email.address;
                    }
                    else if (userResponse.phone != null)
                    {
                        userName = userResponse.phone.national_number;
                    }

                    if (string.IsNullOrWhiteSpace(userName))
                    {
                        throw new UnauthorizedAccessException();
                    }

                    return userName;
                }
            }
            catch
            {
                return "";
            }
            
        }
 
       
    }
}
