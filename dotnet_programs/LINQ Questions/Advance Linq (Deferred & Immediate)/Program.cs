// using System;
// using System.Linq;
// using System.Collections.Generic;
// class Program
// {
//     public static void Main(string[] args)
//     {
//         List<int> numbers=new List<int>{10,20,30};
// // DEFERRED EXECUTION  -> LAZY LOADING (WILL NOT RUN UNTIL GETS CALLED)
//         var deferredquery=numbers.Where(n=>n>15);
//         numbers.Add(40);  // 40 will be added because the lambda line didnt execute bcoz it is still not called
//         Console.WriteLine("Deferred Execution Result:");
//         foreach(var v in deferredquery)
//         {
//             Console.WriteLine(v);
//         }
// // IMMEDIATE EXECUTION
//         var immediateresult=numbers.Where(n=>n>15).ToList();    //ADDED TO TO.LIST();
//         numbers.Add(50); // already lambda exp is executed
//           Console.WriteLine("Immediate Execution Result:");
//         foreach(var s in immediateresult)
//         {
//             Console.WriteLine(s);
//         }
//     }
// }

// DIVIDE L1 IN TWO LIST AFTER COUNTING AND DIVIDING
        // using System;
        // using System.Linq;
        // using System.Collections.Generic;
        // class Program
        // {
        //     public static void Main(String[] args)
        //     {
        //         List<int> l1 = new List<int> { 10, 20, 30, 40, 50, 60, 70, 80 };
        //         int m = l1.Count / 2;
        //         List<int> l2 = l1.Skip(m).ToList(); 
        //         l1 = l1.Take(m).ToList(); 
        //         Console.WriteLine("List 1 :");
        //         foreach (var num in l1)
        //         {
        //             Console.WriteLine(num);
        //         }
        //         Console.WriteLine("List 2:");
        //         foreach (var num in l2)
        //         {
        //             Console.WriteLine(num);
        //         }
        //     }
        // }



// using System;
// using System.Collections.Generic;

// class Program
// {
//    public static void Main(String[] args)
//     {
//         // Creating a List
//         List<Student> students = new List<Student>();
//         // Adding students
//         students.Add(new Student { Id = 1, Name = "Ravi", Age = 20 });
//         students.Add(new Student { Id = 2, Name = "Kumar", Age = 22 });
//         students.Add(new Student { Id = 3, Name = "Priya", Age = 19 });

//         Console.WriteLine("Total Students: " + students.Count);
//         Console.WriteLine();

//         // Accessing by index
//         Console.WriteLine("First Student: " + students[0].Name);
//         Console.WriteLine();

//         // Updating student
//         students[1].Age = 23;

//         // Removing student
//         students.RemoveAt(2);

//         Console.WriteLine("After Update and Remove:");
//         Console.WriteLine("Total Students: " + students.Count);
//         Console.WriteLine();

//         // Sorting list by Age
//         students.Sort((s1, s2) => s1.Age.CompareTo(s2.Age));

//         Console.WriteLine("Sorted by Age:");
//         foreach (var student in students)
//         {
//             Console.WriteLine(student.Id + " - " + student.Name + " - " + student.Age);
//         }

//         Console.ReadLine();
//     }
//     }



using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
class Pc
{
        static void Main()
    {
        ArrayList arr = new ArrayList(){1, "Mari", "MCA", 2000};
        IEnumerable<int> i = arr.OfType<int>();  
        Console.WriteLine(string.Join(", ", i));
        string[] names = {"Ashi","MariMuthu","Sanjana","Shubhanshu","Aryan","Arnav","Arjun" };
        IEnumerable<string> s=names.Where(n=>n.StartsWith("A"));
        Console.WriteLine(string.Join(", ", s));
        IEnumerable<string> e=names.Where(n=>n.EndsWith("u")).Select(n=>"Mr. "+ n);
        Console.WriteLine(string.Join(", ",e));
    }
}
