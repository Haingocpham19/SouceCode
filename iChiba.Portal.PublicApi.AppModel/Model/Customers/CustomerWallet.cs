using System;
using System.Collections.Generic;
using System.Text;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class CustomerWallet
    {
        public string AccountId { get; set; }
        public string WalletId { get; set; }
        public long Point { get; set; }
        public long Cash { get; set; }
        public long CashFreeze { get; set; } 
    }
}
