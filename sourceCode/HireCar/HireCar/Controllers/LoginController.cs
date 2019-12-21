using HireCar.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class LoginController : Controller
    {
        
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Autherize(HireCar.Models.user userModel)
        {
            using (HireCarEntities1 db = new HireCarEntities1())
            {
                var user = db.users.Where(e => e.username == userModel.username && e.password == userModel.password).FirstOrDefault();
                if(user==null)
                {
                    userModel.LoginErrorMessage = "Username or Password is not correct";
                    return View("Index", userModel);
                }
                else
                {
                    Session["id"] = user.id;
                    return RedirectToAction("Index", "Home");
                }
            }
        }
    }
}