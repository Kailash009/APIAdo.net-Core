using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MYAPI.Models;

namespace MYAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {

        [HttpGet]
        public List<Employee> GetEmployees()
        {
            List<Employee> empList = new List<Employee>()
            {
                new Employee{Eid=101,Name="Rohit",Age=23,City="Noida",Salary=67863.34,Post="SE"},
                new Employee{Eid=102,Name="Suresh",Age=24,City="Banglore",Salary=37863.34,Post="Manager"},
                new Employee{Eid=103,Name="Mahesh",Age=25,City="Delhi",Salary=77863.34,Post="TL"},
                new Employee{Eid=104,Name="Dinesh",Age=26,City="Chennai",Salary=17863.34,Post="HR"},
                new Employee{Eid=105,Name="Javed",Age=27,City="Lucknow",Salary=27863.34,Post="Sales"},
            };
            return empList;
        }

        [HttpGet("{id}")]
        public int GetEmployee(int id)
        {
            return id;
        }
        [HttpPost]
        public string Create()
        {
            return "Employee Created SuccessFully!!";
        }
        [HttpPut]
        public string Update()
        {
            return "Employee Updated SuccessFully!!";
        }
        [HttpDelete]
        public string Delete()
        {
            return "Employee Deleted SuccessFully!!";
        }

        [HttpPatch]
        public string PartialUpdate()
        {
            return "Employee updated Partially!";
        }

    }
}
