using System;

class Program
{
    static void Main()
    {
        // --- Wallet Section ---
        Wallet w = new Wallet();
        w.AddMoney(2000);
        w.AddMoney(5000);
        Console.WriteLine("Wallet Balance: " + w.GetBalance());

        // --- Math Operations Section ---
        // Calling static methods
        Console.WriteLine("Static Add (int): " + Mathops.add(1, 2));
        Console.WriteLine("Static Add (double/int): " + Mathops.add(1.1, 2));
        
        // Calling instance method
        Mathops m = new Mathops();
        Console.WriteLine("Instance Add: " + m.add(1, 2));
        Console.WriteLine("Static Add (double): " + Mathops.add(1.1, 1.2));

        // --- Named Section ---
 
        Named person = new Named("Ashi", 21, "Uttarakhand", 'F');
        Console.WriteLine("Name: Ashi");
        Console.WriteLine("Age: 21");
        Console.WriteLine("City: Uttarakhand");
        Console.WriteLine("Gender: F");

        // --- Print Letters Section ---
      
        Printnameletters pnl = new Printnameletters();
        pnl.print();

        // --- Total Print Section ---
       
        Totalprint tp = new Totalprint();
        tp.print();

        // --- Ref/Out/In Section ---
         int x = 10;
        // Decbyten.dec(ref x);
        // Console.WriteLine("Value after ref dec: " + x);

        int q, r;
        Calculator.Divide(10, 3, out q, out r);
        Console.WriteLine("Quotient = " + q);
        Console.WriteLine("Remainder = " + r);

        
        x = 50; 
        Display.Show(in x);

        // --- Params Array Section ---
        Console.WriteLine("Sum 1: " + SumArray.SA(2, 3, 5));
        Console.WriteLine("Sum 2: " + SumArray.SA(3, 4, 5, 6));
        
        // --- Process Section ---
        // Variable named 'proc' instead of 'p'
        Process proc = new Process();
        proc.Proc();
//*****************************************************************************************
Assesmentone.Bankingacc();
//*****************************************************************************************
    }
}