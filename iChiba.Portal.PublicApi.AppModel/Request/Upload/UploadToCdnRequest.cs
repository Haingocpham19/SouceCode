using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class UploadToCdnRequest
    {
        public string FileNameUpload { get; set; }
        public byte[] Bytes { get; set; }
    }
}
