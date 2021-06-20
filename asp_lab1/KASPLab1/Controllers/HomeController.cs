using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KASPLab1.Controllers
{
    public class HomeController : Controller
    {
        CarContext db = new CarContext();
        public ActionResult Index()
        {
            IEnumerable<Car> cars = db.Cars;
            ViewBag.Cars = cars;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо за покупку, " + purchase.Person + "!";
        }
    }
}