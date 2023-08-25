using AhlCourseProject.WebUI.ApiServices;
using AhlCourseProject.WebUI.Areas.AdminPanel.Filter;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using AhlCourseProject.WebUI.Areas.AdminPanel.Models.Dtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Evaluation;
using System.Text.Json;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class AuthController : Controller
    {
        private readonly IHttpApiService _service;
        public AuthController(IHttpApiService service) { _service = service; }


        [HttpGet]
        public IActionResult LogIn()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> LogIn(LogInDto dto)
        {

            var response = await _service.GetData<ResponseBody<AdminPanelUseritem>>(reqURI: $"/Auth/LogIn?username={dto.UserName}&password={dto.Password}");
            if (response.StatusCode < 300 && response.StatusCode >= 200)
            {
                //HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));
                HttpContext.Session.SetString("ActiveAdmenPanelUser", JsonSerializer.Serialize(response.Data));
                return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
            }
            else
            {
                return Json(new { IsSuccess = false, Messages = response.ErrorMessage });
            }

            /*using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5232/api");

                var responseMessage = await client.GetAsync($"{client.BaseAddress}/auth/login?userName={dto.UserName}&password={dto.Password}");

                var jsonResponse = await responseMessage.Content.ReadAsStringAsync();

                var response = JsonSerializer.Deserialize<ResponseBody<AdminPanelUseritem>>(jsonResponse, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });

                if (responseMessage.IsSuccessStatusCode)
                {
                    //HttpContext.Session.SetString("ActiveAdminPanelUser", JsonSerializer.Serialize(response.Data));
                    HttpContext.Session.SetString("ActiveAdmenPanelUser",JsonSerializer.Serialize(response.Data));
                    return Json(new { IsSuccess = true, Messages = "Kullanıcı Bulundu" });
                }
                else
                {
                    return Json(new { IsSuccess = false, Messages = response.ErrorMessage });
                }
            }*/


        }


    }
}
