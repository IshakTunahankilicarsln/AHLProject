using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Customer;
using NLayer_Task.Model.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayer_Task.Business.Implementation
{
    public class CustomerBS : ICustomerBS
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _repo;
        public CustomerBS(IMapper mapper, ICustomerRepository repo) { _mapper = mapper;_repo = repo; }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetAllCustomerAsync(params string[] includelist)
        {
            var olist =await _repo.GetAllCustomerAsync(includelist);
            var list = _mapper.Map<List<CustomerGetDto>>(olist);
            if (list.Count > 0)
                return ApiResponse<List<CustomerGetDto>>.Success(200, list);

            return ApiResponse<List<CustomerGetDto>>.Fail(404, "Aradığınız sonuçlar bulunamadı");

        }//olist = oldlist

        public async Task<ApiResponse<CustomerGetDto>> GetByIdAsync(int id, params string[] includelist)
        {
            var oentity =await _repo.GetByIdAsync(id: id, includelist);
            var entity = _mapper.Map<CustomerGetDto>(oentity);
            if (entity != null)
                return ApiResponse<CustomerGetDto>.Success(200, entity);

            return ApiResponse<CustomerGetDto>.Fail(404, "Aradığınız sonuçlar bulunamadı");
        }

        public async Task<ApiResponse<List<CustomerGetDto>>> GetByNameAsync(string name, params string[] includelist)
        {
            var olist =await _repo.GetByNameAsync(name: name,includelist);
            var list = _mapper.Map<List<CustomerGetDto>>(olist);
            if (list.Count > 0)
                return ApiResponse<List<CustomerGetDto>>.Success(200, list);

            return ApiResponse<List<CustomerGetDto>>.Fail(404, "Aradığınız sonuçlar bulunamadı");
        }

        public async Task<ApiResponse<Customer>> AddCustomerAsync(CustomerPostDto customer, params string[] includelist)
        {
            var entity = _mapper.Map<Customer>(customer);
            var rturnEntity = await _repo.AddCustomer(entity, includelist);
            return ApiResponse<Customer>.Success(200, rturnEntity);
        }

        public async Task<ApiResponse<NoData>> DeleteCustomerAsync(int id)
        {
            var entity = await _repo.GetAsync(c => c.CustomerID == id);
            _repo.DeleteCustomer(entity);
            return ApiResponse<NoData>.Success(204);
        }

        public async Task<ApiResponse<NoData>> UpdateCustomerAsync(CustomerPutDto customer)
        {
            var entity = _mapper.Map<Customer>(customer);
            await _repo.UpdateCustomer(entity);
            return ApiResponse<NoData>.Success(204);
        }
    }
}
