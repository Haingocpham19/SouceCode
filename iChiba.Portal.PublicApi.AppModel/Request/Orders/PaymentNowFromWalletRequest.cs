using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Request
{
    public class PaymentNowFromWalletRequest
    {
        public IList<int> OrderIds { get; set; }
    }
}