using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;

namespace iChiba.Portal.PrivateApi.Middleware
{
    public class ClientIpFilters : ActionFilterAttribute
    {
        private readonly ILogger _logger;

        public ClientIpFilters(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger("ClassConsoleLogActionOneFilter");
        }

        public override void OnActionExecuting(ActionExecutingContext context)
        {
            _logger.LogInformation($"Remote IpAddress: {context.HttpContext.Connection.RemoteIpAddress}");

            // TODO implement some business logic for this...

            base.OnActionExecuting(context);
        }
    }
}