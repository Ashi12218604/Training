using System;
public class Arrays
{
    public static void print()
    {
    //Declaration
int[] numbers = { 10, 20, 30, 40, 50 };
//Initialize with size
//   numbers=new int[5];
//initialize with values
//   numbers={10,20,30,40,50};
foreach(int x in numbers)
        {
             Console.WriteLine(x);
        }
        // Clear 
        // Array.Clear(arryname,startindex,lastindex)
        Array.Clear(numbers,2,3);
       foreach (int n in numbers)
    {
    Console.Write(n + " ");
    }

}
}