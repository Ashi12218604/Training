using System;
class FinanceControlSystem
{    public static void CheckLoan()
    {
        Console.Write("Enter age: ");
        int age=Convert.ToInt32(Console.ReadLine());
        Console.Write("Enter monthly income: ");
        double income=Convert.ToDouble(Console.ReadLine());
        if (age>=21 && income>=30000)
            Console.WriteLine("Loan Eligible");
        else
            Console.WriteLine("Loan Not Eligible");
    }
    public static void Tax()
    {
        Console.Write("Enter annual income: ");
        double income=Convert.ToDouble(Console.ReadLine());
        double tax=0;
        if (income<=250000)
            tax=0;
        else if(income<=500000)
            tax=income*0.05;
        else if(income<=1000000)
            tax=income*0.20;
        else
            tax=income*0.30;
        Console.WriteLine($"Income Tax Payable: Rs.{tax}");
    }
        public static void Transactions()
    {
        double total=0;
        int c=0;
        Console.WriteLine("Enter 5 transactions:");
        while (c<5)
        {
            Console.Write($"Transaction {c+1}: ");
            double amount=Convert.ToDouble(Console.ReadLine());
            if (amount<0)
            {
                Console.WriteLine("Invalid transaction.Can't enter Negative Values");
                continue;
            }
            total+=amount;
            c++;
        }
        Console.WriteLine($"Total of valid transactions:Rs.{total}");
    }
}
