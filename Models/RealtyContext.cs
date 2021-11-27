using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace realtyStore.Models
{
    public class RealtyContext : DbContext
    {
        public DbSet<Realty> Realties { get; set; }
        public DbSet<Buyer> Buyers { get; set; }
        public DbSet<Realtor> Realtors { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Sold> Sold { get; set; }
        public DbSet<Leased> Leased { get; set; }
        public DbSet<City> Cities { get; set; }

    }
}
