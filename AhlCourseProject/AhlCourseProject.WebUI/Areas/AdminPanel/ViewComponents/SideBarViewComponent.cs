using AhlCourseProject.WebUI.Areas.AdminPanel.Models.ApiTypes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewComponents;
using System.Text.Json;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.ViewComponents
{
    public class SideBarViewComponent : ViewComponent
    {
        // bu methodun Adı Invoke() olmak zorunda
        public ViewViewComponentResult Invoke()
        {
            var sessionData = HttpContext.Session.GetString("ActiveAdmenPanelUser");
            var data = JsonSerializer.Deserialize<AdminPanelUseritem>(sessionData);
            return View(data);

        }
    }
}
