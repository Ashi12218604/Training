using System;
public class Jagged
{
        public static void Create()
    {
        int[][] jagged = new int[2][];
        // Initialization
        jagged[0]=new int[]{1,2};
        jagged[1]=new int[]{3,4,5};
        // Print number 5
        Console.WriteLine(jagged[1][2]);
        Console.WriteLine();
        for (int i=0;i<jagged.Length;i++)
        {
            for (int j=0;j<jagged[i].Length;j++) //jagged[i].Length because column length is variable
            {
                Console.Write(jagged[i][j]+" ");

            }
            Console.WriteLine();
        }
    }
}
/*used when number of data is irregular
each row contains different number */