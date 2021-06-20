using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab5WebApi.Models
{
    public class StationeryInitializer : DropCreateDatabaseAlways<StationeryContext>
    {

        protected override void Seed(StationeryContext db)
        {
            db.StationerySet.Add(new Stationery
            {
                Id = 1,
                Name = "Pencil",
                Producer = "PencilFactory",
                Price = 0.05m,
                Image = "pencil.png",
                SellDate = DateTime.Now
            });
            db.StationerySet.Add(new Stationery
            {
                Id = 2,
                Name = "Pen",
                Producer = "PenFactory",
                Price = 0.08m,
                Image = "pen.jpg",
                SellDate = DateTime.Now

            });
            base.Seed(db);
        }
    }
}