using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.ProductPicturePath;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface IProductPicturePathBS
    {
        Task<ApiResponse<List<ProductPicturePathGetDto>>> GetallPicturePathsAsync(params string[] includelist);
        Task<ApiResponse<List<ProductPicturePathGetDto>>> GetPicturePathsAsync(int productId,params string[] includelist);
        Task<ApiResponse<NoData>> DeletePicturePathsAsync(int productId, params string[] includelist);
        Task<ApiResponse<ProductPicturePath>> AddAsync(ProductPicturePathPostDto path);
        Task<ApiResponse<NoData>> UpdateAsync(ProductPicturePathPutDto path);
        Task<List<ProductPicturePathGetDto>> GetByproductIdPicturePathsAsync(int productId, params string[] includelist);


    }
}
