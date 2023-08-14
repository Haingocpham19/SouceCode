using System.Collections.Generic;
using iChiba.OM.Model;

namespace iChiba.OM.Service.Interface
{
    public interface IProductTypeService
    {
        IEnumerable<ProductType> Gets();
        //void Update(ProductType item);
    }
}