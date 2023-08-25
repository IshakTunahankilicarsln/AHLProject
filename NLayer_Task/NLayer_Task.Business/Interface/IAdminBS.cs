using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Admin;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface IAdminBS
    {
        Task<ApiResponse<List<AdminGetDto>>> GetAllAdminAsync(params string[] includelist);
        Task<ApiResponse<List<AdminGetDto>>> GetByAdminNameAsync(string name, params string[] includelist);
        Task<ApiResponse<AdminGetDto>> GetByAdminIdAsync(int id, params string[] includelist);
        Task<ApiResponse<Admin>> AddAdminAsync(AdminPostDto admin, params string[] includelist);
        Task<ApiResponse<NoData>> DeleteAdminAsync(int id);
        Task<ApiResponse<Admin>> UpdateAdminAsync(AdminPutDto addres);
        Task<ApiResponse<AdminGetDto>> GetByAdminUNamePaswordAsync(string username, string password, params string[] includelist);


    }
}
