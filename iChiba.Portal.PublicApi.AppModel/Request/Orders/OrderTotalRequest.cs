using Core.AppModel.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderTotalRequest
    {
        public IList<int> Statuses { get; set; }
        public string PageViewOrder { get; set; }
    }
}
