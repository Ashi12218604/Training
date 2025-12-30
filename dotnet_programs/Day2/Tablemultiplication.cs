using System;
class Tablemultiplication
{
    public static void Multiples()
    {
        for (int j = 20; j<= 30; j++)
        {
            Console.WriteLine($"Table of {j}");
            for(int i = 0; i<= 10; i++)
            {
                Console.WriteLine($"{j} X {i} = {j*i}");
            }
        }
        
    }
}