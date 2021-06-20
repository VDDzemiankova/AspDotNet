using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class CartController : Controller
    {
        CarContext db = new CarContext();
        
        //public static Cart.Cart cart = new Cart.Cart();
        public ActionResult Cart()
        {
           
            return View(GetCart());
        }

        public ActionResult Add(int id)
        {
            
            Car car = db.Cars.Where(a => a.Id == id).FirstOrDefault();
            if(car != null)
            {
                GetCart().AddItem(car, 1);
            }
            return RedirectToAction("Catalog","Catalog");
        }

        public ActionResult Delete(int id)
        {
            Car car = db.Cars.Where(a => a.Id == id).FirstOrDefault();
            if(car != null)
            {
                GetCart().RemoveLine(car);
            }
            return RedirectToAction("Cart", "Cart");
        }

        //[HttpPost]
        //public ActionResult BuyAll()
        //{
        //    //cart.Clear();
        //    return RedirectToAction("Cart", "Cart");
        //}

        public ActionResult ClearAll()
        {
            GetCart().Clear();
            return RedirectToAction("Cart", "Cart");
        }

        public Cart.Cart GetCart()
        {
            Cart.Cart cart = (Cart.Cart)Session["Cart"+User.Identity.Name];
            if(cart == null)
            {
                cart = new Cart.Cart();
                Session["Cart"+User.Identity.Name] = cart;
            }
            return cart;
        }
    }
}