using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace realtyStore.Models
{
    public class myUser
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Patronymic { get; set; }
        public string Phone { get; set; }
        public string Passport { get; set; }
        public string Address { get; set; }
        public string LogIn { get; set; }
        public string Password { get; set; }
        public int CityId { get; set; }
        public int? RoleId { get; set; }
    }

   // public class Users: User {}

}