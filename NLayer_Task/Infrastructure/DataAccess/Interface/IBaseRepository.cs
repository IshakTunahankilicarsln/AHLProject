using Infrastructure.Model;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.Interface
{
    public interface IBaseRepository<Tentity> where Tentity : class, IEntity
    {
        Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity, bool>> kriter = null, params string[] includeList);
        Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> kriter, params string[] includeList);
        Task<Tentity> InsertAsync(Tentity entity, params string[] includeList);
        Task UpdateAsync(Tentity entity);
        Task DeleteAsync(Tentity entity);
    }
}
