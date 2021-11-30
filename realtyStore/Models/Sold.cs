using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class Sold
    {
        public int Id { get; set; }
        public string RealtyType { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int? RealtorId { get; set; }
        public int OldOwnerId { get; set; }
        public int NewOwnerId { get; set; }
    }
}