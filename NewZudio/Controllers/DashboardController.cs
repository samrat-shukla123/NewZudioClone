using NewZudio.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NewZudio.Controllers
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        [Authentication]
        public ActionResult Dashboard()
        {
            return View();
        }
    }
}