using System.Collections.Generic;
using System.Linq;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;

namespace iChiba.OM.Service.Implement
{
    public class ProductTypeService : IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepository;

        public ProductTypeService(IProductTypeRepository productTypeRepository)
        {
            _productTypeRepository = productTypeRepository;
        }

        public IEnumerable<ProductType> Gets()
        {
            return _productTypeRepository.Find();
        }
    }
}
