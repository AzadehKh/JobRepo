using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace JobRepo.ActionFilters
{
    public class LoggedAsEmployeeActionFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.HttpContext.User.Identity == null)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = "Home",
                    action = "Login",
                    message ="Please Log in to access this page "
                }));
            }
            else
            {
                int EmployeeID = filterContext.HttpContext.Session["EmployeeID"] == null ? 0 : Convert.ToInt32(filterContext.HttpContext.Session["EmployeeID"]);
                int EmployerID = filterContext.HttpContext.Session["EmployerID"] == null ? 0 : Convert.ToInt32(filterContext.HttpContext.Session["EmployerID"]);
                if (EmployeeID <= 0)
                {
                    if (EmployeeID <= 0)
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "Login",
                            message = "Please Log in to access this page "
                        }));
                    }
                    else
                    {
                        filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                        {
                            controller = "Home",
                            action = "Login",
                            message = "Please use different account to access this page"
                        }));
                    }
                }
            }

        }
    }
}