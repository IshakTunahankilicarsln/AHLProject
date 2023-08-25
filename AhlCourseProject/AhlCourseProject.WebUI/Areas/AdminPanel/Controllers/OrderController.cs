using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos.Items;
using Microsoft.AspNetCore.Mvc;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    [SessionControlAspect]
    public class OrderController : Controller
    {
        private readonly IHttpApiService _service;
        public OrderController(IHttpApiService service) { _service = service; }

        public async Task<IActionResult> Index()
        {
            var response = await _service.GetData<ResponseBody<List<OrderItem>>>("/Orders");
            return View(response.Data);
        }
    }
}
