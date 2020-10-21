using System.Web;
using System.Web.Mvc;

namespace BitirmeProjem.UI.Areas.Admin.Controllers
{
    public class SessionControl: ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (!HttpContext.Current.Response.IsRequestBeingRedirected)
                    filterContext.HttpContext.Response.Redirect("/Admin/Login");
            }
        }
    }
}