using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using Microsoft.AspNetCore.Mvc;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    //[SessionControlAspect]
    public class HomeController : Controller
    {
        private readonly IHttpApiService _service;
        public HomeController(IHttpApiService service) { _service = service; }

        public IActionResult Index()
        {
            return View();
        }

    }
}
