using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class Employee
    {

        public int Id { get; set; }

        public string name { get; set; }
        public string job { get; set; }
        public int salary { get; set; }

        public int deptNo { get; set; }
    }

    public class employeeDcContext : DbContext
    {
        public DbSet<Employee> employees { get; set; }
        public employeeDcContext(DbContextOptions<employeeDcContext> options) : base(options)
        {

        }

    }
}
