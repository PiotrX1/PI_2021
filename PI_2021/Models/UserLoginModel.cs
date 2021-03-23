using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Models
{
    public class UserLoginModel
    {

        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        
    }
}
