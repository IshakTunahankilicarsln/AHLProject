using Infrastructure.DataAccess.EF.Contexts;
using Infrastructure.DataAccess.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer_Task.Business.Interface;
using NLayer_Task.WebApi.Base;

namespace NLayer_Task.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : BaseController
    {
        private readonly IUserBS _userBS;
        public UsersController(IUserBS userBS) { _userBS = userBS; }

        [HttpGet]
        public async Task<ActionResult> GetAllAdmin()
        {
            var list = await _userBS.GetAllUserAsync();
            return SendResponse(list);
        }
    }
}
