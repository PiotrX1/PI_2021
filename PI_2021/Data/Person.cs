using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PI_2021.Models
{
    [Table("People")]
    public class Person
    {
        [Key]
        public int PersonID { get; set; }
        [MaxLength(100)]
        public string FirstName { get; set; }
        [MaxLength(100)]
        public string LastName { get; set; }
        public char Gender { get; set; }
        public int Age { get; set; }
        public string Description { get; set; }
        [MaxLength(100)]
        public string Picture { get; set; }
        [MaxLength(100)]
        public string City { get; set; }
    }
}
