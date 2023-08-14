using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderListByBillCodeRequest
    {
        public string BillCode { get; set; }
    }
}
