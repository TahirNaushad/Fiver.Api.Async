using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Fiver.Api.Async.Lib
{
    public class BaseController : Controller
    {
        [NonAction]
        protected IActionResult SeeOther(string routeName, object values)
        {
            var location = Url.Link(routeName, values);
            HttpContext.Response.GetTypedHeaders().Location = new System.Uri(location);
            return StatusCode(StatusCodes.Status303SeeOther);
        }
    }
}
