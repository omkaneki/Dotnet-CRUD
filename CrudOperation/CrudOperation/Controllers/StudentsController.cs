using CrudOperation.Interface;
using CrudOperation.Models;
using CrudOperation.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CrudOperation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ControllerBase
    {
        private readonly IStudentService _studentService;

        public StudentsController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        // GET: api/<StudentsController>
        [HttpGet]
        public IEnumerable<StudentsDTO> GetAllStudents()
        {
            var students = _studentService.GetAllStudents();
            return students;
        }

        // GET api/<StudentsController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<StudentsController>
        [HttpPost]
        public IActionResult Post(string name, string city, bool Isactive)
        {
            StudentsDTO students = new StudentsDTO { StudentName = name, City = city, IsActive = Isactive };
            if (students == null)
            {
                return BadRequest("Invalid Bad request");
            }
            var student = _studentService.InsertStudents(students);
            return Ok(students);

        }

        // PUT api/<StudentsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<StudentsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
