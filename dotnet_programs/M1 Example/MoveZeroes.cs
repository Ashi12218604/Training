using System;

class Program
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] arr = new int[n];

        if (n > 0)
        {
            string[] input = Console.ReadLine().Split(' ');

            for (int i = 0; i < n; i++)
            {
                arr[i] = int.Parse(input[i]);
            }
        }
        MoveZeros(arr);
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write(arr[i] + " ");
        }
    }
    static void MoveZeros(int[] arr)
    {
        int write = 0;
        for (int read = 0; read < arr.Length; read++)
        {
            if (arr[read] != 0)
            {
                arr[write] = arr[read];
                write++;
            }
        }

        while (write < arr.Length)
        {
            arr[write] = 0;
            write++;
        }
    }
}
