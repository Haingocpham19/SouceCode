using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class AccountVerifyOTP
    {
        public string id { get; set; }
        public string access_token { get; set; }
        public int token_refresh_interval_sec { get; set; }
    }
}
