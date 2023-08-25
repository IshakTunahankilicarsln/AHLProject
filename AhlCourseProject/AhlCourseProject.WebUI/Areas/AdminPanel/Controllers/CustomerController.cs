using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.Items;
using Microsoft.AspNetCore.Mvc;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class CustomerController : Controller
    {
        private readonly IHttpApiService _service;
        public CustomerController(IHttpApiService service) { _service = service; }


        public async Task<IActionResult> Index()
        {
            var response =await _service.GetData<ResponseBody<List<CustomerItem>>>("/Customers");
            return View(response.Data);
        }

        [HttpPost]
        public async Task<IActionResult> Delete([FromRoute]int id)
        {
            var response = await _service.GetData<ResponseBody<List<CustomerItem>>>("/Customers");
            return View(response.Data);
        }
    }
}
