using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TestT1.Models;

namespace TestT1.ViewModels
{
    public class CreateEmployeeViewModel
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Address { get; set; }

        [Display(Name = "Email address")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

        [Display(Name = "Mobile Number:")]
        [Required(ErrorMessage = "Mobile Number is required.")]

        public string MobileNumber { get; set; }

        public ICollection<Department> Departments { get; set; }
        public ICollection<Designation> Designations { get; set; }


    }
}
