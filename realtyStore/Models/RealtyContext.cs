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
        public DbSet<myUser> Users { get; set; }
        public DbSet<Sold> Sold { get; set; }
        public DbSet<Leased> Leased { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<ApplicationToRealtor> Apps { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<FavoriteRealties> FavoriteRealties { get; set; }
    }
}
