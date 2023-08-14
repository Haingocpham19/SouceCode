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
    public class OrderServiceRepository : BaseRepository<CustomerDBContext, OrderService>, IOrderServiceRepository
    {
        public OrderServiceRepository(CustomerDBContext dbContext) : base(dbContext)
        {
        }
    }
}