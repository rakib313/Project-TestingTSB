using TestT1.Models;
using System;
using System.Linq;

namespace TestT1.Data
{
    public static class DbInitializer
    {
        public static void Initialize(AppDBContext context)
        {
            context.Database.EnsureCreated();

            // Look for any departments.
            if (context.Departments.Any())
            {
                return;   // DB has been seeded
            }

            var departments = new Department[]
            {
                new Department{Name = "IT"},
                new Department{Name = "Marchandizing"},
                new Department{Name = "Development"}
            };
            foreach (Department d in departments)
            {
                context.Departments.Add(d);
            }
            context.SaveChanges();

            // Look for any designation.
            if (context.Designations.Any())
            {
                return; // DB has been seeded
            }

            var designations = new Designation[]
            {
                new Designation{Name = "Designer"},
                new Designation{Name = "SQA"},
                new Designation{Name = "Developer"}
            };
            foreach (Designation item in designations)
            {
                context.Designations.Add(item);
            }
            context.SaveChanges();

            // Look for any employees
            if (context.Employees.Any())
            {
                return;
            }

            var employees = new Employee[]
            {
                new Employee{FirstName = "Rakibul", LastName = "Islam", Address = "Motijheel", Email = "Rakib@gmail.com", MobileNumber = "01886616447", DepartmentID = 2, DesignationID = 1},
                new Employee{FirstName = "Srabon", LastName = "Ahmed", Address = "Mirpur", Email = "Srabon@gmail.com", MobileNumber = "01674585822"},
                new Employee{FirstName = "Fahim", LastName = "Ferdows", Address = "Uttara", Email = "Fahim@gmail.com", MobileNumber = "01754456458"}
            };
            foreach (Employee item in employees)
            {
                context.Employees.Add(item);
            }
            context.SaveChanges();

            // Look for any roles
            if (context.Roles.Any())
            {
                return;
            }

            var roles = new Role[]
            {
                new Role{Name = "Admin"},
                new Role{Name = "User"}
            };
            foreach (var item in roles)
            {
                context.Roles.Add(item);
            }
            context.SaveChanges();
        }
    }
}