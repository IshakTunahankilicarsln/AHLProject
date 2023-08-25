using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.Categories;
using NLayer_Task.Model.Entites;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : BaseController
    {
        private readonly ICategoryBS _categBS;
        public CategoriesController(ICategoryBS categBS) { _categBS = categBS; }

        [HttpGet]
        [Produces("application/json" , "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        public async Task<ActionResult> GetAll()
        {
            var list = await _categBS.GetAllAsync("Product");
            return SendResponse(list);
        }

        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<CategoryGetDto>))]
        public async Task<ActionResult> GetById([FromRoute]int id)
        {
            var entity = await _categBS.GetByIdAsync(id, "Product");
            return SendResponse(entity);
        }

        [HttpGet("byname")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<CategoryGetDto>>))]
        public async Task<ActionResult> GetByName([FromQuery]string name)
        {
            var list = await _categBS.GetByCNameAsync("Product");
            return SendResponse(list);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<Category>))]
        public async Task<ActionResult> AddCategory([FromBody]CategoryPostDto dto)
        {
            var entity = await _categBS.AddCategoryAsync(dto);
            return SendResponse(entity);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(204, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateCategory([FromBody] CategoryPutDto dto)
        {
            var entity = await _categBS.UpdateCategoryAsync(dto);
            return SendResponse(entity);
        }

        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(204, Type = typeof(ApiResponse<NoData>))]
        [ProducesResponseType(400, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> DeleteCategory([FromRoute] int id)
        {
            var entity = await _categBS.DeleteCategoryAsync(id);
            return SendResponse(entity);
        }
    }
}
