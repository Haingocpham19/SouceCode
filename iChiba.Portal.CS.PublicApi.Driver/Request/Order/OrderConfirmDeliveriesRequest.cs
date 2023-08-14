using System.Collections.Generic;

namespace iChiba.Portal.CS.PublicApi.Driver.Request
{
    public class OrderConfirmDeliveriesRequest
    {
        public IList<int> OrderIds { get; set; }
    }
}
