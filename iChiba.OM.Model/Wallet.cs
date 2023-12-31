﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Wallet
    {
        public Wallet()
        {
            CustomerWallet = new HashSet<CustomerWallet>();
            Deposits = new HashSet<Deposits>();
            Freeze = new HashSet<Freeze>();
            Payment = new HashSet<Payment>();
            WalletTrans = new HashSet<WalletTrans>();
            Withdrawal = new HashSet<Withdrawal>();
        }

        public string Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public virtual ICollection<CustomerWallet> CustomerWallet { get; set; }
        public virtual ICollection<Deposits> Deposits { get; set; }
        public virtual ICollection<Freeze> Freeze { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<WalletTrans> WalletTrans { get; set; }
        public virtual ICollection<Withdrawal> Withdrawal { get; set; }
    }
}