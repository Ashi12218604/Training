using System.Threading;
using System.Threading.Tasks;
class Program
{
    public static void Main()
    {
        // Thread worker=new Thread(DoWork);
        // Console.WriteLine("Main thread continue........");
        // worker.Start();
        // *******************************************************************************************
        // Parallel.For(0,5,i=>
        // {
        //     Console.WriteLine($"Processing item {i}");
        // });
        // *******************************************************************************************
        int[] numbers=new int[10];
for(int i=0;i<numbers.Length;i++)
numbers[i]=i+1;
int sum=0;
//*******************************************************************************************
// Parallel.For(0,numbers.Length,i=>
// {
//     sum+=numbers[i]; //Not thread-safe(for demonstration)
            
// });
// Console.WriteLine("SUM:"+sum);
//*******************************************************************************************

Parallel.For(0,numbers.Length,() =>0,(i,loopstate,localsum)=>
{
            return localsum+numbers[i];
        },
        localsum =>
        {
            Interlocked.Add(ref sum, localsum);
        });
        Console.WriteLine("Sum "+sum);
//*******************************************************************************************
// async Task<int> GetDataAsync()
//         {
//             await Task.Delay(1000);
//             return 43;
//         }
//         await GetDataAsync();
   }
// *******************************************************************************************
    // static void DoWork()
    // {
    //     for(int i=1;i<=5;i++)
    //     {
    //         Console.WriteLine("Worker thread: "+i);
    //         Thread.Sleep(5000);
    //     }
    // }
}