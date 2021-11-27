﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class ApplicationToRealtor
    {
        public int Id { get; set; }
        public string Status { get; set; }
        public string RealtyType { get; set; }
        public int Price { get; set; }
        public double Square { get; set; }
        public int CityId { get; set; }
        public string Phone { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Patronymic { get; set; }

    }
}
