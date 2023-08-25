using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Exceptions;
using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Order;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Implementation
{
    public class OrderBS : IOrderBS
    {
        private readonly IMapper _mapper;
        private readonly IOrderRepository _repo;
        public OrderBS(IMapper mapper, IOrderRepository repo) { _mapper = mapper; _repo = repo; }

        public async Task<ApiResponse<Order>> AddorderAsync(OrderPostDto dto, params string[] includelist)
        {
            if (dto == null)
                throw new BadRequestException("Spariş boş olamaz");

            var entity = _mapper.Map<Order>(dto);
            var addentity = await _repo.AddOrderAsync(entity, includelist);
            return ApiResponse<Order>.Success(200, addentity);

        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetAllOrderAsync(params string[] includelist)
        {
            var oldrepsList = await _repo.GetAllOrderAsync(includelist);
            var entity = _mapper.Map<List<OrderGetDto>>(oldrepsList);
            if (entity != null)
                return ApiResponse<List<OrderGetDto>>.Success(200, entity);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<List<OrderGetDto>>> GetByCustomerIdAsync(int id, params string[] includelist)
        {
            var oldrepsList = await _repo.GetByCustomerIdAsync(id, includelist);
            var entity = _mapper.Map<List<OrderGetDto>>(oldrepsList);
                return ApiResponse<List<OrderGetDto>>.Success(200, entity);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<OrderGetDto>> GetByOrderIdAsync(int id, params string[] includelist)
        {
            var oldrepsList = await _repo.GetByOrderIdAsync(id,includelist);
            var entity = _mapper.Map<OrderGetDto>(oldrepsList);
            if(entity != null)
                return ApiResponse<OrderGetDto>.Success(200, entity);


            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<NoData>> DeletebyIdAsync(int id)
        {
            var idcontrol = id.IdControl();
            if (idcontrol != null)
                throw new BadRequestException(idcontrol);

            await _repo.DeleteByIdAsync(id);
            return ApiResponse<NoData>.Success(204);
        }

    }
}
