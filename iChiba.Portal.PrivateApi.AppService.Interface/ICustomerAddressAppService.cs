using Core.AppModel.Response;
using iChiba.Portal.PrivateApi.AppModel.Requests;
using iChiba.Portal.PrivateApi.AppModel.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace iChiba.Portal.PrivateApi.AppService.Interface
{
    public interface ICustomerAddressAppService
    {
        Task<CustomerAddressListResponse> GetListAddress();
        Task<BaseResponse> Add(CustomerAddressAddRequest request);
        Task<BaseResponse> Update(CustomerAddressUpdateRequest request);
        Task<BaseResponse> Delete(CustomerAddressDeleteRequest request);
    }
}
