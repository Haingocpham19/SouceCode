﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class CustomerWallet
    {
        public string AccountId { get; set; }
        public string WalletId { get; set; }
        public long Point { get; set; }
        public long Cash { get; set; }
        public long CashFreeze { get; set; }
        public string Hash { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public byte[] Version { get; set; }
        public long? TotalDeposit { get; set; }
        public long? TotalWithDawal { get; set; }
        public long? TotalPay { get; set; }
        public int? WaitHanding { get; set; }
        public int? WaitDeposit { get; set; }
        public int? WaitPurchase { get; set; }
        public int? Purchased { get; set; }
        public int? WaitPayment { get; set; }
        public int? Paid { get; set; }
        public int? Delivered { get; set; }
        public long? BeginBalance { get; set; }
        public DateTime? BeginBalanceDate { get; set; }
        public int? IchibaReceived { get; set; }
        public int? WaitDelivery { get; set; }
        public bool? PaymentSummary { get; set; }
        public DateTime? PaymentSummaryDate { get; set; }
        public DateTime? PaymentSummaryRequest { get; set; }
        public long? TotalWaitDeposit { get; set; }
        public long? PaidWaitDeposit { get; set; }
        public long? TotalWaitPurchase { get; set; }
        public long? PaidWaitPurchase { get; set; }
        public long? TotalPurchased { get; set; }
        public long? PaidPurchased { get; set; }
        public long? TotalWaitPayment { get; set; }
        public long? PaidWaitPayment { get; set; }
        public long? TotalWaitDelivery { get; set; }
        public long? PaidWaitDelivery { get; set; }
        public long? TotalIchibaReceived { get; set; }
        public long? PaidIchibaReceived { get; set; }
        public long? TotalDelivered { get; set; }
        public long? PaidDelivered { get; set; }
        public DateTime? PaymentProcessDate { get; set; }
        public int? Ictreceived { get; set; }
        public int? IctwaitPayment { get; set; }
        public int? Ictpaid { get; set; }
        public int? IctwaitDelivery { get; set; }
        public int? Ictdelivered { get; set; }
        public long? TotalIctwaitPayment { get; set; }
        public long? PaidIctwaitPayment { get; set; }
        public long? TotalIctpaid { get; set; }
        public long? TotalIctwaitDelivery { get; set; }
        public long? PaidIctwaitDelivery { get; set; }
        public long? TotalIctdelivered { get; set; }
        public long? PaidIctdelivered { get; set; }
        public long? TotalOrderIct { get; set; }
        public long? PaidOrderIct { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}