﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class OrderPayimage
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PayImage { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual Order Order { get; set; }
    }
}