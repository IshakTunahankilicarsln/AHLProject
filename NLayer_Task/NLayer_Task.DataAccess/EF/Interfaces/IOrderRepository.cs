using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task<List<Order>> GetAllOrderAsync(params string[] includelist);
        Task<Order> GetByOrderIdAsync(int id, params string[] includelist); 
        Task<List<Order>> GetByCustomerIdAsync(int id, params string[] includelist);
        Task<Order> AddOrderAsync(Order order, params string[] includelist);
        Task DeleteByIdAsync(int id, params string[] includelist);
    }
}
