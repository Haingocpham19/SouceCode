using Microsoft.AspNetCore.Http;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface ICurrentContext
    {
        string UserId { get; }
        string Ip { get; }
        bool IsAuthenticated { get; }
        HttpContext HttpContext { get; }
    }
}