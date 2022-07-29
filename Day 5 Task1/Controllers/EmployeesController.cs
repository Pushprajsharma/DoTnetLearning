using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        employeeDcContext _context;

        public EmployeesController(employeeDcContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmployees()

        {
            var employees = await _context.employees.ToListAsync();

            if (employees.Count > 0)
            {
                return Ok(employees);
            }
            else
            {
                return Ok("No Employee Exist In database");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeesById(int id)

        {
            var employees = await _context.employees.FindAsync(id);

            if (employees != null)
            {
                return Ok(employees);
            }
            else
            {
                return NotFound("No Employee with this id Exist In database");
            }
        }

        [HttpPost]
        public async Task<IActionResult> createEmployee(Employee obj)

        {
            _context.employees.Add(obj);
            _context.SaveChangesAsync();
            return Ok("Employee added");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateEmployee(Employee obj)

        {
            _context.employees.Add(obj);
            _context.SaveChangesAsync();
            return Ok("Employee Updated");
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)

        {
            var obj = await _context.employees.FindAsync(id);
            _context.employees.Remove(obj);
            _context.SaveChangesAsync();
            return Ok("Employee Deleted");
        }


    }
}
