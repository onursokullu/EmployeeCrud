using EmployeeCrud.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
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
       
        public ActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Employee.Add(employee);
                db.SaveChanges();
            }

            return View(employee);
        }
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = db.Employee.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Edit(Employee employee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(employee);
        }
        public ActionResult Detail(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var employee = db.Employee.SingleOrDefault(e => e.EmployeeId == id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }

        public ActionResult Delete(int? id)
        {
            if(id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var employee = db.Employee.SingleOrDefault(e => e.EmployeeId==id);
            if(employee==null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var employee = db.Employee.SingleOrDefault(x => x.EmployeeId == id);
            db.Employee.Remove(employee ?? throw new InvalidOperationException());
            db.SaveChanges();
            return RedirectToAction("Index");
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