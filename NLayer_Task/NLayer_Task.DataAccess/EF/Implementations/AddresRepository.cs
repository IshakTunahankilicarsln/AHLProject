using Infrastructure.DataAccess.EF.Contexts;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.DataAccess.EF.Context;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.DataAccess.EF.Implementations
{
    public class AddresRepository : BaseRepository<Addres, AHLDBContext>, IAddresRepository
    {
        public async Task<List<Addres>> GetAllAddresAsync(params string[] includelist)
        {            
            var list =await GetAllAsync(kriter: p => p.IsActive.Equals(true),includelist);
            return list;
        }

        public async Task<List<Addres>> GetByCountryAsync(string country, params string[] includelist)
        {
            var list =await GetAllAsync(kriter: p => p.Country.ToLower().Contains(country.ToLower()) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<List<Addres>> GetByCityAsync(string city, params string[] includelist)
        {
            var list =await GetAllAsync(kriter: p=>p.City.ToLower().Contains(city.ToLower()) & p.IsActive.Equals(true), includelist);
            return list;
        }

        public async Task<Addres> GetByIdAsync(int id, params string[] includelist)
        {
            var entity =await GetAsync(kriter: p => p.AddresID.Equals(id) & p.IsActive.Equals(true), includelist);
            return entity;
        }

        public async Task<Addres> AddAdresAsync(Addres adres, params string[] includelist)
        {
            var entity = await InsertAsync(adres, includelist);
            return entity;
        }

        public async Task DeleteAddresAsync(int id, params string[] includelist)
        {
            var entity = await GetAsync(p => p.AddresID != null ? p.AddresID.Equals(id) : p.AddresID.Equals(0), includelist);
            entity.IsActive = false;
            await UpdateAsync(entity);
        }
    }
}
