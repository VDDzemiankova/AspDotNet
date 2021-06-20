using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace ASPLabs2_4.Controllers
{
    public class CatalogController : Controller
    {
        CarContext db = new CarContext();

        public ActionResult Catalog(string searchString, string sort)
        {
            List<Car> cars = db.Cars.ToList();

            if (!string.IsNullOrEmpty(searchString))
            {
                cars = Search(searchString);
            }

            if (!string.IsNullOrEmpty(sort))
            {
                if (sort == "Имя")
                {
                    cars = db.Cars.OrderBy(a=>a.Name).ToList();
                }
                else if (sort == "Производитель")
                {
                    cars = db.Cars.OrderBy(a => a.Maker).ToList();
                }
                else if (sort == "Цена")
                {
                    cars = db.Cars.OrderBy(a => a.Price).ToList();
                }
            }

            return View(cars);
        }

        [HttpGet]
        public ActionResult Buy(int? id)
        {
            ViewBag.CarId = id;
            return View();
        }

        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            Cart.Cart cart = (Cart.Cart)Session["Cart" + User.Identity.Name];
            if (cart!= null && cart.Lines.Count() > 0)
            {
                foreach (var item in cart.Lines)
                {
                    purchase.CarId = item.Car.Id;
                    for (int i = 0; i < item.Quantity; i++)
                    {
                        db.Purchases.Add(purchase);
                        db.SaveChanges();
                    }
                }
                PurchCartViewModel purchCartViewModel = new PurchCartViewModel { Purchase = purchase, Count = cart.Lines.Count() };
                cart.Clear();
                return View("BoughtAll", purchCartViewModel);
            }
            else
            {
                db.Purchases.Add(purchase);
            }
            db.SaveChanges();
            return RedirectToAction("Bought", purchase);
        }

        [HttpGet]
        public ActionResult Bought(Purchase purchase)
        {
            return View(purchase);
        }

        private List<Car> Search(string searchString)
        {
            var predicate = PredicateBuilder.New<Car>(e => false);


            Category category = db.Categories.FirstOrDefault(a => a.Name == searchString);

            if (category != null)
            {
                predicate.Or(a => a.CategoryId == category.Id);
            }
            predicate.Or(a => a.Name == searchString);
            predicate.Or(a => a.Maker == searchString);
            if (Int32.TryParse(searchString, out int result1))
            {
                predicate.Or(a => a.Price == result1);
            }
            predicate.Or(a => a.Brand == searchString);

            return new List<Car>(db.Cars.Where(predicate));

        }
    }
}