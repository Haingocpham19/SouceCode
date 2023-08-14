using System;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement.CodImport
{
    public class CodImportUpdateDataRequest : SpecificationBase<Model.CodImport>
    {
        public CodImportUpdateDataRequest()
           : base(m => ((string.IsNullOrEmpty(m.CustomerCode) || string.IsNullOrWhiteSpace(m.CustomerCode) || m.CustomerCode.Equals("undefined"))
                       || (m.ExchangeRate == null || m.ExchangeRate <= 0)
                       || (string.IsNullOrEmpty(m.Mawb) || string.IsNullOrWhiteSpace(m.Mawb) || m.Mawb.Equals("undefined"))
                       || (string.IsNullOrEmpty(m.Warehouse) || string.IsNullOrWhiteSpace(m.Warehouse) || m.Warehouse.Equals("undefined"))
                       || (string.IsNullOrEmpty(m.OrderCode) || string.IsNullOrWhiteSpace(m.OrderCode) || m.OrderCode.Equals("undefined")))
                       && m.PayCodeDate >= new DateTime(2020, 11, 16))
        {
        }
    }
}