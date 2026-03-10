using Microsoft.AspNetCore.Mvc;
using StudentAPI.Models;
using StudentAPI.DTOs;

namespace StudentAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {

        static List<Student> students = new List<Student>();

        // CREATE STUDENT
        [HttpPost("create")]
        public IActionResult CreateStudent(CreateStudentDTO dto)
        {
            Student s = new Student
            {
                Id = dto.Id,
                Name = dto.Name,
                Age = dto.Age
            };

            students.Add(s);

            return Ok("Student Created");
        }


        // UPDATE MARKS
        [HttpPut("update")]
        public IActionResult UpdateMarks(UpdateMarksDTO dto)
        {
            var student = students.FirstOrDefault(x => x.Id == dto.Id);

            if (student == null)
                return NotFound("Student not found");

            student.M1 = dto.M1;
            student.M2 = dto.M2;

            return Ok("Marks Updated");
        }


        // GET RESULT
        [HttpGet("result/{id}")]
        public IActionResult GetResult(int id)
        {
            var student = students.FirstOrDefault(x => x.Id == id);

            if (student == null)
                return NotFound();

            int total = student.M1 + student.M2;

            string grade;

            if (total >= 180)
                grade = "A";
            else if (total >= 150)
                grade = "B";
            else if (total >= 120)
                grade = "C";
            else
                grade = "Fail";

            StudentResultDTO result = new StudentResultDTO
            {
                Id = student.Id,
                Name = student.Name,
                M1 = student.M1,
                M2 = student.M2,
                Total = total,
                Grade = grade
            };

            return Ok(result);
        }
    }
}