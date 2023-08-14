using Core.Specification.Abstract;
using iChiba.WH.Model;
using iChiba.WH.Repository.Interface;
using iChiba.WH.Service.Interface;
using System.Collections.Generic;

namespace iChiba.WH.Service.Implement
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<Product> GetByPackageDetaiId(List<int> packageDetailIds)
        {
            var spec = new Specification<Product>(m => packageDetailIds.Contains(m.PackageDetailId));
            return _productRepository.Find(spec);
        }
    }
}
