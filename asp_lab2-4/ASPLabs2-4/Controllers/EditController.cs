using ASPLabs2_4.Models;
using ASPLabs2_4.ViewModels;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASPLabs2_4.Controllers
{
    public class EditController : Controller
    {
        CarContext db = new CarContext();
        public ActionResult Edit(int? categoryId, string? maker)
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();

            categoryModels.Insert(0, new CategoryModel { Id = 0, Name = "Все" });

            IndexViewModel indexViewModel = new IndexViewModel() { Categories = categoryModels, Cars = db.Cars.ToList() };

            if (categoryId != null && categoryId > 0)
                indexViewModel.Cars = indexViewModel.Cars.Where(p => p.Category.Id == categoryId);
            if (maker != null && maker.Length > 0 && maker != "Все")
                indexViewModel.Cars = indexViewModel.Cars.Where(p => p.Maker == maker);
            
            return View(indexViewModel);
        }

        [HttpGet]
        public ActionResult Add()
        {
            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            CarCategViewModel carCategViewModel = new CarCategViewModel() { Categories = categoryModels };
            return View(carCategViewModel);
        }

        [HttpPost]
        public ActionResult Add(Car car, HttpPostedFileBase upload, int categoryId)
        {
            if (upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                car.ImagePath = path;
                car.Category = db.Categories.First(a=>a.Id == categoryId);
                db.Cars.Add(car);
                db.SaveChanges();

            }
            return RedirectToAction("Edit");
        }

        [HttpGet]
        public ActionResult Back()
        {
            return RedirectToAction("Edit");
        }
        
        [HttpGet]
        public ActionResult Info(int id)
        {
            Car car = db.Cars.Include(a=>a.Category).First(a => a.Id == id);
            return View(car);
        }

        [HttpGet]
        public ActionResult Editor(int id)
        {
            ViewBag.CarId = id;
            Car car = db.Cars.FirstOrDefault(a => a.Id == id);

            List<CategoryModel> categoryModels = db.Categories.ToList().Select(c => new CategoryModel { Id = c.Id, Name = c.Name }).ToList();
            CarCategViewModel carCategViewModel = new CarCategViewModel() { Car=car, Categories = categoryModels };
            return View(carCategViewModel);
        }

        [HttpPost]
        public ActionResult Editor(Car car, HttpPostedFileBase upload, int categoryId)
        {
            Car carOld = db.Cars.FirstOrDefault(a => a.Id == car.Id);
            carOld.Name = car.Name;
            carOld.Maker= car.Maker;
            if(upload != null)
            {
                string path = "/Pictures/" + upload.FileName;
                upload.SaveAs(Server.MapPath(path));
                carOld.ImagePath = path;
               
            }
            carOld.Price = car.Price;
            carOld.Brand = car.Brand;
            carOld.Category = db.Categories.First(a => a.Id == categoryId);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            ViewBag.CarId = id;
            Car car = db.Cars.FirstOrDefault(a=>a.Id == id);
            return View(car);
        }

        [HttpPost]
        public ActionResult DeleteConfirmed(int id)
        {
            var car = db.Cars.First(b => b.Id == id);
            db.Cars.Remove(car);
            db.SaveChanges();
            return RedirectToAction("Edit");
        }
    }
}