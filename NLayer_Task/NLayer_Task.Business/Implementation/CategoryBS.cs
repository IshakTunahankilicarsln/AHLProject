using AutoMapper;
using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using NLayer_Task.Business.Extension.AlExtension;
using NLayer_Task.Business.Interface;
using NLayer_Task.DataAccess.EF.Interfaces;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Entites;

namespace NLayer_Task.Business.Implementation
{
    public class CategoryBS : ICategoryBS
    {
        private readonly IMapper _mapper;
        private readonly ICategoryRepository _repo;
        public CategoryBS(IMapper mapper, ICategoryRepository repo) { _mapper = mapper; _repo = repo; }


        public async Task<ApiResponse<List<CategoryGetDto>>> GetAllAsync(params string[] includelist)
        {   
            var oldlist =await  _repo.GetAllCAsync(includelist);
            var list = _mapper.Map<List<CategoryGetDto>>(oldlist);
            return ApiResponse<List<CategoryGetDto>>.Success(200, list);
        }

        public async Task<ApiResponse<List<CategoryGetDto>>> GetByCNameAsync(string name, params string[] includelist)
        {
            var control = name.TextControl();
            if (control != null)
                return ApiResponse<List<CategoryGetDto>>.Fail(400, control);

            var oldlist =await _repo.GetByCNameAsync(name, includelist);
            var list = _mapper.Map<List<CategoryGetDto>>(oldlist);
            return ApiResponse<List<CategoryGetDto>>.Success(200, list);
        }

        public async Task<ApiResponse<CategoryGetDto>> GetByIdAsync(int id, params string[] includelist)
        {
            var control = id.IdControl();
            if (control != null)
                return ApiResponse<CategoryGetDto>.Fail(400, control);

            var oldlist =await _repo.GetAsync(c=>c.CategoryId.Equals(id), includelist);
            var list = _mapper.Map<CategoryGetDto>(oldlist);
            return ApiResponse<CategoryGetDto>.Success(200, list);
        }

        public async Task<ApiResponse<Category>> AddCategoryAsync(CategoryPostDto category, params string[] includelist)
        {
            var entity = _mapper.Map<Category>(category);
            var rturnEntity =await _repo.AddAsync(entity, includelist);
            return ApiResponse<Category>.Success(200, rturnEntity);

        }

        public async Task<ApiResponse<NoData>> DeleteCategoryAsync(int id)
        {
            var entity =await _repo.GetAsync(c => c.CategoryId == id);
            await _repo.DeleteAsync(entity);
            
            var wasItDeleted = await _repo.GetAsync(c => c.CategoryId == id && c.IsActive.Equals(true) );
            if (wasItDeleted == null)
                return ApiResponse<NoData>.Success(204);

            return ApiResponse<NoData>.Fail(StatusCodes.Status400BadRequest, "Silme İşlemi Gerçekleşmedi");

        }

        public async Task<ApiResponse<NoData>> UpdateCategoryAsync(CategoryPutDto category)
        {
            var entity = _mapper.Map<Category>(category);
            await _repo.Updateasync(entity);
            return ApiResponse<NoData>.Success(204);
        }
    }
}
