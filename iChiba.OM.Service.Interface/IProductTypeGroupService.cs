using System.Collections.Generic;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IProductTypeGroupService
    {
        IEnumerable<ProductTypeGroup> Gets();
    }
}