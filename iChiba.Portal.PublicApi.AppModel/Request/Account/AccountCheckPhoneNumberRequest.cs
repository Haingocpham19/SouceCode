using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class AccountCheckPhoneNumberRequest
    {
        public string PhoneNumber { get; set; }

        public string Accesstoken { get; set; }
        public string Url { get; set; }
    }
}
