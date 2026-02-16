using System.Collections.Generic;
using Student;

namespace ReverseStudent
{
    public class ReverseStudentLogic
    {
        public List<string> GetReversedStudents()
        {
            InputStudent dal = new InputStudent();
            var students = dal.GetStudents();

            students.Reverse();
            return students;
        }
    }
}
