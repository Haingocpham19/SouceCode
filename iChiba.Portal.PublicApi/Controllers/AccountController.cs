using iChiba.Portal.PublicApi.AppModel.Request;
using iChiba.Portal.PublicApi.AppService.Interface;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace iChiba.Portal.PublicApi.Controllers
{
    public class AccountConfig
    {
        public string Profile { get; set; }
        public string UpdateProfile { get; set; }
        public string ChangePassword { get; set; }
        public string CheckHasPassword { get; set; }
        public string SetPassword { get; set; }
        public string CheckEmail { get; set; }
        public string CheckPhone { get; set; }
        public string CheckUsername { get; set; }
        public string AccessFailedCount { get; set; }
        public string LockoutEnabled { get; set; }
    }

    [Authorize]
    public class AccountController : BaseController
    {
        private readonly AccountConfig accountConfig;
        private readonly IAccountAppService accountAppService;

        public AccountController(ILogger<AccountController> logger,
            IOptions<AccountConfig> accountConfig,
            IAccountAppService accountAppService
            )
            : base(logger)
        {
            this.accountConfig = accountConfig.Value;
            this.accountAppService = accountAppService;
        }



        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.CheckEmail;
            var apirequest = new BaseApiRequest() { Url= url, Accesstoken=accessToken};
            var response = await accountAppService.CheckEmail(apirequest,email);
            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckPhone(string phone)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.CheckPhone;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken };
            var response = await accountAppService.CheckPhone(apirequest, phone);
            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> CheckUsername(string username)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.CheckUsername;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken };
            var response = await accountAppService.CheckUsername(apirequest, username);
            return Ok(response);
        }

        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> AccessFailedCount(string username)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.CheckEmail;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken };
            var response = await accountAppService.AccessFailedCount(apirequest, username);
            return Ok(response);
        }
        [HttpGet]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> LockoutEnabled(string username)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.CheckEmail;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken };
            var response = await accountAppService.LockoutEnabled(apirequest, username);
            return Ok(response);
        }
        //-----------
    

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateProfile(ProfileUpdateRequest model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.UpdateProfile;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken }; 
            var response = await accountAppService.UpdateProfile(apirequest, model); 
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        [ProducesResponseType((int)HttpStatusCode.Forbidden)]
        [ProducesResponseType((int)HttpStatusCode.OK)]
        public async Task<IActionResult> ChangePassword(ChangePasswordRequest model)
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            var url = accountConfig.ChangePassword;
            var apirequest = new BaseApiRequest() { Url = url, Accesstoken = accessToken }; 
            var response = await accountAppService.ChangePassword(apirequest, model); 
            return Ok(response);
        }
         
    }

}