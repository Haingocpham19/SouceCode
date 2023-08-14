using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderRatingRequest
    {
        public int OrderId { get; set; }
        public int RateCode { get; set; }
    }

    public class OrderRatingByBillCodeRequest
    {
        public string BillCode { get; set; }
        public int RateCode { get; set; }
    }
}