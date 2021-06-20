using KASPLab1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace KASPLab1.App_Start
{
    public class CarsDbInitializer : DropCreateDatabaseAlways<CarContext>
    {
        protected override void Seed(CarContext db)
        {
            db.Cars.Add(new Car { Name = "Peugeut 2008", Maker = "PSA", Brand = "Peugeut", Price = 54810 });
            db.Cars.Add(new Car { Name = "Audi A5", Maker = "Volkswagen Group", Brand = "Audi AG", Price = 42792 });
            db.Cars.Add(new Car { Name = "Kia Sorento", Maker = "Hyundai KIA Automotive Group", Brand = "Kia Motors Corporation", Price = 79779 });
            db.Cars.Add(new Car { Name = "BMW X5", Maker = "BMW AG", Brand = "BMW AG", Price = 191186 });
            db.Cars.Add(new Car { Name = "Skoda Octavia", Maker = "Volkswagen Group", Brand = "Skoda Auto", Price = 36305 });
            db.Cars.Add(new Car { Name = "Toyota Camry", Maker = "PSA", Brand = "Toyota Motor Corporation", Price = 65448 });
            db.Cars.Add(new Car { Name = "Hyundai Creta", Maker = "Hyundai KIA Automotive Group", Brand = "Hyundai", Price = 53900 });
            base.Seed(db);
        }
    }
}