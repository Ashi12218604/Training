using CollegeAPI.DTOs;
using CollegeAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.Services
{
    public class StudentService : IStudentService
    {
        private readonly CollegeDbContext _context;

        public StudentService(CollegeDbContext context)
        {
            _context = context;
        }

        // Add Student + Assign Hostel
        public StudentsT AddStudent(StudentAdmissionDTO dto)
        {
            StudentsT student = new StudentsT
            {
                Name = dto.Name,
                Age = dto.Age
            };

            _context.StudentsTs.Add(student);
            _context.SaveChanges(); // generate StudentId

            Hostel hostel = new Hostel
            {
                StudentId = student.StudentIdNum,
                RoomNumber = dto.RoomNumber
            };

            _context.Hostels.Add(hostel);
            _context.SaveChanges();

            return student;
        }

        // Update Hostel Room
        public Hostel? UpdateRoom(UpdateRoomDTO dto)
        {
            var hostel = _context.Hostels
                .FirstOrDefault(x => x.StudentId == dto.StudentId);

            if (hostel == null)
                return null;

            hostel.RoomNumber = dto.RoomNumber;

            _context.Hostels.Update(hostel);
            _context.SaveChanges();

            return hostel;
        }

        // Delete Student + Hostel
        public bool DeleteStudent(int studentId)
        {
            var student = _context.StudentsTs
                .FirstOrDefault(x => x.StudentIdNum == studentId);

            if (student == null)
                return false;

            var hostel = _context.Hostels
                .FirstOrDefault(x => x.StudentId == studentId);

            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
            }

            _context.StudentsTs.Remove(student);

            _context.SaveChanges();

            return true;
        }

        // Get All Hostel Records
        public List<Hostel> GetHostelStudents()
        {
            return _context.Hostels
                .Include(h => h.Student)
                .ToList();
        }

        // Get All College Students
        public List<StudentsT> GetAllStudents()
        {
            return _context.StudentsTs.ToList();
        }
    }
}