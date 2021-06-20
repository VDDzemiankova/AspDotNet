using ASPLabs2_4.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ASPLabs2_4.App_Start
{
    public class CarsDbInitializer : CreateDatabaseIfNotExists<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            Category category1 = new Category { Name = "Кроссовер" };
            Category category2 = new Category { Name = "Спортивный автомобиль" };
            Category category3 = new Category { Name = "С-класс" };
            Category category4 = new Category { Name = "Е-класс" };

            db.Categories.Add(category1);
            db.Categories.Add(category2);
            db.Categories.Add(category3);
            db.Categories.Add(category4);

            db.Cars.Add(new Car { Name = "Peugeut 2008", Maker = "PSA", ImagePath = "/Pictures/1.jpg", Brand = "Peugeut", Price = 54810, Category=category1 });
            db.Cars.Add(new Car { Name = "Audi A5", Maker = "Volkswagen Group", ImagePath = "/Pictures/2.jpg", Brand = "Audi AG", Price = 42792, Category = category2 });
            db.Cars.Add(new Car { Name = "Kia Sorento", Maker = "Hyundai KIA Automotive Group", ImagePath = "/Pictures/3.jpeg", Brand = "Kia Motors Corporation", Price = 79779, Category = category1 });
            db.Cars.Add(new Car { Name = "BMW X5", Maker = "BMW AG", ImagePath = "/Pictures/4.jpg", Brand = "BMW AG", Price = 191186, Category = category1 });
            db.Cars.Add(new Car { Name = "Skoda Octavia", Maker = "Volkswagen Group", ImagePath = "/Pictures/5.jpg", Brand = "Skoda Auto", Price = 36305, Category = category3 });
            db.Cars.Add(new Car { Name = "Toyota Camry", Maker = "PSA", ImagePath = "/Pictures/6.jpg", Brand = "Toyota Motor Corporation", Price = 36305, Category = category4 });
            db.Cars.Add(new Car { Name = "Hyundai Creta", Maker = "Hyundai KIA Automotive Group", ImagePath = "/Pictures/7.jpg", Brand = "Hyundai", Price = 53900, Category = category1 });


            db.Suppliers.Add(new Supplier { Name = "Лори", Country = "Россия" });
            db.Suppliers.Add(new Supplier { Name = "Mack", Country = "США" });
            db.Suppliers.Add(new Supplier { Name = "Clatcher", Country = "Канада" });

            db.Deliveries.Add(new Delivery { NameOfProduct = "PSA", Count = 30 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "BMW", Count = 70 });
            db.Deliveries.Add(new Delivery { NameOfProduct = "Volkswagen", Count = 50 });

            base.Seed(db);
        }
    }
}