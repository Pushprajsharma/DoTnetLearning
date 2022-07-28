using Microsoft.EntityFrameworkCore;

namespace WebApplication3.Models
{
    public class Employee
    {
        public int Id { get; set;  }

        public string ename { get; set;  }
        public string job { get; set; }
        public int salary { get; set; }

        public int deptno { get; set; }
    }

    public class EmployeeDbcontext : DbContext
    { 
        public DbSet<Employee> employees { get; set; }

        public EmployeeDbcontext(DbContextOptions<EmployeeDbcontext> options) : base(options) 
        {

        }
    }
}
