﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class CustomerBankinfo
    {
        public int Id { get; set; }
        public string AccountId { get; set; }
        public string BankAccountName { get; set; }
        public string BankNumber { get; set; }
        public string BankName { get; set; }
        public string BankBranch { get; set; }
        public string BankProvince { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string Hash { get; set; }
        public string BankType { get; set; }
    }
}