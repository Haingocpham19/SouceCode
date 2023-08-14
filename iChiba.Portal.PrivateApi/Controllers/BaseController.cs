using System.Threading.Tasks;
using iChiba.IS4.Api.Driver;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger logger;
        private readonly AccessClient _accessClient;

        public BaseController(ILogger logger)
        {
            this.logger = logger;
        }

        public BaseController(
            ILogger logger,
            AccessClient accessClient)
        {
            this.logger = logger;
            _accessClient = accessClient;
        }

        protected async Task<bool> CheckPermission(string groupResourceKey, string resource, string action)
        {
            var actions = new[] { action };
            var isAccessAllow = await _accessClient.CheckPermission(groupResourceKey, resource, actions);
            return isAccessAllow;
        }

        protected async Task<bool> CheckPermission(string groupResourceKey, string action)
        {
            var actions = new[] { action };
            var resourceKey = ControllerContext.RouteData.Values["controller"].ToString();
            var isAccessAllow = await _accessClient.CheckPermission(groupResourceKey, resourceKey, actions);
            return isAccessAllow;
        }
    }
}
