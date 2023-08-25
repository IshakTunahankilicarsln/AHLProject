using Infrastructure.Utilities.ApiResponses;
using Microsoft.AspNetCore.Mvc;

namespace NLayer_Task.WebApi.Base
{
    public class BaseController : ControllerBase
    {
        [NonAction]
        public ActionResult SendResponse<T>(ApiResponse<T> response)
        {
            if (response.StatusCode == 204)
                return new ObjectResult(null) { StatusCode = response.StatusCode };

            return new ObjectResult(response) { StatusCode = response.StatusCode };
        }
    }
}
