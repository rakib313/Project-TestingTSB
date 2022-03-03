using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestT1.Data;
using TestT1.Models;

namespace TestT1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly AppDBContext _context;
        public EmployeeController(AppDBContext context)
        {
            _context = context;
        }
        // GET: EmployeeController
        public ActionResult Index(string searchString)
        {
            //var employee = from s in _context.Employees
            //               select s;;
            ViewData["CurrentFilter"] = searchString;
            var employees = _context.Employees
                .Include(e => e.Department)
                .Include(e => e.Designation)
                .Include(e => e.Role)
                .ToList();
            if (!String.IsNullOrEmpty(searchString))
            {
                 employees = _context.Employees.Where(s => s.LastName.Contains(searchString.ToUpper())
                                       || s.FirstName.ToUpper().Contains(searchString.ToUpper())
                                       || s.Designation.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Department.Name.ToUpper().Contains(searchString.ToUpper())
                                       || s.Role.Name.ToUpper().Contains(searchString.ToUpper())).ToList();
            }
            //var employee = _context.Employees
            //    .Include(e => e.Department)
            //    .Include(e => e.Designation)
            //    .Include(e => e.Role)
            //    .ToList();

            return View(employees);
        }

        public JsonResult GetEmployees(string searchStr)
        {
            var result = _context.Employees.Where(m => m.FirstName.Contains(searchStr)).ToList();
            //var res = result.Select(
            var json = JsonConvert.SerializeObject(result);
            return Json(json);
        }

        // GET: EmployeeController/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Employee employee = _context.Employees
                            .Include(d => d.Department)
                            .Include(d => d.Designation)
                            .Include(r => r.Role)
                            .FirstOrDefault(m => m.ID == id);

            if (employee == null)
            {
                return NotFound();
            }


            return View(employee);
        }

        // GET: EmployeeController/Create
        public ActionResult Create()
        {
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Designations = _context.Designations.ToList();
            ViewBag.Roles = _context.Roles.ToList();
            return View();
        }

        // POST: EmployeeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Employee employee)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
            }
            catch (DbUpdateException /* ex */)
            {
                ModelState.AddModelError("", "Unable to save changes. " +
                    "Try again, and if the problem persists " +
                    "see your system administrator.");
            }

            return View(employee);
        }

        // GET: EmployeeController/Edit/5
        public ActionResult Edit(int? id)
        {
            ViewBag.Departments = _context.Departments.ToList();
            ViewBag.Designations = _context.Designations.ToList();
            ViewBag.Roles = _context.Roles.ToList();

            if (id == null)
            {
                return NotFound();
            }

            var employee = _context.Employees
                                    .Include(d => d.Designation)
                                    .Include(d => d.Department)
                                    .Include(r => r.Role)
                                    .FirstOrDefault(s=>s.ID == id);
            if (employee == null)
            {
                return NotFound();
            }

            return View(employee);
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Employee employee)
        {
            if (id != employee.ID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(employee);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                catch (DbUpdateException /*ex*/)
                {
                    //Log the error (uncomment ex variable name and write a log.)
                    ModelState.AddModelError("", "Unable to save changes. " +
                        "Try again, and if the problem persists, " +
                        "see your system administrator.");
                }
            }
            return View(employee);
        }

        // GET: EmployeeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
