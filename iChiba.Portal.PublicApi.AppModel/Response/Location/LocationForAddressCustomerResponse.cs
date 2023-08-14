using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Response
{
    public class LocationForAddressCustomerResponse : BaseResponse
    {
        public List<Location> ProvinceList { get; set; }
        public List<Location> DisttrictList { get; set; }
        public List<Location> WardList { get; set; }
    }
}
