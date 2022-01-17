using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace realtyStore.Models
{

    public class Register
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FirstName { get; set; }
        
        [Required]
        public string LastName { get; set; }
        
        public string Patronymic { get; set; }
        
        [Required]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        
        public string Address { get; set; }
        
        [Required]
        public int CityId { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        public string ConfirmPassword { get; set; }
    }
}