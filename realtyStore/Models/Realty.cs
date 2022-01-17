using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class Realty
    {
        public string ImgUrl { get; set; }
        public int Id { get; set; }
        public string Type { get; set; }
        public int? NumberRoom { get; set; }
        public string Address { get; set; }
        public double Square { get; set; }
        public int? Floor { get; set; } //этаж
        public int? Floors { get; set; } //всего этажей
        public string Status { get; set; }
        public int CityId { get; set; }
        public int OwnerId { get; set; }
        public int Price { get; set; }
        public string Description { get; set; }
        public int? RealtorId { get; set; }
        public bool isFavorite { get; set; }
    }
}