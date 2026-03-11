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

            // Save student first
            _context.StudentsTs.Add(student);
            _context.SaveChanges();

            // Create hostel record
            Hostel hostel = new Hostel
            {
                StudentId = student.StudentIdNum,
                RoomNumber = dto.RoomNumber,
                RoomType = dto.RoomType
            };

            _context.Hostels.Add(hostel);
            _context.SaveChanges();

            return student;
        }

        // Update Room + RoomType
        public Hostel? UpdateRoom(UpdateRoomDTO dto)
        {
            var hostel = _context.Hostels
                .FirstOrDefault(h => h.StudentId == dto.StudentId);

            if (hostel == null)
                return null;

            hostel.RoomNumber = dto.RoomNumber;
            hostel.RoomType = dto.RoomType;

            _context.Hostels.Update(hostel);
            _context.SaveChanges();

            return hostel;
        }

        // Delete Student + Hostel
        public bool DeleteStudent(int studentId)
        {
            var student = _context.StudentsTs
                .FirstOrDefault(s => s.StudentIdNum == studentId);

            if (student == null)
                return false;

            var hostel = _context.Hostels
                .FirstOrDefault(h => h.StudentId == studentId);

            if (hostel != null)
            {
                _context.Hostels.Remove(hostel);
            }

            _context.StudentsTs.Remove(student);
            _context.SaveChanges();

            return true;
        }

        // Get all hostel students
        public List<Hostel> GetHostelStudents()
        {
            return _context.Hostels
                .Include(h => h.Student)
                .ToList();
        }

        // Get all college students
        public List<StudentsT> GetAllStudents()
        {
            return _context.StudentsTs.ToList();
        }
    }
}