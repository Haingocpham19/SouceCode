using Core.Specification.Abstract;
using iChiba.OM.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iChiba.OM.Specification.Implement
{
    public class SupplierGetByAccountIdIsNotNull : SpecificationBase<Supplier>
    {
        public SupplierGetByAccountIdIsNotNull() : base(m => !string.IsNullOrWhiteSpace(m.AccountId))
        {

        }
    }
}

