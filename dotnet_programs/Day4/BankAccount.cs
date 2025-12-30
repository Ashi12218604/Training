using System;
class BankAccount
{
    public int accnum;
    public double balance;
    public double amount;
    public BankAccount(int accnum,double balance)
    {
        this.accnum=accnum;
        this.balance=balance;
    }
    public void DisplayAccount()
    {
        Console.WriteLine("Account Number: "+accnum);
        Console.WriteLine("Balance: "+(double)balance);
    }
    public void Deposit(double amount)
    {
        balance+=amount;
        Console.WriteLine($"Updated Balance={balance}");
        
    }
}
class Employee
{
    public string name;
    public double salary;
    public Employee(string name,double salary)
    {
        this.name=name;
        this.salary=salary;
    }
   public void DisplayEmployee()
    {
        Console.WriteLine("Employee Name: "+name);
        Console.WriteLine("Salary: "+(double)salary);
    }
}

