using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos;
using AhlCourseProject.WebUI.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace AhlCourseProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpApiService _service;
        public HomeController(IHttpApiService service) { _service = service;  }

        public async Task<IActionResult> Index()
        {
            var responseP = await _service.GetData<ResponseBody<List<ProductItem>>>("/Products");
            var responseC = await _service.GetData<ResponseBody<List<CategoryItem>>>("/Categories");

            var model = new ViewContenttype();
            model.RroductItem = responseP.Data;
            model.CategoryItem = responseC.Data;
            return View(model);
        }

        public async Task<IActionResult> Products()
        {
            var responseP = await _service.GetData<ResponseBody<List<ProductItem>>>("/Products");
            var responseC = await _service.GetData<ResponseBody<List<CategoryItem>>>("/Categories");

            var model = new ViewContenttype();
            model.RroductItem = responseP.Data;
            model.CategoryItem = responseC.Data;
            return View(model);
        }

    }
}