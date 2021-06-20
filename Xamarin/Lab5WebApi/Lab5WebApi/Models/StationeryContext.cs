using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Lab5WebApi.Models
{
    public class StationeryContext : DbContext
    {
        public DbSet<Stationery> StationerySet { get; set; }
    }
}