using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.ProductDto;
using NLayer_Task.Model.Dtos.ProductPicturePath;
using NLayer_Task.Model.Dtos.SpesificDto;
using NLayer_Task.Model.Entites;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : BaseController
    {
        private readonly IProductBS _productBS;
        private readonly IProductPicturePathBS _pitureBS;
        public ProductsController(IProductBS productBS, IProductPicturePathBS pitureBS) { _productBS = productBS; _pitureBS = pitureBS; }

        [HttpGet]
        public async Task<ActionResult> GetAllProduct()
        {
            var response = await _productBS.GetAllProductAsync("Category", "ProductPicturePath");
            return SendResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetbyId([FromRoute(Name = "id")] int id)
        {
            var employe = await _productBS.GetByIdAsync(id, "Category", "ProductPicturePath");
            return Ok(employe);
        }

        [HttpGet("byname")]
        public async Task<ActionResult> GetByProductName([FromQuery] string name)
        {
            var response = await _productBS.GetByProductNameAsync(name, "Category");
            return SendResponse(response);
        }

        [HttpGet("bymaterial")]
        public async Task<ActionResult> GetByMaterial([FromQuery] string name)
        {
            var response = await _productBS.GetByMaterialAsync(name, "ProductPicturePath");
            return SendResponse(response);
        }

        [HttpGet("categoryId")]
        public async Task<ActionResult> GetCategorybyId([FromQuery] int categoryId)
        {
            var employe = await _productBS.GetByCategryIdAsync(categoryId, "Category", "ProductPicturePath");
            return Ok(employe);
        }

        [HttpGet("byprice")]
        public async Task<ActionResult> GetByPrice([FromQuery] decimal min, [FromQuery] decimal max)
        {
            var response = await _productBS.GetByUnitPriceAsync(min, max, "Category", "ProductPicturePath");
            return SendResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> AddProduct([FromBody] ProductPostDto prodct)
        {
            var response = await _productBS.AddAsync(prodct, "ProductPicturePath");
            return SendResponse(response);
        }

        [HttpPut]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductPutDto prodct)
        {
            var response = await _productBS.UpdateAsync(prodct);
            return SendResponse(response);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteProduct([FromRoute] int id)
        {
            var response = await _productBS.DeletebyIdAsync(id);
            return SendResponse(response);
        }

        [HttpPost("byMix")]
        public async Task<ActionResult> Add([FromBody] ProductAndPıcturePostDto entity)
        {
            ProductPostDto product = entity.Productpostdto;
            var response = await _productBS.AddAsync(product);
            for (int i = 0; i < entity.PictureImages.Count; i++)
            {
                _ = _pitureBS.AddAsync(new ProductPicturePathPostDto()
                {
                    ProductID = response.Data.ProductID,
                    PicturePath = entity.PictureImages.ToList()[i]

                });
            }
            return SendResponse(response);

        }

        [HttpPut("byMix")]
        public async Task<ActionResult> UpdateProduct([FromBody] ProductAndPicturePutDto entity)
        {
            ProductPutDto product = entity.Productputdto;
            var response = await _productBS.UpdateAsync(product);
            var rtnresponse =  await _pitureBS.DeletePicturePathsAsync(entity.Productputdto.ProductID);
            foreach (var item in entity.PictureImages)
            {

                _ = _pitureBS.AddAsync(new ProductPicturePathPostDto()
                {
                    ProductID = entity.Productputdto.ProductID,
                    PicturePath = item
                });

            }
            return SendResponse(rtnresponse);
        }
    }

}
