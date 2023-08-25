using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.User;

namespace NLayer_Task.Business.Interface
{
    public interface IUserBS
    {
        Task<ApiResponse<List<UserGetDto>>> GetAllUserAsync(params string[] includelist);
        Task<ApiResponse<UserGetDto>> GetByIdAsync(int id, params string[] includelist);

    }
}
