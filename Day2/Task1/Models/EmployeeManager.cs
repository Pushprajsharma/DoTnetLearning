namespace WebApplication2.Models
{
    public class EmployeeManager
    {
        public static List<Employees> empList = new List<Employees>();

        public EmployeeManager() {
            empList = new List<Employees>()
                {
            new Employees () {Id = 1 , Name = "John" , job="CEO" , location="Pune" , salary = 20000},
            new Employees () {Id = 2 , Name = "Rock" , job="Sales" , location="Pune" , salary = 40000},
            new Employees () {Id = 3 , Name = "Kevinn" , job="Marketing" , location="Pune" , salary = 30000},
            new Employees () {Id = 4 , Name = "Mathew" , job="Pre sales" , location="Pune" , salary = 70000},
        };
        }


        public List<Employees> getEmployee() {
            return empList;  
        }

        public Employees getEmployeeById(int id)
        {
            Employees myObj = empList.Find(item => item.Id == id);
            return myObj;
        }

        public void createEmployee(Employees obj) {
            empList.Add(obj);
        }
        public void updateEmployee(Employees obj) {
            Employees a = empList.Find(item => item.Id == obj.Id);
            empList.Remove(a);
            empList.Add(obj);
        }

        public void DeleteEmp(int id) { 
            Employees obj = empList.Find(item => item.Id == id);
            empList.Remove(obj);
        }


    }
}
