using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeSite.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Display(Name = "Name")]
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public DateTime HiredDate { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }
        public bool Gender { get; set; }
        public string Role { get; set; }
        public string Email { get; set; }


    }
}
