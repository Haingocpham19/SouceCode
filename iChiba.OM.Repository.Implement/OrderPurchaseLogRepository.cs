﻿using Core.Repository.Abstract;
using iChiba.OM.DbContext;
using iChiba.OM.Model;
using iChiba.OM.Repository.Interface;

namespace iChiba.OM.Repository.Implement
{
    public class OrderPurchaseLogRepository : BaseRepository<CustomerDBContext, OrderPurchaseLog>, IOrderPurchaseLogRepository
    {
        public OrderPurchaseLogRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}
