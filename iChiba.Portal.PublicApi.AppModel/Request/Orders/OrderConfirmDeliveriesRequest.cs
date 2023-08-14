using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class OrderConfirmDeliveriesRequest
    {
        public IList<int> OrderIds { get; set; }
    }
}
