using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class CustomerResponse : BaseEntityResponse<CustomerViewModel>
    {
        public CustomerResponse()
        {
            Data = new CustomerViewModel();
        }
    }

    public class CustomerInfoHomePageResponse : BaseEntityResponse<CustomerInfoHomePageModel>
    {
        public CustomerInfoHomePageResponse()
        {
            Data = new CustomerInfoHomePageModel();
        }
    }
}
