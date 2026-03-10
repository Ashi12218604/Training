using CollegeAPI.DTOs;
using CollegeAPI.Models;

namespace CollegeAPI.Services
{
    public interface IStudentService
    {
        StudentsT AddStudent(StudentAdmissionDTO dto);
        Hostel UpdateRoom(UpdateRoomDTO dto);
        bool DeleteStudent(int studentId);
        List<Hostel> GetHostelStudents();
        List<StudentsT> GetAllStudents();
    }
}