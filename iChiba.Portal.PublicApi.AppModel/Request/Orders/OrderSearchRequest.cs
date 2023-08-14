using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderSearchRequest
    {
        public string Code { get; set; }
        public string PhoneOrEmail { get; set; }
    }
}
