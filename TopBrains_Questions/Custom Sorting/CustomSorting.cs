using System;
using System.Collections.Generic;
using System.Linq;
    public class Student
    {
        public string name {get; set;}
        public int age {get; set;}
        public int marks {get; set;}
    }
    class Program
    {
        static void Main(string[] args)
        {
            List<Student> students = new List<Student>
            {
                new Student {name="Ashi Gupta",age = 22,marks = 99},
                new Student {name = "Sanjana Velma",age = 21,marks = 98},
                new Student {name = "Arnav Gupta",age = 19,marks = 99},
                new Student {name = "Raima Shihab",age = 22,marks = 98},
                new Student {name = "Shahid Shaik",age = 20,marks = 98}
            };
            var sortedstudent = students.OrderByDescending(s => s.marks).ThenBy(s => s.age).ToList();
            foreach (var s in sortedstudent)
                Console.WriteLine($"{s.name} - Age:{s.age}, Marks:{s.marks}");
        }
    }
