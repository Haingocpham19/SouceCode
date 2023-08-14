using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class SetPasswordRequest
    {
        public string NewPassword { get; set; }
        public string ConfirmPassword { get; set; }

        public string Accesstoken { get; set; }
        public string Url { get; set; }
    }
}
