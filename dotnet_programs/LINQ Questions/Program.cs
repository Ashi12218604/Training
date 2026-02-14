// // Ques: Even numbers

//         // using System;
//         // using System.Collections.Generic;
//         // using System.Linq;
//         // class Program
//         // {
//         //     public static void Main(String[] args)
//         //     {
//         //         int[] numbers={1,2,3,4,5,6,7,8,9};
//         //         // var evennumbers=
//         //         // from n in numbers
//         //         // where n%2==0
//         //         // select n;
//         //         var evennumbers=numbers.Where(n=>n%2==0);
//         //         Console.WriteLine("Query output");
//         //         foreach (var n in evennumbers)
//         //         {
//         //             Console.WriteLine(n);
//         //         }
//         //     }
//         // }



// using System;
// using System.Linq;
// using System.Collections.Generic;

// class Program
// {
//     static void Main()
//     {
//         List<int> numbers = new List<int>
//         {
//             10, 15, 20, 25, 30, 10, 20
//         };

//         // 1. Where
//         Console.WriteLine("1. Where ( > 20 )");
//         var filtered = numbers.Where(n => n > 20);
//         foreach (var n in filtered)
//         {
//             Console.WriteLine(n);
//         }


//         // 2. Select
//         Console.WriteLine("\n2. Select ( Square )");
//         var squares = numbers.Select(n => n * n);
//         Print(squares);

//         // 3. OrderBy
//         Console.WriteLine("\n3. OrderBy");
//         var ordered = numbers.OrderBy(n => n);
//         Print(ordered);

//         // 4. OrderByDescending
//         Console.WriteLine("\n4. OrderByDescending");
//         Print(numbers.OrderByDescending(n => n));

//         // 5. Take
//         Console.WriteLine("\n5. Take ( first 3 )");
//         Print(numbers.Take(3));

//         // 6. Skip
//         Console.WriteLine("\n6. Skip ( first 2 )");
//         Print(numbers.Skip(2));

//         // 7. Count
//         Console.WriteLine("\n7. Count");
//         Console.WriteLine(numbers.Count());

//         // 8. Sum
//         Console.WriteLine("\n8. Sum");
//         Console.WriteLine(numbers.Sum());

//         // 9. Max
//         Console.WriteLine("\n9. Max");
//         Console.WriteLine(numbers.Max());

//         // 10. Min
//         Console.WriteLine("\n10. Min");
//         Console.WriteLine(numbers.Min());

//         // 11. Average
//         Console.WriteLine("\n11. Average");
//         Console.WriteLine(numbers.Average());

//         // 12. FirstOrDefault
//         Console.WriteLine("\n12. FirstOrDefault ( > 50 )");
//         Console.WriteLine(numbers.FirstOrDefault(n => n > 50));

//         // 13. Any
//         Console.WriteLine("\n13. Any ( > 25 )");
//         Console.WriteLine(numbers.Any(n => n > 25));

//         // 14. Distinct
//         Console.WriteLine("\n14. Distinct");
//         Print(numbers.Distinct());

//         // 15. Aggregate
//         Console.WriteLine("\n15. Aggregate ( Multiply All )");
//         int product = numbers.Aggregate((a, b) => a * b);
//         Console.WriteLine(product);
//     }

//     static void Print(IEnumerable<int> data)
//     {
//         foreach (var item in data)
//         {
//             Console.Write(item + " ");
//         }
//         Console.WriteLine();
//     }
// }






// //Inner Join

// //using System;
// //using System.Collections.Generic;
// //using System.Linq;

// //namespace LinqInnerJoinDemo
// //{
// //    class Program
// //    {
// //        static void Main(string[] args)
// //        {
// //            // Students collection
// //            List<Student> students = new List<Student>
// //            {
// //                new Student { StudentId = 1, Name = "Ravi" },
// //                new Student { StudentId = 2, Name = "Anu" },
// //                new Student { StudentId = 3, Name = "Kumar" }
// //            };

// //            // Courses collection
// //            List<Course> courses = new List<Course>
// //            {
// //                new Course { StudentId = 1, CourseName = "C#" },
// //                new Course { StudentId = 1, CourseName = "SQL" },
// //                new Course { StudentId = 2, CourseName = ".NET" }
// //            };

// //            // INNER JOIN using LINQ (Query Syntax)
// //            var result =
// //                from s in students
// //                join c in courses
// //                    on s.StudentId equals c.StudentId
// //                select new
// //                {
// //                    StudentName = s.Name,
// //                    CourseName = c.CourseName
// //                };

// //            // Print result
// //            Console.WriteLine("INNER JOIN RESULT:\n");

// //            foreach (var item in result)
// //            {
// //                Console.WriteLine($"{item.StudentName} - {item.CourseName}");
// //            }

// //            Console.ReadLine();
// //        }
// //    }

// //    // Student class
// //    class Student
// //    {
// //        public int StudentId { get; set; }
// //        public string Name { get; set; }
// //    }

// //    // Course class
// //    class Course
// //    {
// //        public int StudentId { get; set; }
// //        public string CourseName { get; set; }
// //    }
// //}



// // LINQ Questions based on List Scenario
// using System;
// using System.Collections.Generic;
// using System.Linq;
// class Program
// {
//     public static void Main(String[] args)
//     {
//         List<string> ls=new List<string>{"Mari","Shiva","Arjun","Daniel","University"};
//         var c=ls.Count();
//         var morethan4=ls.Where(x => x.Length > 4).ToList();
//         var startswitha=ls.Where(n=>n.StartsWith("A",StringComparison.OrdinalIgnoreCase)).ToList();
//         var firstTwo = ls.Select(x => x.Substring(0, 2)).ToList();
//         Console.WriteLine("Total Count" + c);
//         Console.WriteLine("\nMore than 4 characters");
//         morethan4.ForEach(Console.WriteLine);
//         Console.WriteLine("\nStarts with A");
//         startswitha.ForEach(Console.WriteLine);
//         Console.WriteLine("\nFirst 2 characters");
//         firstTwo.ForEach(Console.WriteLine);
//     }
// }