using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Exceptions;
using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Dtos.Admin;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Implementation
{
    public class AdminBS : IAdminBS
    {
        private readonly IMapper _mapper;
        private readonly IAdminRepository _repo;

        public AdminBS(IMapper mapper, IAdminRepository repo) { _mapper = mapper; _repo = repo; }

        public async Task<ApiResponse<Admin>> AddAdminAsync(AdminPostDto admin, params string[] includelist)
        {
            var entity = _mapper.Map<Admin>(admin);
            var returnent = await _repo.AddByAdmin(entity, includelist);
            return ApiResponse<Admin>.Success(200, returnent);
        }       

        public async Task<ApiResponse<List<AdminGetDto>>> GetAllAdminAsync(params string[] includelist)
        {
            var oldrepsList = await _repo.GetAllAdminAsync(includelist);
            var repsList = _mapper.Map<List<AdminGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<AdminGetDto>>.Success(200, repsList);

            return ApiResponse<List<AdminGetDto>>.Fail(404, "Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<AdminGetDto>> GetByAdminIdAsync(int id, params string[] includelist)
        {
            var oldentity = await _repo.GetByIdAsync(id, includelist);
            var entity = _mapper.Map<AdminGetDto>(oldentity);
            if (entity != null)
                return ApiResponse<AdminGetDto>.Success(200, entity);

            throw new NotFoundException("Aradığınız Sonuç Bulunamadı");
        }

        public async Task<ApiResponse<List<AdminGetDto>>> GetByAdminNameAsync(string name, params string[] includelist)
        {
            var oldlist = await _repo.GetByAdminNameAsync(name, includelist);
            var newlist = _mapper.Map<List<AdminGetDto>>(oldlist);
            if (newlist.Count > 0)
                return ApiResponse<List<AdminGetDto>>.Success(200, newlist);
            throw new NotFoundException();
        }

        public async Task<ApiResponse<Admin>> UpdateAdminAsync(AdminPutDto addres)
        {
            var entity = _mapper.Map<Admin>(addres);
            await _repo.UpdateAsync(entity);
            return ApiResponse<Admin>.Success(204);
        }

        public async Task<ApiResponse<NoData>> DeleteAdminAsync(int id)
        {
            var cntrolText = id.IdControl();
            if (cntrolText != null)
                throw new BadRequestException(cntrolText);

            await _repo.DeleteAdminAsync(id);
            return ApiResponse<NoData>.Success(204);
        }

        public async Task<ApiResponse<AdminGetDto>> GetByAdminUNamePaswordAsync(string username, string password, params string[] includelist)
        {
            var constring = username.TextControl();
            if (constring != null)
                throw new BadRequestException(constring);
            if (password == null)
                throw new BadRequestException("şifre boş olamaz");
            var oldentity = await _repo.GetByUsernameandPasswordAsync(username, password, includelist);
            var entity = _mapper.Map<AdminGetDto>(oldentity);
            if (oldentity == null)
                throw new BadRequestException("Girilen bilgilere uyumlu Kullanıcı Bulunamadı");

            if (entity != null)
                return ApiResponse<AdminGetDto>.Success(200, entity);

            throw new NotFoundException("Aradığınız Sonuç Bulunamadı");
        }
    }
}
