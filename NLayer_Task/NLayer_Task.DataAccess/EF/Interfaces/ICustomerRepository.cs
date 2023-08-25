using Infrastructure.DataAccess.Interface;
using Infrastructure.Model;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface ICustomerRepository : IBaseRepository<Customer>
    {
        Task<List<Customer>> GetAllCustomerAsync(params string[] includelist);
        Task<List<Customer>> GetByNameAsync(string name , params string[] includelist);
        Task<Customer> GetByIdAsync(int id , params string[] includelist);
        Task<Customer> AddCustomer(Customer customer, params string[] includelist);
        Task UpdateCustomer(Customer customer, params string[] includelist);
        Task DeleteCustomer(Customer customer, params string[] includelist);
    }
}
