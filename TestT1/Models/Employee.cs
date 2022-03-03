using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TestT1.Models
{
    public class Employee
    {
        public int ID { get; set; }
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

        public int? DepartmentID { get; set; }
        public int? DesignationID { get; set; }
        public int? RoleID { get; set; }

        //Navigations

        public Role Role { get; set; }
        public Department Department { get; set; }
        public Designation Designation { get; set; }
    }
}
