using Infrastructure.DataAccess.EF.Contexts;
using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IUserRepository : IBaseRepository<User>
    {
        Task<List<User>> GetAllUserAsync(params string[] includelist);
        Task<User> GetByIDAsync(int id, params string[] includelist);
    }
}
