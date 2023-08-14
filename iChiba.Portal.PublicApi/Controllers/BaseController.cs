using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PublicApi.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Produces("application/json")]
    public class BaseController : ControllerBase
    {
        protected readonly ILogger logger;

        public BaseController(ILogger logger)
        {
            this.logger = logger;
        }
    }
}
