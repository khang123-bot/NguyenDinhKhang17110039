using HireCar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.SqlServer;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class returncarController : Controller
    {
        HireCarEntities1 db = new HireCarEntities1();
        // GET: returncar
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Save(returncar ret)
        {
            if(ModelState.IsValid)
            {
                db.returncars.Add(ret); 
                var car = db.cars.SingleOrDefault(e => e.carNumber == ret.carno);

                if(car==null)
                
                    return HttpNotFound("Car Number Not Found!");
                car.available = "yes";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
                
            }

            return View(ret);
        }

        [HttpPost]
        public ActionResult Getid(String carno)
        {
            var car = (from s in db.rents
                       where s.carid == carno
                       select new
                       {
                           StartDate = s.sdate,
                           EndDate = s.edate,
                           Custid = s.customerid,
                           CarNo = s.carid,
                           Fee = s.fee,
                           ElapsedDays = SqlFunctions.DateDiff("day", s.edate, DateTime.Now)
                       }).ToArray();

            return Json(car, JsonRequestBehavior.AllowGet);
        }


    }
}