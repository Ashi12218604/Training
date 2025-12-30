using System;
public class Calculatornew
{
    public static void Calculator(int a,int b)
    {
        int res=0;
        void add()
        {
            res=a+b;
            Console.WriteLine("Addition = "+res);
        }
        void subtract() 
        {
            res=a-b;
            Console.WriteLine("Subtraction = "+res);
        }
        add();
        subtract();
    }
}
