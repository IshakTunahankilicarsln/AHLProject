using Infrastructure.DataAccess.EF.Contexts;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class AdminRepository : BaseRepository<Admin, AHLDBContext>, Interfaces.IAdminRepository
    {
        public async Task<Admin> AddByAdmin(Admin admin, params string[] includelist)
        {
            var entity = await InsertAsync(admin, includelist);
            return entity;
        }

        public async Task<List<Admin>> GetAllAdminAsync(params string[] includelist)
        {
            var list = await GetAllAsync(p=> p.IsActive.Equals(true), includeList: includelist);
            return list;
        }

        public async Task<List<Admin>> GetByAdminNameAsync(string name, params string[] includelist)
        {
            var list = await GetAllAsync(kriter: p => p.AdminFullName.ToLower().Contains(name.ToLower()) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Admin> GetByIdAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(kriter: p => p.AdminId.Equals(id) & p.IsActive.Equals(true), includelist);
            return entity;
        }

        public async Task DeleteAdminAsync(int id)
        {
            var entity = await GetAsync(p => p.AdminId != null ? p.AdminId.Equals(id) : p.AdminId.Equals(0));
            entity.IsActive = false;
            await UpdateAsync(entity);
        }

        public async Task<Admin> GetByUsernameandPasswordAsync(string username, string password, params string[] includelist)
        {
            var entity = await GetAsync(kriter: p => p.UserName.Equals(username) & p.Password.Equals(password) & p.IsActive.Equals(true), includelist);
            return entity;
        }
    }
}
