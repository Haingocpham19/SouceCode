using System.Threading.Tasks;
using Ichiba.WH.Api.Driver.Response;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface IWarehouseAppService
    {
        Task<WarehouseListResponse> GetAll();
        Task<WarehouseListResponse> GetByRoute(string route);
    }
}