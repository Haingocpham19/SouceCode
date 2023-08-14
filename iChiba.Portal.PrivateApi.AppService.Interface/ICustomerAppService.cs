using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface ICustomerAppService
    {
        Task<CustomerInfoHomePageResponse> GetCustomerInfoHomePage();
    }
}
