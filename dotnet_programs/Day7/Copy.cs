using System;
public class Copy
{
    public static void Cp()
    {
        int[] src ={7,8,9};
        int[] src1={7,8,9};
        int[] dest = new int[3];
        // Copy all elements
        Array.Copy(src, dest, 3);
        Console.WriteLine("After copying 3 elements:");
        foreach (int n in dest)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        // Copy only first 2 elements
        int[] dest2 = new int[3];
        Array.Copy(src, dest2, 2);
        Console.WriteLine("After copying 2 elements:");
        foreach (int n in dest2)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        Array.Resize(ref src,5);
        Console.WriteLine("After Resizing elements to 5:");
            foreach (int n in src)
        {
            Console.Write(n + " ");
        }
        Console.WriteLine();
        // Array.Resize(src,5); // without ref: Argument 1 must be passed with the 'ref' keyword
        Array.Resize(ref src1,1);
        Console.WriteLine("After Resizing elements to 1:");
             foreach (int n in src1)
        {
            Console.Write(n + " ");
        }
      
    }
}
