using System.Collections.Generic;

namespace iChiba.Portal.CS.PublicApi.Driver.Request
{
    public class ProofPaymentAddRequest
    {
        public IList<int> OrderIds { get; set; }
        public string Image { get; set; }
    }
}
