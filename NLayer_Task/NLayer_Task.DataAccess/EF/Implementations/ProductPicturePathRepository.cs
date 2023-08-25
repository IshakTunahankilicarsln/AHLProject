using Infrastructure.DataAccess.EF.Contexts;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class ProductPicturePathRepository : BaseRepository<ProductPicturePath, AHLDBContext>, IProductPicturePathRepository
    {
        public async Task<ProductPicturePath> AddPAsync(ProductPicturePath path)
        {
            var repo = await InsertAsync(path);
            return repo;
        }

        public async Task<List<ProductPicturePath>> GetAllPicturePathAsync(params string[] includelist)
        {
            return await GetAllAsync(p => p.IsActive.Equals(true), includelist);

        }
    }
}
