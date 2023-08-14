﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class WalletTrans
    {
        public int Id { get; set; }
        /// <summary>
        /// Nạp tiền, rút tiền, thanh toán (deposit,withdrawal,pay,freeze)
        /// </summary>
        public string Type { get; set; }
        /// <summary>
        /// Số tiền
        /// </summary>
        public long Amount { get; set; }
        public string AccountId { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Description { get; set; }
        public string Hash { get; set; }
        /// <summary>
        /// Tên ví
        /// </summary>
        public string WalletId { get; set; }
        public byte[] Version { get; set; }
        /// <summary>
        /// Mã tham chiếu
        /// </summary>
        public int RefId { get; set; }
        public long Cash { get; set; }

        public virtual Wallet Wallet { get; set; }
    }
}