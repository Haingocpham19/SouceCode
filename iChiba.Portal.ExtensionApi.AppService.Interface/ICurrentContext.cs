using Microsoft.AspNetCore.Http;

namespace iChiba.Portal.ExtensionApi.AppService.Interface
{
    public interface ICurrentContext
    {
        string UserId { get; }
        string Ip { get; }
        bool IsAuthenticated { get; }
        HttpContext HttpContext { get; }
    }
}
