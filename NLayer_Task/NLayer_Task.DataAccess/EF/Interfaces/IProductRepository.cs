using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IProductRepository : IBaseRepository<Product>
    {
        Task<List<Product>> GetAllProductAsync(params string[] includelist);
        Task<List<Product>> GetByProductNameAsync(string name, params string[] includelist);
        Task<List<Product>> GetByMaterialAsync(string material, params string[] includelist);
        Task<List<Product>> GetByUnitPriceAsync(decimal min, decimal max, params string[] includelist);
        Task<Product> GetByIdAsync(int id, params string[] includelist);
        Task DeleteByIdAsync(int id, params string[] includelist);
        Task<Product> AddProductAsync(Product prd, params string[] includelist);
        Task UpdateProductAsync(Product prd, params string[] includelist);
        Task<List<Product>> GetByCategoryIDAsync(int id, params string[] includelist);
    }
}
