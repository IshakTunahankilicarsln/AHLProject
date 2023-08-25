using AutoMapper;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Admin;
using NLayer_Task.Model.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Implementation
{
    public class UserBS : IUserBS
    {
        private readonly IMapper _mapper;
        private readonly IUserRepository _repo;
        public UserBS(IMapper mapper,IUserRepository repo) { _repo = repo; _mapper = mapper; }

        public async Task<ApiResponse<List<UserGetDto>>> GetAllUserAsync(params string[] includelist)
        {
            var oldrepsList = await _repo.GetAllUserAsync(includelist);
            var repsList = _mapper.Map<List<UserGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<UserGetDto>>.Success(200, repsList);

            return ApiResponse<List<UserGetDto>>.Fail(404, "Aradığınız Sonuçlar Bulunamadı");
        }

        public Task<ApiResponse<UserGetDto>> GetByIdAsync(int id, params string[] includelist)
        {
            throw new NotImplementedException();
        }
    }
}
