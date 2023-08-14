namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class CustomerWalletViewModel
    {
        public string AccountId { get; set; }
        public string WalletId { get; set; }
        public long Point { get; set; }
        public long Cash { get; set; }
        public long CashFreeze { get; set; }
        public long? TotalDeposit { get; set; }
        public long? TotalWithDawal { get; set; }
        public long? TotalPay { get; set; }
    }
}
