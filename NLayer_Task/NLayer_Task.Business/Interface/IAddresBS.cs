using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Interface
{
    public interface IAddresBS
    {
        Task<ApiResponse<List<AddresGetDto>>> GetAllAddresAsync(params string[] includelist);
        Task<ApiResponse<List<AddresGetDto>>> GetByCountryAsync(string country, params string[] includelist);
        Task<ApiResponse<List<AddresGetDto>>> GetByCityAsync(string city, params string[] includelist);
        Task<ApiResponse<AddresGetDto>> GetByIdAsync(int id, params string[] includelist);
        Task<ApiResponse<NoData>> DeleteAddresAsync(int id, params string[] includelist);
        Task<ApiResponse<Addres>> AddAddresasync(AddresPostDto addres, params string[] includelist);//AddAdresAsync
        Task<ApiResponse<Addres>> UpdateAddresAsync(AddresPutDto addres, params string[] includelist);


    }
}
