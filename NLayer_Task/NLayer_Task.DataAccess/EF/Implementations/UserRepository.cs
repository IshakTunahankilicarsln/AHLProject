using Infrastructure.DataAccess.EF.Contexts;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class UserRepository : BaseRepository<User, AHLDBContext>, IUserRepository
    {
        public async Task<List<User>> GetAllUserAsync(params string[] includelist)
        {
            var list = await GetAllAsync(includeList : includelist);
            return list;
        }

        public Task<User> GetByIDAsync(int id, params string[] includelist)
        {
            throw new NotImplementedException();
        }
    }
}
