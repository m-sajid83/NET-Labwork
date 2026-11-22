using Microsoft.AspNetCore.Mvc;
using DOT_NET_lab_10.Model;

namespace DOT_NET_lab_10.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        // In-memory data. Changes reset when the application is restarted.
        private static readonly List<Student> students = new()
        {
            new Student { Id = 1, Name = "Sajid", Branch = "Computer Engineering", Class = "5th Semester" },
            new Student { Id = 2, Name = "Ravan", Branch = "Computer Engineering", Class = "5th Semester" }
        };

        private static int nextId = 5;

        // GET: api/Student
        [HttpGet]
        public IActionResult GetStudents()
        {
            return Ok(students);
        }

        // GET: api/Student/1
        [HttpGet("{id}")]
        public IActionResult GetStudentById(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            return Ok(student);
        }

        // POST: api/Student
        [HttpPost]
        public IActionResult AddStudent(Student student)
        {
            student.Id = nextId++;
            students.Add(student);
            return Ok("Student added successfully");
        }

        // PUT: api/Student/1
        [HttpPut("{id}")]
        public IActionResult UpdateStudent(int id, Student student)
        {
            var existingStudent = students.FirstOrDefault(s => s.Id == id);
            if (existingStudent == null)
                return NotFound("Student not found");

            existingStudent.Name = student.Name;
            existingStudent.Branch = student.Branch;
            existingStudent.Class = student.Class;

            return Ok("Student updated successfully");
        }

        // DELETE: api/Student/1
        [HttpDelete("{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var student = students.FirstOrDefault(s => s.Id == id);
            if (student == null)
                return NotFound("Student not found");

            students.Remove(student);
            return Ok("Student deleted successfully");
        }
    }
}
