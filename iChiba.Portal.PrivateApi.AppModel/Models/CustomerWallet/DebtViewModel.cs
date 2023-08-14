namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class DebtViewModel
    {
        public long Cash { get; set; }
        public long CashFreeze { get; set; }
        public long TotalPay { get; set; }
        public long TotalDeposits { get; set; }
        public long TotalWaitPayment { get; set; }
        public long TotalWithdrawal { get; set; }
    }
}
