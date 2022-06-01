using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Primitives;

namespace VmsInformWeb.Controllers
{
    public abstract class BaseApiController : Controller
    {
        public override void OnActionExecuted(ActionExecutedContext context)
        {
            context.HttpContext.Response.Headers.Add("Cache-control", new StringValues(new[] { "no-cache", "no-store" }));
            context.HttpContext.Response.Headers.Add("Expires", "0");
            context.HttpContext.Response.Headers.Add("Pragma", "no-cache");
        }
    }
}