using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class MoneyTransactionViewModel
    {
        public string Code { get; set; }
        public long Amount { get; set; }
        public int Status { get; set; }
        public string TransactionType { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreateDateStr { get; set; }
        public string Description { get; set; }
        public DateTime? ProcessedDate { get; set; }
        public string FTCode { get; set; }
    }

    public class WalletTransactionViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string CreatedDateDisplay { get; set; }
        public string DayOfWeek { get; set; }
        public List<MoneyTransactionViewModel> Transactions { get; set; }
    }
}
