using CrudOperation.Interface;
using CrudOperation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        // GET: api/<EmployeesController>
        [HttpGet]
        public IEnumerable<Employee> Get()
        {
            var employees =_employeeService.GetAllEmployees();
            return employees;
        }

        // GET api/<EmployeesController>/5
        [HttpGet("{Id}")]
        public Employee Get(int Id)
        {
            var employees = _employeeService.GetEmpById(Id);
            return employees;
        }

        // POST api/<EmployeesController>
        [HttpPost]
        public IActionResult Post(string name, int age)
        {
            Employee employee = new Employee{Name = name, Age = age};
            if (employee == null)
            {
                return BadRequest("Invalid Bad request");
            }
            var employees = _employeeService.AddEmployee(employee);
            return Ok(employees);

        }

        // PUT api/<EmployeesController>/5
        [HttpPut("{id}")]
        public void Put(int id,string name, int age)
        {
            Employee employee = new Employee {Id=id, Name = name, Age = age};
            var employees = _employeeService.UpdateEmployee(employee);
            
        }

        // DELETE api/<EmployeesController>/5
        [HttpDelete("{Id}")]
        public int Delete(int Id)
        {
            var employees = _employeeService.DeleteEmployee(Id);
            return Id;
        }
    }
}
