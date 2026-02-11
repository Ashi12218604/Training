using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace University_Course_Registration_System
{
    // =========================
    // Student Class
    // =========================
    public class Student
    {
        public string StudentId { get; private set; }
        public string Name { get; private set; }
        public string Major { get; private set; }
        public int MaxCredits { get; private set; }

        public List<string> CompletedCourses { get; private set; }
        public List<Course> RegisteredCourses { get; private set; }

        public Student(string id, string name, string major, int maxCredits = 18, List<string> completedCourses = null)
        {
            StudentId = id;
            Name = name;
            Major = major;
            MaxCredits = maxCredits;
            CompletedCourses = completedCourses ?? new List<string>();
            RegisteredCourses = new List<Course>();
        }

        public int GetTotalCredits()
        {
            return RegisteredCourses.Sum(c => c.Credits);
        }

        public bool CanAddCourse(Course course)
        {
            if (RegisteredCourses.Any(c => c.CourseCode == course.CourseCode))
                return false;

            if (GetTotalCredits() + course.Credits > MaxCredits)
                return false;

            if (!course.HasPrerequisites(CompletedCourses))
                return false;

            return true;
        }

        public bool AddCourse(Course course)
        {
            if (CanAddCourse(course) && !course.IsFull())
            {
                RegisteredCourses.Add(course);
                course.EnrollStudent();
                return true;
            }

            return false;
        }

        public bool DropCourse(string courseCode)
        {
            var course = RegisteredCourses.FirstOrDefault(c => c.CourseCode == courseCode);

            if (course != null)
            {
                RegisteredCourses.Remove(course);
                course.DropStudent();
                return true;
            }

            return false;
        }

        public void DisplaySchedule()
        {
            if (RegisteredCourses.Count == 0)
            {
                Console.WriteLine("No courses registered.");
                return;
            }

            foreach (var c in RegisteredCourses)
            {
                Console.WriteLine($"{c.CourseCode} - {c.CourseName} ({c.Credits} credits)");
            }
        }
    }
}
