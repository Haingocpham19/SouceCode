using System;
using System.Collections.Generic;
using iChiba.Portal.PublicApi.AppModel.Model;

namespace iChiba.Portal.PublicApi.AppModel.Model
{
    public class OrderDeliverybillList
    {
        public int Id { get; set; }
        public string BillCode { get; set; }
        public DateTime CreatedDate { get; set; }
        public int Status { get; set; }
        public string AccountId { get; set; }
        public DateTime? BillDate { get; set; }
        public decimal TotalAmount { get; set; }
        public IList<Order> Orders { get; set; }
    }

    public class OrderDeliverybillPayment
    {
        public decimal TotalAmountToBePaid { get; set; }
        public decimal TotalAmountPaid { get; set; }
    }
}
