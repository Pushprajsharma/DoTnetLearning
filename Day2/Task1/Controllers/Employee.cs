using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApplication2.Controllers
{
    public class Employee : Controller
    {
        EmployeeManager manager = new EmployeeManager();
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllEmployee() {
            List<Employees> emp = manager.getEmployee();
            return View(emp);
            
        }
        public IActionResult Details(int id)
        {
            Employees emp = manager.getEmployeeById(id);
            return View(emp);

        }

        [HttpGet]
        public IActionResult create()
        {
           return View();
        }

        [HttpPost]

        public IActionResult create(Employees obj)
        {
            manager.createEmployee(obj);
            return RedirectToAction("AllEmployee");

        }

        public IActionResult Delete(int id) {
            manager.DeleteEmp(id);
            return RedirectToAction("AllEmployee");
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            Employees emp = manager.getEmployeeById(id); 
            return View(emp);
        }

        [HttpPost]

        public IActionResult Edit(Employees obj)
        {
            manager.updateEmployee(obj);
            return RedirectToAction("AllEmployee");

        }


    }
}
