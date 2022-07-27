using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;
namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        IEmployee _employee;
        public EmployeeController(IEmployee employee)
        {
            _employee = employee;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllEMployee()
        {
            List<Employee> employee = _employee.GetAllEMployee();
            return View(employee);
        }

        public IActionResult Details(int id)
        {
            Employee obj = _employee.GetEmployee(id);
            return View(obj);
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
;        }
        [HttpPost]
        public IActionResult Create(Employee obj)
        {
            _employee.AddEmployee(obj);
            return RedirectToAction("AllEMployee");
            
        }

        [HttpGet]
        public IActionResult Delete(int id) 
        {
            Employee employee = _employee.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]

        public IActionResult DeleteEmployee(int id)
        {
            _employee.DeleteEmployee(id);
            return RedirectToAction("AllEMployee");
        }


        [HttpGet]

        public IActionResult Edit(int id) {
            Employee obj = _employee.GetEmployee(id);
            return View(obj);
        }

        [HttpPost]
        public IActionResult Edit(Employee obj)
        {
            _employee.UpdateEmployee(obj);
            return RedirectToAction("AllEMployee");
        }



    }
}
