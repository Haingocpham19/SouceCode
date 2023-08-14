using Core.AppModel.Response;
using iChiba.Portal.PublicApi.AppModel.Model;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PublicApi.AppModel.Response
{
    public class OrderGetByQuoteCodeResponse : BaseEntityResponse<IList<OrderGetByQuoteCode>>
    {

    }


    public class OrderGetByQuoteCode
    {
        public string BillCode { get; set; }
        public DateTime? BillDate { get; set; }
        public long? TotalAmount { get; set; }
        public long? TotalAmountToBePaid { get; set; }
        public int BillStatus { get; set; } // trạng thái mã phiếu
        public string Review { get; set; }
        public IEnumerable<Order> Orders { get; set; }
    }
}
