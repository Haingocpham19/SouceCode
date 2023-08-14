﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Deposits
    {
        public Deposits()
        {
            DepositMessage = new HashSet<DepositMessage>();
        }

        public int Id { get; set; }
        /// <summary>
        /// Số tiền
        /// </summary>
        public long Amount { get; set; }
        /// <summary>
        /// Đang xử lý, đã xử lý, huỷ
        /// </summary>
        public int DepositStatus { get; set; }
        public string AccountId { get; set; }
        public DateTime? BankDate { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Ftcode { get; set; }
        public string BankName { get; set; }
        public string BankDescription { get; set; }
        public string BankNumber { get; set; }
        public string BankContent { get; set; }
        public string PayImage { get; set; }
        public int PayStatus { get; set; }
        public string Hash { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime? ProcessDate { get; set; }
        public int ConfirmStatus { get; set; }
        /// <summary>
        /// BANK | ICHIBA
        /// </summary>
        public string DepositType { get; set; }
        public string WalletId { get; set; }
        public byte[] Version { get; set; }
        public string State { get; set; }
        public string Type { get; set; }
        public string Note { get; set; }
        public string Ref { get; set; }
        public string CustomerBankNumber { get; set; }
        public string CustomerBankName { get; set; }
        public string CustomerBankOwner { get; set; }
        public DateTime? CustomerTranDate { get; set; }
        public string CustomerTranCode { get; set; }
        public string ConfirmBy { get; set; }
        public DateTime? ConfirmDate { get; set; }

        public virtual Wallet Wallet { get; set; }
        public virtual ICollection<DepositMessage> DepositMessage { get; set; }
    }
}