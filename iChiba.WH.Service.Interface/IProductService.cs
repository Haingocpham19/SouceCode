using iChiba.WH.Model;
using System.Collections.Generic;

namespace iChiba.WH.Service.Interface
{
    public interface IProductService
    {
        IEnumerable<Product> GetByPackageDetaiId(List<int> packageDetailIds);
    }
}
