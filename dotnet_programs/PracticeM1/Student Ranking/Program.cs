using System;
using System.Collections.Generic;
using System.Linq;

public class Student
{
    public string Name { get; set; }
    public int Marks { get; set; }

    public Student(string name, int marks)
    {
        Name = name;
        Marks = marks;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Student> list = new List<Student>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            list.Add(new Student(input[0], int.Parse(input[1])));
        }

  var top=list.OrderByDescending(x=>x.Marks).Take(3);
        foreach (var s in top)
        {
            Console.WriteLine($"{s.Name} {s.Marks}");
        }
    }
}
