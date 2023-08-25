using Infrastructure.DataAccess.EF.Contexts;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;
using System.Xml.Linq;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class ProductRepository : BaseRepository<Product, AHLDBContext>, IProductRepository
    {


        public async Task<List<Product>> GetAllProductAsync(params string[] includelist)
        {
            var list = await GetAllAsync(p => p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<List<Product>> GetByMaterialAsync(string material, params string[] includelist)
        {
            var list = await GetAllAsync(p => p.ProductMaterial.ToLower().Contains(material.ToLower()) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<List<Product>> GetByProductNameAsync(string name, params string[] include)
        {
            var list = await GetAllAsync(p => p.ProductName.ToLower().Contains(name.ToLower()) & p.IsActive.Equals(true), include);
            return list;
        }

        public async Task<List<Product>> GetByUnitPriceAsync(decimal min, decimal max, params string[] includelist)
        {
            var list = await GetAllAsync(p => p.UnitPrice < max  & p.UnitPrice > min & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Product> GetByIdAsync(int id, params string[] includelist)
        {
            var list = await GetAsync(p => p.ProductID.Equals(id) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<List<Product>> GetByCategoryIDAsync(int id, params string[] includelist)
        {
            var list = await GetAllAsync(p => p.CategoryID.Equals(id) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Product> AddProductAsync(Product prd, params string[] includelist)
        {
            var entity = await InsertAsync(prd,includelist);
            return entity;
        }

        public async Task DeleteByIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(p => p.ProductID != null ? p.ProductID.Equals(id) : p.ProductID.Equals(0), includelist);
            entity.IsActive = false;
            await UpdateAsync(entity);
        }

        public async Task UpdateProductAsync(Product prd, params string[] includelist)
        {
            await UpdateAsync(prd);
        }
    }
}
