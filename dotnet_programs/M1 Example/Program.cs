// using System;
// using System.Collections.Generic;

// public class Program
// {
//     public static Stack<Order> OrderStack { get; set; } = new Stack<Order>();

//     public static void Main(string[] args)
//     {
//         Order obj = new Order();

//         int orderId = Convert.ToInt32(Console.ReadLine());
//         string customerName = Console.ReadLine();
//         string item = Console.ReadLine();

//         obj.AddOrderDetails(orderId, customerName, item);

//         Console.WriteLine(obj.GetOrderDetails());

//         obj.RemoveOrderDetails();

//         if (OrderStack.Count == 0)
//         {
//             Console.WriteLine("No Orders");
//         }
//         else
//         {
//             foreach (Order o in OrderStack)
//             {
//                 Console.WriteLine(o.OrderId + " " + o.CustomerName + " " + o.Item);
//             }
//         }
//     }
// }


// using System;
// using System.Collections.Generic;

// class Program
// {
//     static void Main(String[] args)
//     {
//         Dictionary<string, int> inventory = new Dictionary<string, int>
//         {
//             { "P101", 25 },
//             { "P102", 0 },
//             { "P103", 14 }
//         };

//         string inputCode = Console.ReadLine();
//         // TODO: Implement lookup and print result
//         if(inventory.ContainsKey(inputCode))
//         {
//             Console.WriteLine(inventory[inputCode]);
//         }
//     else
//         {
//             Console.WriteLine("Not found");
//         }


//     }
// }

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        Dictionary<string, int> marks = new Dictionary<string, int>
//        {
//            { "Asha", 78 },
//            { "Bala", 82 }
//        };

//        string student = Console.ReadLine();
//        int newMark = int.Parse(Console.ReadLine());
//        // TODO: Add or update mark
//        if(marks.ContainsKey(student))
//        {
//            marks[student]=newMark;
//        }
//        else

//        {
//            marks.Add(student,newMark);
//        }
//        Console.WriteLine(marks[student]);
//    }
//}

//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        int[] employeeIds = { 1001, 1002, 1001, 1003, 1002, 1001 };
//        Dictionary<int, int> attendance = new Dictionary<int, int>();

//        // Build frequency map
//        foreach (int id in employeeIds)
//        {
//            if (attendance.ContainsKey(id))
//            {
//                attendance[id]++;
//            }
//            else
//            {
//                attendance[id] = 1;
//            }
//        }

//        // Print result
//        foreach (var v in attendance)
//        {
//            Console.WriteLine($"Employee {v.Key} : {v.Value}");
//        }
//        Console.ReadLine();

//    }
//}


//using System;
//using System.Collections.Generic;

//class Program
//{
//    static void Main()
//    {
//        string[] attempts = { "raj", "kavi", "raj", "raj", "kavi" };
//        Dictionary<string, int> failedAttempts = new Dictionary<string, int>();
//       foreach(string a in attempts)
//        {
//           if(failedAttempts.ContainsKey(a))
//            {
//                failedAttempts[a]++;
//            }
//            else
//            {
//                failedAttempts[a] = 1;
//            }
//        }
//       foreach(var v in failedAttempts)
//        {
//            if(v.Value>=3)
//            {
//                Console.WriteLine(v.Key);
//            }
//        }
//       Console.ReadLine();
//        // TODO: Count attempts and print users with attempts >= 3
//    }
//}



// C# Program to remove elements
// from a stack
// using System;
// using System.Collections.Generic;

// class Geeks
// {
//     public static void Main(string[] args)
//     {
//         // Initialize a stack
//         Stack<string> s = new Stack<string>();

//         // Inserting elements into the s using Push()
//         s.Push("Geeks");
//         s.Push("For");
//         s.Push("Geeks");
//         s.Push("For");

//         // Initial stack
//         Console.WriteLine("Initial stack: ");
//         foreach (var item in s)
//         {
//             Console.WriteLine(item);
//         }

//         // Removing the top element 
//         // from the stack
//         s.Pop();

//         // Final s after removal
//         Console.WriteLine("\nUpdated stack after Pop:");
//         foreach (string item in s)
//         {
//             Console.WriteLine(item);
//         }
//         Console.ReadLine();
//     }
// }




// Reverse

// using System;
// using System.Collections;
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         string input="Hello World";
//         string[] words=input.Split(' ');
//         for(int i=0;i<words.Length;i++)
//         {
//             char[] arr=words[i].ToCharArray();
//             Array.Reverse(arr);
//             words[i]=new string(arr);
//         }
//        Console.WriteLine(string.Join(" ",words)); 
//     }
// }


//Second Highest

// using System;
// class Program
// {
//     public static void Main(string[] args)
//     {
//         int[] salary={1000,2000,4000,1500};
//         // Array.Sort(salary);
//         // Console.WriteLine(salary[salary.Length-2]);
//         int sh=salary.Distinct().OrderByDescending(x=>x).Skip(1).First();
//         Console.WriteLine(sh);
//     }
// }

// Student attendance analyser

// using System;
// using System.Collections.Generic;
// using System.Collections;
// public class Student_Attendance
// {
//         public static Dictionary<int,bool?> validate(string input)
//     {
//         Dictionary<int, bool?> dict=new Dictionary<int, bool?>();
//             foreach (var v in input.Split(','))
//         {
//             var colon = v.Split(':');
//             string idc=colon[0];
//             if (!idc.All(char.IsDigit))
//                 continue;
//             int id = Convert.ToInt32(idc);
//             string value=colon.Length>1?colon[1]:"";
//             if (string.IsNullOrEmpty(value))
//                 dict[id]=null;
//             else if (value=="Present")
//                 dict[id] = true;
//             else
//                 dict[id] = false;
//         }
//         return dict;
//     }
// public static void Main(string[] args)
// {
//     string input="101:Present,102:Absent,103:Present,104:,105:Present,ABC:Present,106:Absent";
//     var attendance=validate(input);
//             foreach (var s in attendance)
//         {
//             if (s.Value == true)
//                 Console.WriteLine($"{s.Key} -> Present");
//             else if (s.Value == false)
//                 Console.WriteLine($"{s.Key} -> Absent");
//             else
//                 Console.WriteLine($"{s.Key} -> Not Marked");
//         }
// }
// }


//Even number using Linq
// using System;
// using System.Linq;
// public class Program
// {
//     public static void Main(string[] args)
//     {
//         int[] n={1,2,3,4,5,6,7,8,9};
//         var n2=n.Where(n=>n%2==0);
//         Console.WriteLine(String.Join(",",n2));

//     }
// }


// Exception handling
    // using  System;
    // public class InvalidAgeException:Exception
    // {
    //     public InvalidAgeException(string message):base(message)
    //     {
            
    //     }
    // }
    // class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         int age=16;
    //         try
    //         {
    //         if(age<18)
    //         throw new InvalidAgeException("Age must be 18");
    //         }
    //         catch (InvalidAgeException ex)
    //         {
    //             Console.WriteLine(ex.Message);
    //         }

    //     }
    // }



    // Discount
    //     using System;
    //     public class Discount
    // {
    //     public static void Main(string[] args)
    //     {
    //         // double p;
    //         double o=double.Parse(Console.ReadLine());
    //         if(o>5000)
    //         {
    //     o=o-(0.10*o);
    //         }
    //     double p=o;
    //         Console.WriteLine(p);


    //     }
    // }


// Delegate for addition and multiplication of two numbers
        // using System;
        // class Program{
        // public delegate int Operation(int a, int b);
        //     static int Add(int a, int b)
        //     {
        //         return a+b;
        //     }
        //     static int Multi(int a, int b)
        //     {
        //         return a*b;
        //     }
        // public static void Main(string[] args)
        //     {
        //         Operation op;
        //         op=Add;
        //         Console.WriteLine("Additions is:"+ op(5,3));
        //         op=Multi;
        //         Console.WriteLine("Multiplication is:"+ op(7,7));
        //     }

        // }


        //Multi cast delegate
// using System;

// class Program
// {
//     public delegate void Notify();

//     static void SendEmail()
//     {
//         Console.WriteLine("Email Sent");
//     }

//     static void SendSMS()
//     {
//         Console.WriteLine("SMS Sent");
//     }

//     static void SendWhatsApp()
//     {
//         Console.WriteLine("WhatsApp Message Sent");
//     }

//     static void Main()
//     {
//         Notify notify = SendEmail;
//         notify += SendSMS;
//         notify += SendWhatsApp;

//         notify();
//     }
// }



//Fun and Action
    // using System;
    // class Program
    // {
    //     public static void Main(string[] args)
    //     {
    //         Func<int,int> square=n=>n*n;
    //         Console.WriteLine(square(7));
    //     }
    // }


//Action
        // using System;
        // public class Program
        // {
        //     public static void Main(string[] args)
        //     {
        //     Action<string> print= msg=>Console.WriteLine(msg);
        //     print("Hello Ayush");
        // }
        // }


//Reverse String
using System;
public class Program
{
    public static void Main(string[] args)
    {
        string input="Ayush is Gay";
        string[] str=input.Split(" ");
        for(int i=0;i<str.Length;i++)
        {
            char[] arr=str[i].ToCharArray();
            Array.Reverse(arr);
            str[i]=new string(arr);
        }
        Console.WriteLine(String.Join(" ",str));
    }
}
