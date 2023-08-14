using System.Collections.Generic;
using System.Linq;
using Core.Common;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class OrderPackageProductService : IOrderPackageProductService
    {
        private readonly IOrderPackageProductRepository orderPackageProductRepository;

        public OrderPackageProductService(IOrderPackageProductRepository orderPackageProductRepository)
        {
            this.orderPackageProductRepository = orderPackageProductRepository;
        }

        public OrderPackageProduct Add(OrderPackageProduct model)
        {
            return orderPackageProductRepository.Add(model);
        }

        public void Delete(OrderPackageProduct model)
        {
            orderPackageProductRepository.Delete(model);
        }
        public void DetachedRange(IList<OrderPackageProduct> orderPackageProduct)
        {
            orderPackageProductRepository.DetachedRange(orderPackageProduct);
        }
        public void DeleteAllByPackageId(int orderPackageId)
        {
            var data = orderPackageProductRepository.Find(new OrderPackageProductGetBy(orderPackageId, null)).ToList();
            orderPackageProductRepository.DeleteAllByPackageId(data);
        }

        public OrderPackageProduct GetById(int id)
        {
            return orderPackageProductRepository.FindById(id);
        }

        public IList<OrderPackageProduct> GetByIds(IList<int> ids)
        {
            return orderPackageProductRepository.Find(new OrderPackageProductGetBy(ids)).ToList();
        }

        public IList<OrderPackageProduct> Gets(int orderPackageId, string searchKeyword,
            Sorts sorts,
            Paging paging)
        {
            return orderPackageProductRepository.Find(new OrderPackageProductGetBy(orderPackageId, searchKeyword), sorts, paging).ToList();
        }
        public IList<OrderPackageProduct> Gets(int orderPackageId)
        {
            return orderPackageProductRepository.Find(new OrderPackageProductGetBy(orderPackageId, null)).ToList();
        }

        public IList<OrderPackageProduct> Gets(List<int> orderPackageIds)
        {
            return orderPackageProductRepository.Find(new OrderPackageProductGetBy(orderPackageIds)).ToList();
        }

        public void Update(OrderPackageProduct model)
        {
            orderPackageProductRepository.Update(model);
        }
    }
}
