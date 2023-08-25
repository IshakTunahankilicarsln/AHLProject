using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Exceptions;
using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Addres;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Implementation
{
    public class AddresBS : IAddresBS
    {
        private readonly IMapper _mapper;
        private readonly IAddresRepository _repo;
        public AddresBS(IMapper mapper, IAddresRepository repo) { _mapper = mapper; _repo = repo; }

        

        public async Task<ApiResponse<List<AddresGetDto>>> GetAllAddresAsync(params string[] includelist)
        {
            var oldlist =await _repo.GetAllAddresAsync(includelist);
            var newlist = _mapper.Map<List<AddresGetDto>>(oldlist);
            if (newlist.Count > 0) 
                return ApiResponse<List<AddresGetDto>>.Success(200, newlist);
            throw new NotFoundException();

        }

        public async Task<ApiResponse<List<AddresGetDto>>> GetByCityAsync(string city, params string[] includelist)
        {
            var oldlist =await _repo.GetByCityAsync(city,includelist);
            var newlist = _mapper.Map<List<AddresGetDto>>(oldlist);
            if (newlist.Count > 0)
                return ApiResponse<List<AddresGetDto>>.Success(200, newlist);
            throw new NotFoundException();
        }

        public async Task<ApiResponse<List<AddresGetDto>>> GetByCountryAsync(string country, params string[] includelist)
        {
            var oldlist = await _repo.GetByCountryAsync(country,includelist);
            var newlist = _mapper.Map<List<AddresGetDto>>(oldlist);
            if (newlist.Count > 0)
                return ApiResponse<List<AddresGetDto>>.Success(200, newlist);
            throw new NotFoundException();

        }

        public async Task<ApiResponse<AddresGetDto>> GetByIdAsync(int id, params string[] includelist)
        {
            var oldentity = await _repo.GetByIdAsync(id,includelist);
            var entity = _mapper.Map<AddresGetDto>(oldentity);
            if (entity != null)
                return ApiResponse<AddresGetDto>.Success(200, entity);

            throw new NotFoundException("Aradığınız Sonuç Bulunamadı");

        }

        public async Task<ApiResponse<NoData>> DeleteAddresAsync(int id, params string[] includelist)
        {
            var cntrolText = id.IdControl();
                if (cntrolText != null)
                throw new BadRequestException(cntrolText);

            await _repo.DeleteAddresAsync(id,includelist);
            return ApiResponse<NoData>.Success(204);
        }

        public async Task<ApiResponse<Addres>> AddAddresasync(AddresPostDto addres, params string[] includelist)
        {
            var entity = _mapper.Map<Addres>(addres);
            var returnent = await _repo.AddAdresAsync(entity, includelist);
            return ApiResponse<Addres>.Success(200, returnent);
        }

        public async Task<ApiResponse<Addres>> UpdateAddresAsync(AddresPutDto addres, params string[] includelist)
        {
            var entity = _mapper.Map<Addres>(addres);
            await _repo.UpdateAsync(entity);
            return ApiResponse<Addres>.Success(204);
        }
    }
}
