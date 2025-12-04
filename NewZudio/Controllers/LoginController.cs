using NewZudio.Models.Login;
using NewZudio.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace NewZudio.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILogin _repo;
        public LoginController(ILogin repo) { _repo = repo; }
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Login(UserMaster obj)
        {
            if (obj.UserID != null && obj.Password != null)
            {
                var list = await _repo.UserLogin(obj);
                if (list.Flag == "success")
                {
                    Session["ID"] = list.Id;
                    Session["Name"] = list.Name;
                    Session["Role"] = list.Role;
                    return RedirectToAction("Dashboard", "Dashboard");
                }
                else
                {
                    TempData["msg"] = list.Flag;
                    return View();
                }
               
            }
            else
                return View();
        }
        public ActionResult Logout()
        {
            Session.Clear();        // Clears all session values
            Session.Abandon();      // Ends the session

            return RedirectToAction("Login", "Login");
        }
    }
}