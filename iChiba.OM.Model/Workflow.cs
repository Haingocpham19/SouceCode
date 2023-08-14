﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

namespace iChiba.OM.Model
{
    public partial class Workflow
    {
        public Workflow()
        {
            WorkflowHistory = new HashSet<WorkflowHistory>();
            WorkflowVariable = new HashSet<WorkflowVariable>();
        }

        public int Id { get; set; }
        public string Type { get; set; }
        public string State { get; set; }
        public int CorrelationId { get; set; }
        public string Assignee { get; set; }
        public DateTime Started { get; set; }
        public DateTime? Completed { get; set; }

        public virtual ICollection<WorkflowHistory> WorkflowHistory { get; set; }
        public virtual ICollection<WorkflowVariable> WorkflowVariable { get; set; }
    }
}