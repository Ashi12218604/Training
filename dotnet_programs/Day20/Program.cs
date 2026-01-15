// using System;
// using System.Threading;
// using System.Diagnostics;  // process class namespace
// class Program
// {
//     static int counter=0;
//     static object lockObj=new object();
//     static void Main()
//     {
//         Thread t1=new Thread(Increment);
//         Thread t2=new Thread(Increment);
//         t1.Start();
//         t2.Start();
//         t1.Join(); /* if we comment out joins then counter value becomes 0 bcoz t1 and t2 are still in waiting list */
//         t2.Join();
//         Console.WriteLine("Final counter value: "+ counter);
//     }
//     static void Increment()
//     {
//         for(int i=0;i<100000;i++)
//         { 
//             lock(lockObj)  // Internally Monitor class is running
//             {
//             counter++;
//             }
//         }
//     }


// ***********************************************************************************************************************************
// Process.Start("notepad.exe");
//***********************************************************************************************************************************

//         Process currentProcess=Process.GetCurrentProcess();
//         Console.WriteLine("Current Process Id: " +currentProcess.Id); //changes everytime because each execution starts a new separate process managed by the OS
//         Console.WriteLine("Process Name: "+currentProcess.ProcessName);
//         Console.WriteLine("Process time:"+currentProcess.StartTime); // date and time both
//         Console.WriteLine("Process Threads:"+currentProcess.Threads);  // tell namespace and collections
//         Console.WriteLine("Total process Time:"+currentProcess.TotalProcessorTime); 
    // }
// }


// ***********************************************************************************************************************************
using System;
using System.Threading;

class Program
{
    static void Main()
    {
        TaskDemo.ExecuteTask();
//         // Create a new thread
//         Thread worker = new Thread(DoWork);

//         // Start the thread
//         worker.Start();

//         Console.WriteLine("Main thread continues...");

//         // Optional: Wait for worker thread to finish
//         worker.Join();
//         Console.WriteLine("Main thread finished");
//     }

//     static void DoWork()
//     {
//         for (int i = 1; i <= 5; i++)
//         {
//             Console.WriteLine("Worker thread: " + i);
//             Thread.Sleep(500); // Simulate work
//         }
    }
}