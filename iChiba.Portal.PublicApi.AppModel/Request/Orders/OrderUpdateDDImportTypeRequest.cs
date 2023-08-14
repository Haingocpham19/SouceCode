using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderUpdateDDImportTypeRequest
    {
        public int OrderId { get; set; }
        public string DdImportType { get; set; }
    }
}
