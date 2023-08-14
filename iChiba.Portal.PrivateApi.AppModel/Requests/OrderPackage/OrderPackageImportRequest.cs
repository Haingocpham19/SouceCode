using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Requests
{
    public class OrderPackageImportRequest
    {
        public byte[] FileData { get; set; }
        public string FileName { get; set; }
        public DateTime? CreatdDate { get; set; }
    }
}
