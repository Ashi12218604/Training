using System;

class Totalprint
{
        public void print()
    {
        int n=Convert.ToInt32(Console.ReadLine());
        int[] arr=new int[n];
        int total=0;

        for(int i=0;i<n;i++)
        {
            Console.WriteLine("Enter value:");
            arr[i]=Convert.ToInt32(Console.ReadLine());
            total+=arr[i];
        }

        Console.WriteLine("Total value of total is:"+total);
    }
}
