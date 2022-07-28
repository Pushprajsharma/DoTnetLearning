using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;
using WebApplication3.Repository;
using WebApplication3.filter;


namespace WebApplication3.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        IEmployee _employee;
        public EmployeeController(IEmployee employee , ILogger<HomeController> logger)
        {
            _employee = employee;
            _logger = logger;
        }
        public IActionResult Index()
        {
            return View();
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult AllEMployee()
        {
            _logger.LogInformation("All Employee Action is Processed.");
            List<Employee> employee = _employee.GetAllEMployee();
            //List<Employee> lstStudents = new List<Employee>();

            //lstStudents[7].ename = "Scott";

            return View(employee);
        }

        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Details(int id)
        {
            _logger.LogInformation("Details Action is Processed.");
            Employee obj = _employee.GetEmployee(id);
            return View(obj);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create() 
        {
            _logger.LogInformation("Creatw Get Action is Processed.");
            return View();
;        }
        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Create(Employee obj)
        {
            _logger.LogInformation("Create Post Action is Processed.");
            _employee.AddEmployee(obj);
            return RedirectToAction("AllEMployee");
            
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Delete(int id) 
        {
            _logger.LogInformation("Delete Get Action is Processed.");
            Employee employee = _employee.GetEmployee(id);
            return View(employee);
        }

        [HttpPost]
        [ActionName("Delete")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult DeleteEmployee(int id)
        {
            _logger.LogInformation("Delete post Action is Processed.");
            _employee.DeleteEmployee(id);
            return RedirectToAction("AllEMployee");
        }


        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(int id) {
            _logger.LogInformation("Edit get Action is Processed.");
            Employee obj = _employee.GetEmployee(id);
            return View(obj);
        }

        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult Edit(Employee obj)
        {
            _logger.LogInformation("Edit post Action is Processed.");
            _employee.UpdateEmployee(obj);
            return RedirectToAction("AllEMployee");
        }
        [HttpGet]
        public IActionResult employeeByDeptNo(int id) 
        {
            _logger.LogInformation("Employee by dept no get Action is Processed.");
            return View();
        }
        [HttpPost]
        [ActionName("employeeByDeptNo")]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult getAllemployeeByDeptNo(int deptno)
        {
            _logger.LogInformation("Employee by dept no post Action is Processed.");
            IEnumerable<Employee> emplist = _employee.GetEmployeeByDeptNumber(deptno);
            ViewBag.RequestType = Request.Method;
            return View(emplist);
        }

        [HttpGet]
        [TypeFilter(typeof(MyExceptionFilter))]
        public IActionResult employeeByJob(string job)
        {
            return View();
        }
        [HttpPost]
        [TypeFilter(typeof(MyExceptionFilter))]
        [ActionName("employeeByJob")]
        public IActionResult getemployeeByJob(string job)
        {
            IEnumerable<Employee> emplist = _employee.GetEmployeeByJob(job);
            ViewBag.RequestType = Request.Method;
            return View(emplist);
        }





    }
}
