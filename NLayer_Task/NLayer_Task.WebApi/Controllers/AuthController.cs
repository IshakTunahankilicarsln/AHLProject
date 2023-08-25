using Infrastructure.Model;
using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.Model.Dtos.Admin;
using NLayer_Task.Model.Entites;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : BaseController
    {
        private readonly IAdminBS _adminBS;
        public AuthController(IAdminBS adminBS) { _adminBS = adminBS; }

        [HttpGet]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<Admin>>))]
        public async Task<ActionResult> GetAllAdmin()
        {
            var list = await _adminBS.GetAllAdminAsync();

            return SendResponse(list);
        }

        [HttpGet("ByName")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<List<Admin>>))]
        public async Task<ActionResult> GetByName([FromQuery]string name)
        {
            var list = await _adminBS.GetByAdminNameAsync(name);
            return SendResponse(list);
        }

        [HttpGet("LogIn")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<Admin>))]
        public async Task<ActionResult> LogIn([FromQuery] string username, [FromQuery] string password)
        {
            var adminEntity = await _adminBS.GetByAdminUNamePaswordAsync(username, password);
            return SendResponse(adminEntity);
        }

        [HttpGet("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<Admin>))]
        public async Task<ActionResult> GetAdmin([FromRoute] int id)
        {
            var entity = await _adminBS.GetByAdminIdAsync(id);
            return SendResponse(entity);
        }

        [HttpPost]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<Admin>))]
        public async Task<ActionResult> AddAdmin([FromBody]AdminPostDto admin)
        {
            var entity =await _adminBS.AddAdminAsync(admin);
            return SendResponse(entity);
        }

        [HttpPut]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateAdmin([FromBody] AdminPutDto admin)
        {
            var entity = await _adminBS.UpdateAdminAsync(admin);
            return SendResponse(entity);
        }

        [HttpDelete("{id}")]
        [Produces("application/json", "text/plain")]
        [ProducesResponseType(200, Type = typeof(ApiResponse<NoData>))]
        public async Task<ActionResult> UpdateAdmin([FromRoute] int id)
        {
            var entity = await _adminBS.DeleteAdminAsync(id);
            return SendResponse(entity);
        }
    }
}
