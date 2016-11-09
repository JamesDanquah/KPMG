using System.Web.Mvc;
using TestProject.Models;

namespace TestProject.Controllers
{
    public class BaseController : Controller
    {
        protected override void OnActionExecuting(ActionExecutingContext ctx)
        {
            base.OnActionExecuting(ctx);
        }

        protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            var model = filterContext.Controller.ViewData.Model as BaseModel;

            base.OnActionExecuted(filterContext);
        }
    }
}