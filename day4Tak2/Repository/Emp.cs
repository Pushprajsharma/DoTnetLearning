using WebApplication3.Models;
namespace WebApplication3.Repository
{
    public class Emp : IEmployee
    {
        EmployeeDbcontext _context;

        public Emp(EmployeeDbcontext context)
        {
            _context = context;
        }

        public void AddEmployee(Employee obj)
        {
            _context.employees.Add(obj);
            _context.SaveChanges();
        }

        public void DeleteEmployee(int id)
        {
           Employee obj =  _context.employees.Find(id);
           _context.employees.Remove(obj);
            _context.SaveChanges();
        }

        public List<Employee> GetAllEMployee()
        {
            List<Employee> empList = _context.employees.ToList();
            return empList;
        }

        public Employee GetEmployee(int id)
        {
            Employee obj = _context.employees.Find(id);
            return obj;
        }

        public IEnumerable<Employee> GetEmployeeByDeptNumber(int deptno)
        {
          
            IEnumerable<Employee> emplist = _context.employees.Where(item => item.deptno == deptno); 
            return emplist;

        }
        
        public IEnumerable<Employee> GetEmployeeByJob(string job)
        {
          
            IEnumerable<Employee> emplist = _context.employees.Where(item => item.job.Equals(job)); 
            return emplist;

        }

        public void UpdateEmployee(Employee obj)
        {

            _context.employees.Update(obj);
            _context.SaveChanges();

        }
    }
}
