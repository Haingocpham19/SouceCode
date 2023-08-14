using System.Collections.Generic;
using System.Linq;
using Core.Common;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.OM.Service.Interface;
using iChiba.OM.Specification.Implement;

namespace iChiba.OM.Service.Implement
{
    public class OrderPackageService : IOrderPackageService
    {
        private readonly IOrderPackageRepository orderPackageRepository;

        public OrderPackageService(IOrderPackageRepository orderPackageRepository)
        {
            this.orderPackageRepository = orderPackageRepository;
        }

        public OrderPackage Add(OrderPackage model)
        {
            return orderPackageRepository.Add(model);
        }

        public void Delete(OrderPackage model)
        {
            orderPackageRepository.Delete(model);
        }

        public OrderPackage GetById(int id)
        {
            return orderPackageRepository.FindById(id);
        }

        public IList<OrderPackage> Gets(int? orderId, string searchKeyword,
            Sorts sorts,
            Paging paging)
        {
            return orderPackageRepository.Find(new OrderPackageGetBy(orderId, searchKeyword), sorts, paging).ToList();
        }
        public IList<OrderPackage> Gets(int? orderId)
        {
            return orderPackageRepository.Find(new OrderPackageGetBy(orderId, null)).ToList();
        }

        public IList<OrderPackage> Gets(List<int> orderIds)
        {
            return orderPackageRepository.Find(new OrderPackageGetBy(orderIds)).ToList();
        }

        public OrderPackage GetDebitNote(int orderId)
        {
            return orderPackageRepository.FindSingleBySpec(new OrderPackageGetBy(orderId));
        }

        public IList<OrderPackage> GetDebitNotes(int orderId)
        {
            return orderPackageRepository.Find(new OrderPackageGetBy(orderId)).ToList();
        }

        public void Update(OrderPackage model)
        {
            orderPackageRepository.Update(model);
        }

        public void DetachedRange(IList<OrderPackage> orderPackages)
        {
            orderPackageRepository.DetachedRange(orderPackages);
        }
    }
}
