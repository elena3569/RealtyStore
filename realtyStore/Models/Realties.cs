using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    abstract public class Realties
    {
        public int Id { get; set; }
        public string RealtyType { get; set; }
        public int CityId { get; set; }
        public string Address { get; set; }
        public string Date { get; set; }
        public int Price { get; set; }
        public int? RealtorId { get; set; }
        public int OwnerId { get; set; }
        public int BuyerId { get; set; }
    }

    public class Leased: Realties {
        public string Status { get; set; }
        public int RealtyId { get; set; }
        public string DateCheckOut { get; set; }

    }
    public class Sold: Realties {}
}