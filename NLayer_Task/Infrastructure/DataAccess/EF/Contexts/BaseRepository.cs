using Infrastructure.DataAccess.Interface;
using Infrastructure.Model;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Infrastructure.DataAccess.EF.Contexts
{
    public class BaseRepository<Tentity, TContext> : IBaseRepository<Tentity>
        where Tentity : class, IEntity
        where TContext : DbContext , new()
    {
        public async Task<List<Tentity>> GetAllAsync(Expression<Func<Tentity,bool>> kriter = null ,params string[] includeList)
        {
            using (TContext context = new TContext())            
            {
                
                IQueryable<Tentity> dbset = context.Set<Tentity>();
                if (includeList.Length > 0)
                {
                    foreach (string include in includeList)
                    { dbset = dbset.Include(include); }                        
                }

                if(kriter is null)
                    return await dbset.ToListAsync();

                var tentList = await dbset.Where(kriter).ToListAsync();
                return tentList;

            }
        }

        public async Task<Tentity> GetAsync(Expression<Func<Tentity, bool>> kriter, params string[] includeList)
        {   
            
            using (TContext context = new TContext())
            {
                IQueryable<Tentity> dbset = context.Set<Tentity>();
                if (includeList.Length > 0)
                {
                    foreach (string include in includeList)
                    { dbset = dbset.Include(include); }
                }
                var entity =await dbset.Where(kriter).SingleOrDefaultAsync();
                return entity;
            }
            
        }        

        public async Task<Tentity> InsertAsync(Tentity entity, params string[] includeList)
        {
            using(TContext context = new TContext())
            {
                var entryEntity = context.Set<Tentity>().Add(entity);
                await context.SaveChangesAsync();
                return entryEntity.Entity;
            }
        }

        public async Task DeleteAsync(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<Tentity>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task UpdateAsync(Tentity entity)
        {
            using (TContext context = new TContext())
            {
                context.Set<Tentity>().Update(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
