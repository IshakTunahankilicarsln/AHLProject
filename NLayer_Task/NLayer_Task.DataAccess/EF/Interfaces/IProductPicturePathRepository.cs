using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IProductPicturePathRepository : IBaseRepository<ProductPicturePath>
    {
        Task<List<ProductPicturePath>> GetAllPicturePathAsync(params string[] includelist);
        Task<ProductPicturePath> AddPAsync(ProductPicturePath product);
    }
}
