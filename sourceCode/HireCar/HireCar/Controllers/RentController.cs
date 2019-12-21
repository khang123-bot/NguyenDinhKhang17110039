using HireCar.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HireCar.Controllers
{
    public class RentController : Controller
    {
        HireCarEntities1 db = new HireCarEntities1();
        // GET: Rent
        public ActionResult Index()
        {
            var result = (from rs in db.rents
                          join c in db.cars on rs.carid equals c.carNumber
                          select new RentViewModel
                          {
                              id = rs.id,
                              carid = rs.carid,
                              customerid = rs.customerid,
                              fee = rs.fee,
                              sdate = rs.sdate,
                              edate = rs.edate,
                              available = c.available
                          }).ToList();



            return View(result);
        }

        [HttpGet]
        public ActionResult getCar()
        {
            var car = db.cars.ToList();
            return Json(car, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getid(int id)
        {
            var customer = (from s in db.customers where s.id == id select s.customerName).ToList();
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Getavil(String carid)
        {
            var carvil = (from s in db.cars where s.carNumber == carid select s.available).FirstOrDefault();
            return Json(carvil, JsonRequestBehavior.AllowGet);
        }



        [HttpPost]
        public ActionResult Save(rent rent)
        {
            if(ModelState.IsValid)
            {
                db.rents.Add(rent);
                var car = db.cars.SingleOrDefault(e => e.carNumber == rent.carid);
                if(car==null)
                    return HttpNotFound("Your car number is not valid!!!");
                car.available = "no";
                db.Entry(car).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(rent);
        }

    }
}