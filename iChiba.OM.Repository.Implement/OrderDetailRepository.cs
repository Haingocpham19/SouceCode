using System;
using System.Collections.Generic;
using System.Linq;
using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace iChiba.OM.Repository.Implement
{
    public class OrderDetailRepository : BaseRepository<CustomerDBContext, Orderdetail>, IOrderDetailRepository
    {
        public OrderDetailRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }

        public IList<Orderdetail> GetReSyncPurchaseReport()
        {

            return dbContext.Orderdetail.FromSqlRaw($"EXEC Store_GetDataReSyncPurchaseReport").ToList();
        }

        public IList<Orderdetail> GetOrderNotInPurchaseReport()
        {
            return dbContext.Orderdetail.FromSqlRaw($"EXEC Store_GetOrderNotInPurchaseReport").ToList();
        }

        public Customer GetCustomerByAccountId(string accountId)
        {
            return dbContext.Customer.FirstOrDefault(x => x.AccountId == accountId);
        }

        public void DetachedRange(IList<Orderdetail> orderDetails)
        {
            foreach (var orderDetail in orderDetails)
            {
                dbContext.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
        public void Detached(Orderdetail orderDetail)
        {
            dbContext.Entry(orderDetail).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }
    }
}