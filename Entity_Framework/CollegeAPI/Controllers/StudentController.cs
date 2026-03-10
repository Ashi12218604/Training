using CollegeAPI.DTOs;
using CollegeAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudentController : ControllerBase
    {
        private readonly IStudentService _service;

        public StudentController(IStudentService service)
        {
            _service = service;
        }

        // Admission
        [HttpPost("admission")]
        public IActionResult AddStudent(StudentAdmissionDTO dto)
        {
            var student = _service.AddStudent(dto);
            return Ok(student);
        }

        // Update Room
        [HttpPut("update-room")]
        public IActionResult UpdateRoom(UpdateRoomDTO dto)
        {
            var hostel = _service.UpdateRoom(dto);

            if (hostel == null)
                return NotFound();

            return Ok(hostel);
        }

        // Delete Student
        [HttpDelete("delete/{id}")]
        public IActionResult DeleteStudent(int id)
        {
            var result = _service.DeleteStudent(id);

            if (!result)
                return NotFound();

            return Ok("Student deleted");
        }

        // Hostel Students
        [HttpGet("hostel-students")]
        public IActionResult GetHostelStudents()
        {
            return Ok(_service.GetHostelStudents());
        }

        // All College Students
        [HttpGet("all-students")]
        public IActionResult GetAllStudents()
        {
            return Ok(_service.GetAllStudents());
        }
    }
}