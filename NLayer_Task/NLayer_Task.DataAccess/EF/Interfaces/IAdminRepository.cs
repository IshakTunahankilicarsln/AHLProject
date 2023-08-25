using Infrastructure.DataAccess.Interface;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.DataAccess.EF.Interfaces
{
    public interface IAdminRepository : IBaseRepository<Admin>
    {
        Task<List<Admin>> GetAllAdminAsync(params string[] includelist);
        Task<List<Admin>> GetByAdminNameAsync(string name, params string[] includelist);
        Task<Admin> GetByIdAsync(int id, params string[] includelist);
        Task<Admin> AddByAdmin(Admin admin, params string[] includelist);
        Task DeleteAdminAsync(int id);
        Task<Admin> GetByUsernameandPasswordAsync(string username, string password, params string[] includelist);

    }
}
