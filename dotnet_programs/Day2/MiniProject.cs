using System;

class MiniProject
{
    public static void Run()
    {
        int choice;
        do
        {
            Console.WriteLine("\n1. Debit Operations");
            Console.WriteLine("2. Credit Operations");
            Console.WriteLine("3. Exit");
            Console.Write("Enter choice: ");
            choice = Convert.ToInt32(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    DebitMenu();
                    break;
                case 2:
                    CreditMenu();
                    break;
                case 3:
                    Console.WriteLine("Program exited");
                    break;
                default:
                    Console.WriteLine("Invalid choice");
                    break;
            }
        } while (choice != 3);
    }

    static void DebitMenu()
    {
        int option;
        do
        {
            Console.WriteLine("\nDebit Menu");
            Console.WriteLine("1. ATM Withdrawal Check");
            Console.WriteLine("2. EMI Burden Check");
            Console.WriteLine("3. Daily Spending");
            Console.WriteLine("4. Minimum Balance Check");
            Console.WriteLine("5. Back");
            Console.Write("Enter option: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Debit.ATMWithdrawal();
                    break;
                case 2:
                    Debit.EMICheck();
                    break;
                case 3:
                    Debit.DailySpending();
                    break;
                case 4:
                    Debit.MinimumBal();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        } while (option != 5);
    }

    static void CreditMenu()
    {
        int option;
        do
        {
            Console.WriteLine("\nCredit Menu");
            Console.WriteLine("1. Net Salary");
            Console.WriteLine("2. Fixed Deposit Maturity");
            Console.WriteLine("3. Reward Points");
            Console.WriteLine("4. Bonus Eligibility");
            Console.WriteLine("5. Back");
            Console.Write("Enter option: ");
            option = Convert.ToInt32(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Credit.Salary();
                    break;
                case 2:
                    Credit.FD();
                    break;
                case 3:
                    Credit.RewardPoints();
                    break;
                case 4:
                    Credit.Bonus();
                    break;
                case 5:
                    break;
                default:
                    Console.WriteLine("Invalid option");
                    break;
            }
        } while (option != 5);
    }
}
class Debit
{
        public static void ATMWithdrawal()
    {
        const int dailyLimit=40000;

        Console.Write("Enter withdrawal amount: ");
        int amount=Convert.ToInt32(Console.ReadLine());

        if (amount<=dailyLimit)
            Console.WriteLine("Withdrawal permitted within daily limit.");
        else
            Console.WriteLine("Daily ATM withdrawal limit exceeded.");
    }
    public static void EMICheck()
    {
        Console.Write("Enter monthly income: ");
        double income=Convert.ToDouble(Console.ReadLine());

        Console.Write("Enter EMI amount: ");
        double emi=Convert.ToDouble(Console.ReadLine());

        if (emi<=income*0.40)
            Console.WriteLine("EMI is financially manageable.");
        else
            Console.WriteLine("EMI exceeds safe income limit.");
    }
    public static void DailySpending()
    {
        Console.Write("Enter number of transactions: ");
        int n=Convert.ToInt32(Console.ReadLine());
        double total=0;

        for (int i=1;i<=n;i++)
        {
            Console.Write($"Enter transaction {i} amount: ");
            total+=Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine($"Total debit amount for the day: {total}");
    }
    public static void MinimumBal()
    {
        const int minBalance=2000;
        Console.Write("Enter current balance: ");
        double balance = Convert.ToDouble(Console.ReadLine());
        if (balance>=minBalance)
            Console.WriteLine("Minimum balance requirement satisfied.");
        else
            Console.WriteLine("Minimum balance not maintained.");
    }
}
class Credit
{
          public static void Salary()
    {
        Console.Write("Enter gross salary: ");
        double gross=Convert.ToDouble(Console.ReadLine());
        double netSalary=gross-(gross * 0.10);
        Console.WriteLine($"Net salary credited: {netSalary}");
    }
    public static void FD()
    {
        Console.Write("Enter principal amount: ");
        double principal=Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter rate of interest: ");
        double rate=Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter time period (months): ");
        double time=Convert.ToDouble(Console.ReadLine());
        double interest=(principal*rate*time)/(100*12);
        double maturity=principal+interest;
        Console.WriteLine($"Fixed Deposit maturity amount: {maturity}");
    }
    public static void RewardPoints()
    {
        Console.Write("Enter total credit card spending: ");
        double spending=Convert.ToDouble(Console.ReadLine());
        int points=(int)(spending/100);
        Console.WriteLine($"Reward points earned: {points}");
    }
    public static void Bonus()
    {
        Console.Write("Enter annual salary: ");
        double salary=Convert.ToDouble(Console.ReadLine());
        Console.Write("Enter years of service: ");
        int years = Convert.ToInt32(Console.ReadLine());
        if (salary>=500000 && years>=3)
            Console.WriteLine("Employee is eligible for bonus.");
        else
            Console.WriteLine("Employee is not eligible for bonus.");
    }
}

