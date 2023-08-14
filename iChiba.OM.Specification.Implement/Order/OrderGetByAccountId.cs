using System.Collections.Generic;
using Core.Specification.Abstract;

namespace iChiba.OM.Specification.Implement
{
    public class OrderGetByAccountId : SpecificationBase<Model.Order>
    {
        public OrderGetByAccountId(string accountId)
        : base(m => !string.IsNullOrEmpty(m.AccountId) && m.AccountId.Equals(accountId))
        {

        }
    }
}
