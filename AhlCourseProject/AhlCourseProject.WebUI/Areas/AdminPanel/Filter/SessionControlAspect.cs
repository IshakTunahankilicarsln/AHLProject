using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace AhlCourseProject.WebUI.Areas.AdminPanel.Filter
{
    public class SessionControlAspect : ActionFilterAttribute
    {

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var sessionData = context.HttpContext.Session.GetString("ActiveAdmenPanelUser");
            if (string.IsNullOrEmpty(sessionData))
            {
                context.Result =  new RedirectToActionResult("", "adminpanel", null);
            }
        }
    }
}
