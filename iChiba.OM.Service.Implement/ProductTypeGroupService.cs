using System.Collections.Generic;
using System.Linq;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;

namespace iChiba.OM.Service.Implement
{
    public class ProductTypeGroupService : IProductTypeGroupService
    {
        private readonly IProductTypeGroupRepository _productTypeGroupRepository;

        public ProductTypeGroupService(IProductTypeGroupRepository productTypeGroupRepository)
        {
            _productTypeGroupRepository = productTypeGroupRepository;
        }

        public IEnumerable<ProductTypeGroup> Gets()
        {
            return _productTypeGroupRepository.Find();
        }
    }
}
