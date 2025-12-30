using System;
using System.Runtime.InteropServices.Marshalling;
class Program
   {
static void Main()
{
    Tablemultiplication.Multiples();
    Reversecount.rev();
    Gaming.game();

    // ********************************************************
    // Banking Finance System
    int ch; // First declaration
    do
    {
        Console.WriteLine("1. Check Loan Eligibility");
        Console.WriteLine("2. Calculate Tax");
        Console.WriteLine("3. Enter Transactions");
        Console.WriteLine("4. Exit");
        ch = Convert.ToInt32(Console.ReadLine());
        switch (ch)
        {
            case 1: FinanceControlSystem.CheckLoan(); break;
            case 2: FinanceControlSystem.Tax(); break;
            case 3: FinanceControlSystem.Transactions(); break;
            case 4: Console.WriteLine("Exit"); break;
            default: Console.WriteLine("Invalid choice"); break;
        }
    } while (ch != 4);

    // ********************************************************
    // Mini Project
       do
    {
        Console.WriteLine("--- Mini Project Menu ---");
        Console.WriteLine("1. Check Loan Eligibility");
        Console.WriteLine("2. Calculate Tax");
        Console.WriteLine("3. Enter Transactions");
        Console.WriteLine("4. Exit");
        ch = Convert.ToInt32(Console.ReadLine()); 
        switch (ch)
        {
            case 1: FinanceControlSystem.CheckLoan(); break;
            case 2: FinanceControlSystem.Tax(); break;
            case 3: FinanceControlSystem.Transactions(); break;
            case 4: Console.WriteLine("Exit"); break;
            default: Console.WriteLine("Invalid choice"); break;
        }
    } while (ch != 4);

    // Mini Project logic
    MiniProject.Run();
}
   }

