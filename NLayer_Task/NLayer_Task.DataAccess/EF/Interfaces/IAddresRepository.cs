using Infrastructure.DataAccess.Interface;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IAddresRepository : IBaseRepository<Addres>
    {
        Task<List<Addres>> GetAllAddresAsync(params string[] includelist);
        Task<List<Addres>> GetByCountryAsync(string country, params string[] includelist);
        Task<List<Addres>> GetByCityAsync(string city, params string[] includelist);
        Task<Addres> GetByIdAsync(int id, params string[] includelist);
        Task<Addres> AddAdresAsync(Addres adres, params string[] includelist);
        Task DeleteAddresAsync(int id, params string[] includelist);

    }
}
