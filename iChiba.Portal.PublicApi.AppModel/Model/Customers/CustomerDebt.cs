using System;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class CustomerDebt
    {
        public Guid Guid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public int? Point { get; set; }
        public int? Cash { get; set; }
        public long CashFreeze { get; set; }
        public int? CustomerLevel { get; set; }
        public bool? AllowBid { get; set; }
        public long? TotalCash { get; set; }
        public long? TotalCashFreeze { get; set; }
        public long? TotalAvailableBalances { get; set; }
        public long? TotalDeposit { get; set; }
        public long? TotalWithDawal { get; set; }
        public long? TotalPay { get; set; }
        public long? AmountNeedPayment { get; set; }
        public int? WaitHanding { get; set; }
        public int? WaitDeposit { get; set; }
        public int? WaitPurchase { get; set; }
        public int? Purchased { get; set; }
        public int? WaitPayment { get; set; }
        public int? IchibaReceived { get; set; }
        public int? WaitDelivery { get; set; }
        public int? Paid { get; set; }
        public int? Delivered { get; set; }
    }
}
