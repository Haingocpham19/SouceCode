using AutoMapper;
using iChiba.OM.Model;
using iChiba.Portal.PrivateApi.AppModel.Models;
using iChiba.Portal.PrivateApi.AppModel.Requests;

namespace iChiba.Portal.PrivateApi.AppService.Implement.Adapter
{
    public static class CustomerAddressAdapter
    {
        public static CustomerAddressViewModel ToModel(this CustomerAddress model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CustomerAddress, CustomerAddressViewModel>(model);
        }

        public static CustomerAddress ToModel(this CustomerAddressAddRequest model)
        {
            if (model == null)
            {
                return null;
            }

            return Mapper.Map<CustomerAddressAddRequest, CustomerAddress>(model);
        }


        public static CustomerAddress ToUpdateModel(this CustomerAddress customerAddress, CustomerAddressUpdateRequest model)
        {
            if (customerAddress == null)
            {
                return null;
            }

            customerAddress.Name = model.Name;
            customerAddress.Phone = model.Phone;
            customerAddress.Address = model.Address;
            customerAddress.District = model.District;
            customerAddress.Note = model.Note;
            customerAddress.Active = model.Active;
            customerAddress.Province = model.Province;
            customerAddress.Country = model.Country;
            customerAddress.Ward = model.Ward;
            customerAddress.PostalCode = model.PostalCode;

            return customerAddress;
        }
    }
}
