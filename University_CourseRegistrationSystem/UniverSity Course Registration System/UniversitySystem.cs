using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
// =========================
    // University System Class
    // =========================
    public class UniversitySystem
    {
        public Dictionary<string, Course> AvailableCourses { get; private set; }
        public Dictionary<string, Student> Students { get; private set; }

        public UniversitySystem()
        {
            AvailableCourses = new Dictionary<string, Course>();
            Students = new Dictionary<string, Student>();
        }

        public void AddCourse(string code, string name, int credits, int maxCapacity = 50, List<string> prerequisites = null)
        {
            if (AvailableCourses.ContainsKey(code))
                throw new ArgumentException("Course already exists.");

            AvailableCourses.Add(code, new Course(code, name, credits, maxCapacity, prerequisites));
        }

        public void AddStudent(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            if (Students.ContainsKey(id))
                throw new ArgumentException("Student already exists.");

            Students.Add(id, new Student(id, name, major, maxCredits, completedCourses));
        }

        public bool RegisterStudentForCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId) || !AvailableCourses.ContainsKey(courseCode))
            {
                Console.WriteLine("Student or Course not found.");
                return false;
            }

            var student = Students[studentId];
            var course = AvailableCourses[courseCode];

            if (student.AddCourse(course))
            {
                Console.WriteLine($"Registration successful. Credits: {student.GetTotalCredits()}/{student.MaxCredits}");
                return true;
            }

            Console.WriteLine("Registration failed (credit limit/prerequisite/full course).");
            return false;
        }

        public bool DropStudentFromCourse(string studentId, string courseCode)
        {
            if (!Students.ContainsKey(studentId))
                return false;

            return Students[studentId].DropCourse(courseCode);
        }

        public void DisplayAllCourses()
        {
            foreach (var course in AvailableCourses.Values)
            {
                Console.WriteLine($"{course.CourseCode} | {course.CourseName} | {course.Credits} credits | {course.GetEnrollmentInfo()}");
            }
        }

        public void DisplayStudentSchedule(string studentId)
        {
            if (!Students.ContainsKey(studentId))
            {
                Console.WriteLine("Student not found.");
                return;
            }

            Students[studentId].DisplaySchedule();
        }

        public void DisplaySystemSummary()
        {
            int totalStudents = Students.Count;
            int totalCourses = AvailableCourses.Count;

            double avgEnrollment = totalCourses == 0 ? 0 :
                AvailableCourses.Values
                .Average(c => int.Parse(c.GetEnrollmentInfo().Split('/')[0]));

            Console.WriteLine($"Total Students: {totalStudents}");
            Console.WriteLine($"Total Courses: {totalCourses}");
            Console.WriteLine($"Average Enrollment: {avgEnrollment:F2}");
        }
    }
}
