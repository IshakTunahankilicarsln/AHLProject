using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface ICategoryRepository : IBaseRepository<Category>
    {
        Task<List<Category>> GetAllCAsync(params string[] includelist);
        Task<List<Category>> GetByCNameAsync(string name, params string[] includelist);
        Task<Category> GetByIdAsync(int id, params string[] includelist);
        Task<Category> AddAsync(Category category, params string[] includelist);
        Task Updateasync(Category category);
        Task DeleteAsync(Category category);

    }
}
