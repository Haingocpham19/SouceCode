using System;
using System.Collections.Generic;
using System.Linq;
using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;
using iChiba.Portal.Common;
using Microsoft.EntityFrameworkCore;

namespace iChiba.OM.Repository.Implement
{
    public class OrderRepository : BaseRepository<CustomerDBContext, Order>, IOrderRepository
    {
        public OrderRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }

        public IList<Order> GetReSyncPurchaseReport()
        {

            return dbContext.Order.FromSqlRaw($"EXEC Store_GetDataReSyncPurchaseReport").ToList();
        }

        public IList<Order> GetOrderNotInPurchaseReport()
        {
            return dbContext.Order.FromSqlRaw($"EXEC Store_GetOrderNotInPurchaseReport").ToList();
        }

        public Customer GetCustomerByAccountId(string accountId)
        {
            return dbContext.Customer.FirstOrDefault(x => x.AccountId == accountId);
        }

        public void UpdateBulky()
        {
            const string command = "UPDATE [ORDER] SET Bulky = 0 WHERE ((Hight * Length * Width) / 6) < WeightOrigin and OrderType <> 'TRANSPORT' AND Bulky = 1 " +
                                   "UPDATE [ORDER] SET Bulky = 1 WHERE ((Hight * Length * Width) / 6) > WeightOrigin and OrderType <> 'TRANSPORT' AND (Bulky = 0 OR Bulky IS NULL)";

            dbContext.Database.ExecuteSqlRaw(command);
        }

        public void DetachedRange(IList<Order> orders)
        {
            foreach (var order in orders)
            {
                dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
            }
        }
        public void Detached(Order order)
        {
            dbContext.Entry(order).State = Microsoft.EntityFrameworkCore.EntityState.Detached;
        }

        public IList<string> CollectOrderType()
        {
            return dbContext.Order
                .Where(x => !string.IsNullOrEmpty(x.OrderType)
                            && !string.IsNullOrWhiteSpace(x.OrderType)
                            && !x.OrderType.Equals("TRANSPORT"))
                .Select(x => x.OrderType)
                .Distinct()
                .ToList();
        }
        public HashSet<string> ExistsListTracking(IEnumerable<string> lstTracking)
        {
            var lstQueryTracking = new HashSet<string>();
            foreach (var x in lstTracking)
            {
                if (!string.IsNullOrWhiteSpace(x))
                {
                    var tracking = x.Trim();
                    lstQueryTracking.Add(tracking);
                }
            }

            return dbContext.Order.AsNoTracking()
                .Where(w => (w.Tracking != null && w.Tracking != string.Empty)
                    && w.TrackingStatus != (int)OrderTrackingStatus.Canceled
                    && lstQueryTracking.Contains(w.Tracking))
                .Select(s => s.Tracking)
                .ToHashSet();
        }
    }
}