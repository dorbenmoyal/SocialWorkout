using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialWorkout.Filters
{
    public class AutorizeAdmin : System.Web.Mvc.ActionFilterAttribute, System.Web.Mvc.IActionFilter
    {

        public override void OnActionExecuting(System.Web.Mvc.ActionExecutingContext filterContext)
        {
            // Check if the admin session in set
            if (HttpContext.Current.Session["Admin"] == null)
            {
                filterContext.Result = new System.Web.Mvc.RedirectToRouteResult(new System.Web.Routing.RouteValueDictionary
                {
                    // redirect to signIn page in case the admin session is null
                    {"Controller", "Home"},
                    {"Action", "Unauthorized"}
                });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}