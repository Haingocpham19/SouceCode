using iChiba.Portal.ExtensionApi.AppService.Interface;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;

namespace iChiba.Portal.ExtensionApi.AppService.Implement.IS4
{
    public class CurrentContext : ICurrentContext
    {
        private const string AU_ID = "sub";

        private readonly IHttpContextAccessor httpContextAccessor;

        private string userId;
        public string UserId
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(userId))
                {
                    return userId;
                }

                userId = httpContextAccessor.HttpContext.User.FindFirst(AU_ID).Value;
                return userId;
            }
        }

        private string ip;
        public string Ip
        {
            get
            {
                if (!string.IsNullOrWhiteSpace(ip))
                {
                    return ip;
                }

                ip = GetCurrentIpAddress();

                return ip;
            }
        }

        public CurrentContext(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;
        }

        private bool IsRequestAvailable()
        {
            return httpContextAccessor?.HttpContext?.Request != null;
        }

        private string GetCurrentIpAddress()
        {
            if (!IsRequestAvailable())
            {
                return string.Empty;
            }

            var result = string.Empty;

            try
            {
                //first try to get IP address from the forwarded header
                if (httpContextAccessor.HttpContext.Request.Headers != null)
                {
                    //the X-Forwarded-For (XFF) HTTP header field is a de facto standard for identifying the originating IP address of a client
                    //connecting to a web server through an HTTP proxy or load balancer
                    const string FORWARDED_HTTP_HEADER_KEY = "X-FORWARDED-FOR";
                    var forwardedHeader = httpContextAccessor.HttpContext.Request.Headers[FORWARDED_HTTP_HEADER_KEY];

                    if (!string.IsNullOrWhiteSpace(forwardedHeader))
                    {
                        result = forwardedHeader.FirstOrDefault();
                    }
                }
                //if this header not exists try get connection remote IP address
                if (string.IsNullOrEmpty(result)
                    && httpContextAccessor.HttpContext.Connection.RemoteIpAddress != null)
                {
                    result = httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
                }
            }
            catch
            {
                return string.Empty;
            }

            if (result != null
                && result.Equals("::1", StringComparison.InvariantCultureIgnoreCase))
            {
                result = "127.0.0.1";
            }

            if (!string.IsNullOrEmpty(result))
            {
                result = result.Split(':').FirstOrDefault();
            }

            return result;
        }

        public bool IsAuthenticated
        {
            get
            {
                return httpContextAccessor.HttpContext.User.Identity.IsAuthenticated;
            }
        }

        public HttpContext HttpContext => httpContextAccessor.HttpContext;
    }
}
