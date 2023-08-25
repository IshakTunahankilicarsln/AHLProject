using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.ProductPicturePath;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductPicturePathsController : BaseController
    {
        private readonly IProductPicturePathBS _pathBS;
        public ProductPicturePathsController(IProductPicturePathBS pathBS) { _pathBS = pathBS; }

        [HttpGet]
        public async Task<ActionResult> GetallPicturePathsAsync()
        {
            var response = await _pathBS.GetallPicturePathsAsync();
            return SendResponse(response);
        }

        [HttpPost]
        public async Task<ActionResult> Add([FromBody] ProductPicturePathPostDto path)
        {
            var response = await _pathBS.AddAsync(path);
            return SendResponse(response);
        }

        [HttpPut]
        public async Task<ActionResult> Update([FromBody] ProductPicturePathPutDto path)
        {
            var response = await _pathBS.UpdateAsync(path);
            return SendResponse(response);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetPicturePath(int id)
        {
            var response = await _pathBS.GetPicturePathsAsync(id);
            return SendResponse(response);
        }

    }
}
