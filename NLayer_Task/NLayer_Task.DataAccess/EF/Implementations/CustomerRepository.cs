using Infrastructure.DataAccess.EF.Contexts;
using Infrastructure.Model;
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
    public class CustomerRepository : BaseRepository<Customer, AHLDBContext>, ICustomerRepository
    {

        public async Task<List<Customer>> GetAllCustomerAsync(params string[] includelist)
        {
            var list = await GetAllAsync(c => c.IsActive.Equals(true), includeList: includelist);
            return list;
        }

        public async Task<Customer> GetByIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(c => c.CustomerID.Equals(id) & c.IsActive.Equals(true), includelist);
            return entity;
        }

        public async Task<List<Customer>> GetByNameAsync(string name, params string[] includelist)
        {
            var list = await GetAllAsync(c => c.FirstName.Equals(name) & c.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Customer> AddCustomer(Customer customer, params string[] includelist)
        {
            var entity = await InsertAsync(customer, includelist);
            return entity;
        }

        public async Task UpdateCustomer(Customer customer, params string[] includelist)
        {
            await UpdateAsync(customer);
        }

        public async Task DeleteCustomer(Customer customer, params string[] includelist)
        {
            if (customer.IsActive.Equals(true))
            {
                customer.IsActive = false;
                await UpdateAsync(customer);
            }
            throw new NotImplementedException("implemnte edilmedi");
        }

    }
}
