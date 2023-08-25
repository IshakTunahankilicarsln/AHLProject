using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Order;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface IOrderBS
    {
        Task<ApiResponse<List<OrderGetDto>>> GetAllOrderAsync(params string[] includelist);
        Task<ApiResponse<OrderGetDto>> GetByOrderIdAsync(int id, params string[] includelist);
        Task<ApiResponse<List<OrderGetDto>>> GetByCustomerIdAsync(int id, params string[] includelist);
        Task<ApiResponse<Order>> AddorderAsync(OrderPostDto dto, params string[] includelist);
        Task<ApiResponse<NoData>> DeletebyIdAsync(int id);
    }
}
