using Infrastructure.DataAccess.EF.Contexts;
using Microsoft.EntityFrameworkCore;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class OrderRepository : BaseRepository<Order, AHLDBContext>, IOrderRepository
    {
        public async Task<Order> AddOrderAsync(Order order, params string[] includelist)
        {
            var entity = await InsertAsync(order);
            return entity;
        }


        public async Task<List<Order>> GetAllOrderAsync(params string[] includelist)
        {
            using (var context = new AHLDBContext())
            {
                var ordersWithCustomersAndAddresses = await context.Orders
                    .Include(o => o.Customer) // Müşteri bilgilerini çeker
                        .ThenInclude(c => c.Addres) // Müşteriye ait adresi çeker
                    .ToListAsync();

                return ordersWithCustomersAndAddresses;
            }
        }

        //public async Task<List<Order>> GetAllOrderAsync(params string[] includelist)
        //{
        //    using (var context = new AHLDBContext())
        //    {
        //        var ordersWithCustomersAndAddresses = context.Orders
        //            .Include(o => o.Customer) // Müşteri bilgilerini çeker
        //                .ThenInclude(c => c.Addres) // Müşteriye ait adresi çeker
        //            .ToList();

        //    } 
        //        var list = await GetAllAsync(includeList : includelist);
        //        return list;
        //}

        public async Task<List<Order>> GetByCustomerIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAllAsync(o => o.CustomerID == id && o.IsActive.Equals(true));
            return entity;
        }

        public async Task<Order> GetByOrderIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(o => o.OrderID == id && o.IsActive.Equals(true));
            return entity;
        }

        public async Task DeleteByIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(p => p.OrderID != null ? p.OrderID.Equals(id) : p.OrderID.Equals(0), includelist);
            entity.IsActive = false;
            await UpdateAsync(entity);
        }
    }
}
