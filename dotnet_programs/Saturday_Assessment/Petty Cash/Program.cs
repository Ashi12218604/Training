using System;
using PettyCash;
class Program
{
    public static void Main()
    {
        IRepository<Voucher> repository = new VoucherRepository();
        Report report = new Report();
        Console.WriteLine("Expense Voucher System");
        while (true)
        {
            Console.WriteLine("\n1. Add Voucher");
            Console.WriteLine("2. Generate Expense Report");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            string choice = Console.ReadLine();
            if (choice=="1")
            {
                Console.Write("Enter Expense Type: ");
                string expenseType = Console.ReadLine();
                Console.Write("Enter Amount: ");
                decimal amount;
                while (!decimal.TryParse(Console.ReadLine(), out amount) || amount <= 0)
                {
                    Console.Write("Invalid amount. Re-enter: ");
                }
                Console.Write("Enter Date (dd-MM-yyyy): ");
                DateTime date;
                while (!DateTime.TryParseExact(
                    Console.ReadLine(),
                    "dd-MM-yyyy",
                    null,
                    System.Globalization.DateTimeStyles.None,
                    out date))
                {
                    Console.Write("Invalid date format. Re-enter (dd-MM-yyyy): ");
                }

                repository.Add(new Voucher(expenseType, amount, date));
            }
            else if (choice=="2")
            {
                Console.Write("Enter Expense Type for Report: ");
                string expenseType=Console.ReadLine();
                report.Show(repository.GetAll(), expenseType);
            }
            else if (choice=="3")
            {
                Console.WriteLine("You have exited.");
                break;
            }
            else
            {
                Console.WriteLine("Enter a valid choice from 1 to 3 only.");
            }
        }
    }
}
