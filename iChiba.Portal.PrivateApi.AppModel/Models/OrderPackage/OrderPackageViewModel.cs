using iChiba.Portal.PrivateApi.AppModel.Requests;
using System;
using System.Collections.Generic;

namespace iChiba.Portal.PrivateApi.AppModel.Models
{
    public class OrderPackageViewModel
    {
        public string Code { get; set; }
        public string CodeCustom { get; set; }
        public string Name { get; set; }
        public int NoOfPiece { get; set; }
        public decimal Length { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal Weight { get; set; }
        public string CreatedBy { get; set; }
        public string ModifiedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public IList<OrderPackageProductAddRequest> OrderPackageProducts { get; set; }
    }
}
