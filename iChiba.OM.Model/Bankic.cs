﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Bankic
    {
        public int Id { get; set; }
        public string BankName { get; set; }
        public string BankFullName { get; set; }
        public string Picture { get; set; }
        public string Icon { get; set; }
        public string AccountNumber { get; set; }
        public string AccountName { get; set; }
        public string Branch { get; set; }
        public string Address { get; set; }
        public string Province { get; set; }
        public string Description { get; set; }
        public int? Status { get; set; }
        public string AccAccount { get; set; }
        public long? BeginBalance { get; set; }
        public DateTime? BeginBalanceDate { get; set; }
        public int? ForDeposit { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ServiceGroup { get; set; }
        public bool? AutoGetHistory { get; set; }
        public string BankType { get; set; }
        public string ProxyHost { get; set; }
        public int? ProxyPort { get; set; }
        public string ProxyUserName { get; set; }
        public string ProxyPassword { get; set; }
    }
}