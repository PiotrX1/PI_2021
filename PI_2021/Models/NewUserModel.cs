using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Models
{
    public class NewUserModel
    {
        [Required(ErrorMessage = "Nazwa użytkownika jest wymagana")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Hasło jest wymagane")]
        public string Password { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
