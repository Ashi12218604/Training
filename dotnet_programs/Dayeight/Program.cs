using System;

public class Exceptions
{
    public static void Main()
    {
        // int a = 10;
        // int b = 0;

        // try
        // {
        //     int res = a / b;
        // }
        // catch (Exception ex)
        // {
        //     Console.WriteLine("Error occurred: " + ex.Message);
        // }



        TestCase("ACC123",5000,2000);
            TestCase("ACC567",3000,4000);
            TestCase("ACC890",1000,-500);
            TestCase("",1000,200);
        }

        static void TestCase(string accNo,decimal balance,decimal withdrawAmount)
        {
            try
            {
                BankAccounts account=new BankAccounts(accNo,balance);
                Console.WriteLine($"Account Created:{account.AccountNumber}, Balance:{account.Balance}");
                account.Withdraw(withdrawAmount);
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine("Handled in Main:"+ex.Message);
            }
            catch(BankOperationException ex)
            {
                Console.WriteLine("Bank Operation Failure:");
                Console.WriteLine("Message:"+ex.Message);
                Console.WriteLine("Root Cause:"+ex.InnerException?.Message);
            }
            catch(Exception ex)
            {
                Console.WriteLine("Unexpected Error:"+ex.Message);
            }
    }
}
