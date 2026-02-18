using System;

class Account
{
    public int AccountNumber { get; set; }
    public string HolderName { get; set; }
    public double Balance { get; set; }

    public Account(int accNo, string name, double balance)
    {
        // TODO
        AccountNumber=accNo;
        HolderName=name;
        Balance=balance;
    }

    public void Deposit(double amount)
    {
        // TODO
        Balance+=amount;
    }

    public void Withdraw(double amount)
    {
        // TODO
        if(amount>Balance)
        {
            Console.WriteLine("Insufficient Balance");
        }
        else
        Balance-=amount;
    }
}

class Program
{
    static void Main()
    {
        string[] accInput = Console.ReadLine().Split();
        int accNo = int.Parse(accInput[0]);
        string name = accInput[1];
        double balance = double.Parse(accInput[2]);

        Account a = new Account(accNo, name, balance);
        int t = int.Parse(Console.ReadLine());
        for(int i = 0; i < t; i++)
        {
            string[] transaction = Console.ReadLine().Split();
            string type = transaction[0];
            double amount = double.Parse(transaction[1]);

            // TODO: Call appropriate method
            
    if(type=="Deposit")
            {
                a.Deposit(amount);
            }
            else if(type=="Withdraw")
            {
                a.Withdraw(amount);                
            }
            Console.WriteLine("Current Balance:" + a.Balance);
        }
    }
}
