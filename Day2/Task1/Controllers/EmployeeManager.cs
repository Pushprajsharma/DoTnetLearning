using Microsoft.AspNetCore.Mvc;

namespace WebApplication3.Controllers
{
    public class EmployeeManager : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Employee()
        {
            return View();
        }

    }
}
