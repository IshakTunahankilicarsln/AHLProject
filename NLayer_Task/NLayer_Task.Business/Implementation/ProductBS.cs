using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Exceptions;
using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Implementation
{
    public class ProductBS : IProductBS
    {
        private readonly IProductRepository _repo;
        private readonly IMapper _mapper;
        public ProductBS(IProductRepository repo, IMapper mapper) { _repo = repo; _mapper = mapper; }

        public async Task<ApiResponse<List<ProductGetDto>>> GetAllProductAsync(params string[] includelist)
        {
            var oldrepsList = await _repo.GetAllProductAsync(includelist);
            var repsList = _mapper.Map<List<ProductGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<ProductGetDto>>.Success(200, repsList);

            throw new NotFoundException( "Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByMaterialAsync(string material, params string[] includelist)
        {
            var controls = material.TextControl();
            if (controls != null)
                throw new BadRequestException(controls);

            var oldrepsList = await _repo.GetByMaterialAsync(material, includelist: includelist);
            var repsList = _mapper.Map<List<ProductGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<ProductGetDto>>.Success(200, repsList);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByProductNameAsync(string name, params string[] include)
        {
            var controls = name.TextControl();
            if (controls != null)
                throw new BadRequestException(controls);
            var oldrepsList = await _repo.GetByProductNameAsync(name,include);
            var repsList = _mapper.Map<List<ProductGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<ProductGetDto>>.Success(200, repsList);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByUnitPriceAsync(decimal min, decimal max, params string[] includelist)
        {
            var oldrepsList = await _repo.GetByUnitPriceAsync(min, max, includelist);
            var repsList = _mapper.Map<List<ProductGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<ProductGetDto>>.Success(200, repsList);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<List<ProductGetDto>>> GetByCategryIdAsync(int id, params string[] includelist)
        {
            var oldrepsList = await _repo.GetByCategoryIDAsync(id, includelist);
            var repsList = _mapper.Map<List<ProductGetDto>>(oldrepsList);
            if (repsList.Count > 0)
                return ApiResponse<List<ProductGetDto>>.Success(200, repsList);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");
        }

        public async Task<ApiResponse<ProductGetDto>> GetByIdAsync(int id, params string[] includelist)
        {
            var idcontrol = id.IdControl();
            if (idcontrol != null)
                throw new BadRequestException(idcontrol);

            var entity =await _repo.GetByIdAsync(id, includelist);
            var mapentity = _mapper.Map<ProductGetDto>(entity);
            if (mapentity != null)
                return ApiResponse<ProductGetDto>.Success(200, mapentity);

            throw new NotFoundException("Aradığınız Sonuçlar Bulunamadı");

        }

        public async Task<ApiResponse<Product>> AddAsync(ProductPostDto productdto, params string[] includelist)
        {
            var control1 = productdto.ProductName.TextControl();
            if (control1 != null)
                throw new BadRequestException(control1);

            var control2 = productdto.UnitsInStock.IdControl();
            if (control2 != null)
                throw new BadRequestException(control2);

            var control3 = productdto.ProductName.TextControl();
            if (control3 != null)
                throw new BadRequestException(control3);
            var control4 = productdto.ProductMaterial.TextControl();
            if (control4 != null)
                throw new BadRequestException(control4);
            var control5 = productdto.CategoryID.IdControl();
            if (control5 != null)
                throw new BadRequestException(control5);

            var entity = _mapper.Map<Product>(productdto);
            var Repentity = await _repo.AddProductAsync(entity, includelist);
            return ApiResponse<Product>.Success(200, Repentity);
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPutDto productPutDto)
        {
            var entity = _mapper.Map<Product>(productPutDto);
            await _repo.UpdateProductAsync(entity);
            return ApiResponse<NoData>.Success(204);
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
