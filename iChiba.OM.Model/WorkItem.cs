﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class WorkItem
    {
        public int Id { get; set; }
        public string TriggerName { get; set; }
        public int EntityId { get; set; }
        public string WorkflowType { get; set; }
        public int Retries { get; set; }
        public string Error { get; set; }
        public DateTime DueDate { get; set; }
    }
}