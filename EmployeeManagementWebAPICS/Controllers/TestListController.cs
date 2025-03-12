using EmployeeManagementWebAPICS.Model_Classes;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EmployeeManagementWebAPICS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestListController : ControllerBase
    {
        private static List<Employee> employees;

        public TestListController()
        {
            if (employees == null)
            {


                employees = new List<Employee>();

                employees.Add(new Employee { EmpId = 1, Name = "AB", Age = 20 });
                employees.Add(new Employee { EmpId = 2, Name = "PQ", Age = 22 });
                employees.Add(new Employee { EmpId = 3, Name = "XY", Age = 12 });
            }
        }

        // GET: api/<TestListController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            return employees.ToList();
        }

        // GET api/<TestListController>/5
        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            return employees.FirstOrDefault(e => e.EmpId == id);
        }

        // POST api/<TestListController>
        [HttpPost]
        public void Post(Employee newEmployee)
        {
            employees.Add(newEmployee);
        }

        [HttpPost("{id}/{name}/{age}")]
        public void Post(int id, string name, int age)
        {
            Employee newEmployee = new Employee();
            newEmployee.EmpId = id;
            newEmployee.Name = name;
            newEmployee.Age = age;
            
            employees.Add(newEmployee);
        }

        [HttpGet("salary/{basic}/{da}/{ta}")]
        public double Get(int basic, float da, int ta)
        {
            return basic + (double)basic * (da / 100) + ta;
        }

        // PUT api/<TestListController>/5
        [HttpPut("{id}")]
        public void Put(int id, Employee employeeToEdit)
        {
            Employee employee = GetEmployeeByID(id);

            employee.Age = employeeToEdit.Age;
        }

        private Employee GetEmployeeByID(int id)
        {
            return employees.FirstOrDefault(e => e.EmpId == id);
        }

        // DELETE api/<TestListController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            employees.Remove(GetEmployeeByID(id));
        }
    }
}
