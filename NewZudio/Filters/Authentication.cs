using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Mvc.Filters;
using System.Web.Routing;

namespace NewZudio.Filters
{
    public class Authentication : ActionFilterAttribute, IAuthenticationFilter
    {
        public void OnAuthentication(AuthenticationContext filterContext)
        {
            if (HttpContext.Current.Session["ID"] == null)
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary(new { Controller = "Login", action = "Login" }));
            }
        }

        public void OnAuthenticationChallenge(AuthenticationChallengeContext filterContext)
        {
            
        }
    }
}