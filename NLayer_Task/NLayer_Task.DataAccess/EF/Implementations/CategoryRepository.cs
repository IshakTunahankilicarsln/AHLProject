using Infrastructure.DataAccess.EF.Contexts;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class CategoryRepository : BaseRepository<Category, AHLDBContext>, ICategoryRepository
    {      
        public async Task<List<Category>> GetAllCAsync(params string[] includelist)
        {
            var list =await GetAllAsync(p => p.IsActive.Equals(true),includeList : includelist);
            return list;
        }

        public async Task<List<Category>> GetByCNameAsync(string name, params string[] includelist)
        {
            var list =await GetAllAsync(c => c.CategoryName.Contains(name) & c.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Category> GetByIdAsync(int id, params string[] includelist)
        {
            var list =await GetAsync(c => c.CategoryId.Equals(id) & c.IsActive.Equals(true), includelist);
            return list;
        }
        
        public async Task<Category> AddAsync(Category category, params string[] includelist)
        {
            var entity =await InsertAsync(category, includelist);
            return entity;
        }

        public async Task Updateasync(Category category)
        {
            await UpdateAsync(category);
        }

        public async Task DeleteAsync(Category category)
        {
            if (category.IsActive.Equals(true))
            {
                category.IsActive = false;
                await UpdateAsync(category);
            }            
        }
    }
}
