using System;
using System.Threading.Tasks;
using System.Diagnostics;

public class TaskDemo
{
    public static void ExecuteTask()
    {
        try
        {
            Task t = Task.Run(() => throw new Exception("Task error"));
            t.Wait();
        }
        catch (AggregateException ex)
        {
            Console.WriteLine(ex.InnerExceptions[0].Message);
        }
        Task t1=Task.Run(() =>Console.WriteLine("Task 1"));
                Task t2=Task.Run(() =>Console.WriteLine("Task 2"));
                Task.WhenAll(t1,t2).ContinueWith(t => Console.WriteLine("All tasks completed"));

Task <int> t3= Task.Run(() => 42);
        t3.ContinueWith(resultTask => Console.WriteLine($"Result: {resultTask.Result}")).Wait();
   
    }
}
