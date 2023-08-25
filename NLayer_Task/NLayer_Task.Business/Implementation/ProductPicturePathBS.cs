using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using NLayer_Task.Business.Exceptions;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.ProductPicturePath;
using NLayer_Task.Model.Entites;
using System.IO;

namespace NLayer_Task.Business.Implementation
{
    public class ProductPicturePathBS : IProductPicturePathBS
    {
        private readonly IMapper _mapper;
        private readonly IProductPicturePathRepository _repo;
        public ProductPicturePathBS(IMapper mapper, IProductPicturePathRepository repo) { _mapper = mapper; _repo = repo; }

        public async Task<ApiResponse<ProductPicturePath>> AddAsync(ProductPicturePathPostDto path)
        {
            var fixProduct = _mapper.Map<ProductPicturePath>(path);
            var repo = await _repo.AddPAsync(fixProduct);

            return ApiResponse<ProductPicturePath>.Success(200, repo);
        }
        
        public async Task<ApiResponse<List<ProductPicturePathGetDto>>> GetallPicturePathsAsync(params string[] includelist)
        {
            var response = await _repo.GetAllPicturePathAsync(includelist: includelist);
            var list = _mapper.Map<List<ProductPicturePathGetDto>>(response);

            if (list.Count >= 0)
                return ApiResponse<List<ProductPicturePathGetDto>>.Success(200, list);
            throw new NotFoundException("Aradığınız kayır bulunamadı");
        }

        public async Task<ApiResponse<List<ProductPicturePathGetDto>>> GetPicturePathsAsync(int productId, params string[] includelist)
        {
            var response = await _repo.GetAllAsync(pictre => pictre.ProductID.Equals(productId), includelist);
            var entity = _mapper.Map<List<ProductPicturePathGetDto>>(response);

            if (entity.Count > 0)
                return ApiResponse<List<ProductPicturePathGetDto>>.Success(200, entity);

            throw new NotFoundException("Aradığınız kayır bulunamadı");
        }


        public async Task<List<ProductPicturePathGetDto>> GetByproductIdPicturePathsAsync(int productId, params string[] includelist)
        {
            var response = await _repo.GetAllAsync(pictre => pictre.ProductID.Equals(productId), includelist);
            var entity = _mapper.Map<List<ProductPicturePathGetDto>>(response);

            if (entity.Count > 0)
                return entity;

            throw new NotFoundException("Aradığınız kayır bulunamadı");
        }

        public async Task<ApiResponse<NoData>> UpdateAsync(ProductPicturePathPutDto path)
        {
            var fixProduct = _mapper.Map<ProductPicturePath>(path);
            await _repo.UpdateAsync(fixProduct);

            return ApiResponse<NoData>.Success(204);
        }

        public async Task<ApiResponse<NoData>> DeletePicturePathsAsync(int productId, params string[] includelist)
        {
            var response = await _repo.GetAllAsync(pictre => pictre.ProductID.Equals(productId), includelist);

            foreach (var item in response)
            {
                var DeleteItem = await _repo.GetAsync(pictre => pictre.ID.Equals(item.ID), includelist);
                await _repo.DeleteAsync(DeleteItem);
            }

            return ApiResponse<NoData>.Success(204);

        }

    }
}
