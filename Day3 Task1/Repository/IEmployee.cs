using WebApplication3.Models;
namespace WebApplication3.Repository
{
    public interface IEmployee
    {
        List<Employee> GetAllEMployee();
        Employee GetEmployee(int id);

        public void AddEmployee(Employee obj);
        public void DeleteEmployee(int id);

        public void UpdateEmployee(Employee obj);
    }
}
