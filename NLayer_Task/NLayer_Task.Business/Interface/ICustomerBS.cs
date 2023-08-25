using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Dtos.Customer;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface ICustomerBS
    {
        Task<ApiResponse<List<CustomerGetDto>>> GetAllCustomerAsync(params string[] includelist);
        Task<ApiResponse<List<CustomerGetDto>>> GetByNameAsync(string name, params string[] includelist);
        Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int id, params string[] includelist);
        Task<ApiResponse<Customer>> AddCustomerAsync(CustomerPostDto customer, params string[] includelist);
        Task<ApiResponse<NoData>> UpdateCustomerAsync(CustomerPutDto customer);
        Task<ApiResponse<NoData>> DeleteCustomerAsync(int id);
    }
}
