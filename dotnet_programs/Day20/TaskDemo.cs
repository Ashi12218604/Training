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
    }
}
