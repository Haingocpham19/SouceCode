﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderCom
    {
        public OrderCom()
        {
            OrderComMoney = new HashSet<OrderComMoney>();
        }

        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string EmployeeId { get; set; }
        public decimal? Com { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string ComType { get; set; }
        public string ComSource { get; set; }
        public DateTime? ComDate { get; set; }

        public virtual ICollection<OrderComMoney> OrderComMoney { get; set; }
    }
}