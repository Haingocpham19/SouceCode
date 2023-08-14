using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Models;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Responses
{
    public class CustomerAddressListResponse : BaseEntityResponse<IList<CustomerAddressViewModel>>
    {
        public CustomerAddressListResponse()
        {
            Data = new List<CustomerAddressViewModel>();
        }
    }
}
