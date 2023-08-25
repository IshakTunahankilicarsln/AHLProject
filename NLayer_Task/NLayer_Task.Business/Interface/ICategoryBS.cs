using Infrastructure.Model;//ITK
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface ICategoryBS
    {
        Task<ApiResponse<List<CategoryGetDto>>> GetAllAsync(params string[] includelist);
        Task<ApiResponse<List<CategoryGetDto>>> GetByCNameAsync(string name, params string[] includelist);
        Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int id, params string[] includelist);
        Task<ApiResponse<Category>> AddCategoryAsync(CategoryPostDto category, params string[] includelist);
        Task<ApiResponse<NoData>> UpdateCategoryAsync(CategoryPutDto category);
        Task<ApiResponse<NoData>> DeleteCategoryAsync(int id);
    }


}//ITK***
