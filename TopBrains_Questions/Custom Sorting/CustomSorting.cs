using System;
using System.Collections.Generic;
    public class Student
    {
        public string name {get;set;}
        public int age {get;set;}
        public int marks {get;set;}
    }
    public class StudentComparer:IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            if (x.marks!= y.marks)
                return y.marks.CompareTo(x.marks);
            return x.age.CompareTo(y.age);
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student { name = "Ashi Gupta", age = 22, marks = 99},
                new Student { name = "Sanjana Velma", age = 21, marks = 98},
                new Student { name = "Arnav Gupta", age = 19, marks = 95},
                new Student { name = "Raima Shihab", age = 22, marks = 98},
                new Student { name = "Shahid Shaik", age = 20, marks = 98}
            };
            students.Sort(new StudentComparer());
            foreach (var s in students)
            {
                Console.WriteLine($"{s.name} - Age:{s.age}, Marks:{s.marks}");
            }
        }
    }
