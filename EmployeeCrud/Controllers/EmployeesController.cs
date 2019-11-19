using EmployeeCrud.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmployeeCrud.Controllers
{
    public class EmployeesController : Controller
    {
        EmployeeContext db = new EmployeeContext();

        public ActionResult Index()
        {
            var employees = db.Employee.ToList();
            return View(employees);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}