using System;
class Program
{
    public static void Main()
    {
        int choice = 0;
        do
        {
            Console.WriteLine("============== QuickMart Traders =============");
            Console.WriteLine("Create New Transaction (Enter Purchase & Selling Details)");
            Console.WriteLine("View Last Transaction");
            Console.WriteLine("Calculate Profit/Loss (Recompute & Print)");
            Console.WriteLine("Exit");
            Console.WriteLine("Enter your Options: ");
            try
            {
                choice = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine("Invalid Input");
                choice = 0;
            }
            switch(choice)
            {
                case 1:
                QuickMart.CreateTransaction();
                break;
                case 2:
                QuickMart.ViewTransaction();
                break;
                case 3:
                QuickMart.CalculatePorL();
                break;
                case 4:
                Console.WriteLine("Thank you. Application closed normally.");
                break;
                default:
                Console.WriteLine("Invalid Input.");
                break;
            }
        }while (choice != 4);
    }
}