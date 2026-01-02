// using System;
// class Programs
// {
//     public static void Main()
//     {
//         // *** Garbage Collector ***
//     //         Console.WriteLine("Creating objects...");
//     //         for(int i=0;i<10;i++)
//     //         {
//     //             Myclass obj=new Myclass();
//     //         }
//     //         Console.WriteLine("Forcing Garbage Collection....");
//     //         GC.Collect();
//     //         GC.WaitForPendingFinalizers();
//     //         Console.WriteLine("Garbage collection completed");

//     //     }
//     // }
//     // class Myclass
//     // {
//     //     ~Myclass()  //Finalizer(Destructor like method)      // No parameter, no return type
//     //     {
//     //         Console.WriteLine("FiNALIZER CALLED,OBJECT COLLECTED");
//     //     }
//     // }

// // ***Anonymous.cs*** //
//     // Anonymous.Print();
//     // Console.WriteLine();

// // ***Multipletuples.cs*** //
//     // var result = MultipleTuples.Calculate(10, 5);
//     //         Console.WriteLine("Sum = " + result.Sum);
//     //         Console.WriteLine("Difference = " + result.Diff);
//     //         Console.WriteLine("Average = " + result.Average);

//         Console.WriteLine();

// // ***Tuples.cs*** //
//     // var response=Tuples.ValidateUser("Admin");
//     // Console.WriteLine(response.Message);

// // ***Student.cs*** //
//     // var s = new Student { Id = 1, Name = "Amit" };
//     // Console.WriteLine(s.GetType());
//     // var (sid, sname) = s;

//     // Console.WriteLine(sid);
//     // Console.WriteLine(sname);

// // ***Evenumbers.cs*** //
//     //  Evennumbers.Filter();

// // ***Datashaping.cs*** //
//     //  DataShaping.Run();

// // ***Employee.cs*** //
//     // EmployeeSort.Sort();

//     // ***ResourceHandler.cs*** //
//     using (ResourceHandler handler = new ResourceHandler())
//         {
//             Console.WriteLine("Using the resource...");
//         }

//         Console.WriteLine("End of Program");


// }
// }


using System;

class Program
{
    static void Main()
    {
        Console.WriteLine($"Total Memory Before GC: {GC.GetTotalMemory(false)} bytes");

        for (int i = 0; i < 10000; i++)
        {
            object obj = new object(); // Gen 0 allocation
        }

        Console.WriteLine($"Total Memory After Object Creation: {GC.GetTotalMemory(false)} bytes");

        GC.Collect(); 
        GC.WaitForPendingFinalizers();

        Console.WriteLine($"Total Memory After GC: {GC.GetTotalMemory(false)} bytes");
        Console.WriteLine($"Generation of a new object: {GC.GetGeneration(new object())}");
    }
}