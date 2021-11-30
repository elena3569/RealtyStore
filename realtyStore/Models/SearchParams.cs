using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class SearchParams
    {
        public string RealtyType { get; set; }
        public string[] NumberRooms { get; set; }
        public double? MinSquare { get; set; }
        public double? MaxSquare { get; set; }
        public int CityId { get; set; }
        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

    }
}