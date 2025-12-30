using System;
public class Matrix
{
   public static void Calculate()
    {
        int[,] matrix =
        {
            {1,2},
            {3,4}
        };
        for(int i=0;i<matrix.GetLength(0);i++)
        { 
            for(int j=0;j<matrix.GetLength(1);j++)   //GetLength is for jagged array(array of arrays where length can vary)
            {
                Console.Write(matrix[i,j]+" ");
            }
            Console.WriteLine();
        }
    }
}