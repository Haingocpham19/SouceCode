using System.Collections.Generic;

namespace iChiba.Portal.CS.PublicApi.Driver.Request
{
    public class ProofPaymentGetByOrderIdsRequest
    {
        public IList<int> OrderIds { get; set; }
    }
}
