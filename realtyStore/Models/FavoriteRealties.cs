using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class FavoriteRealties
    {
        public int Id { get; set; } 
        public int UserId { get; set; }
        public int RealtyId { get; set; }
    }
}