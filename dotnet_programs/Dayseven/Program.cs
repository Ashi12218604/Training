using System;
class Program
{
    public static void Main(String[] args)
    {
        // Arrays.print();
        // Console.WriteLine();
        // Matrix.Calculate();
        // Console.WriteLine();
        // Jagged.Create();
        // Console.WriteLine();
        // Copy.Cp();
        // Console.WriteLine();
        // Exists.Ex();
        // Console.WriteLine();
        // Lists.ls();
        // Console.WriteLine();
        // Hashtables.hs();
        // Console.WriteLine();
        // Queues.q();
        //  Console.WriteLine();
        // Stacks.SK();
        // Console.WriteLine();
        // Diction.DT();
        // Console.WriteLine();
        // Hashsets.hs();
        // Console.WriteLine();
        // Sortedlists.Stl();
        // Console.WriteLine();
        // Frequency.freq();
        // Console.WriteLine();
        Scenario sc=new Scenario();
       Console.Write("Enter input string: ");
        string input=Console.ReadLine();
        string result=sc.cleansandinvert(input);
        if (result == "")
            Console.WriteLine("Invalid input");
        else
            Console.WriteLine("New String is: " + result);
        

    }
}