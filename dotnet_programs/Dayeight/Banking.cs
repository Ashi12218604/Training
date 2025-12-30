using System;
using System.IO;
public class InsufficientBalanceException:Exception
    {
        public InsufficientBalanceException(string message):base(message){}
    }

    public class BankOperationException:Exception
    {
        public BankOperationException(string message,Exception inner):base(message,inner){}
    }

    public class BankAccounts
    {
        public string AccountNumber{get;private set;}
        public decimal Balance{get;private set;}

        public BankAccounts(string accountNumber,decimal initialBalance)
        {
            if(string.IsNullOrWhiteSpace(accountNumber))
                throw new ArgumentException("Account number cannot be null or empty.");
            if(initialBalance<0)
                throw new ArgumentException("Initial balance cannot be negative.");
            AccountNumber=accountNumber;
            Balance=initialBalance;
        }

        public void Withdraw(decimal amount)
        {
            try
            {
                if(amount<=0)
                    throw new ArgumentException("Withdrawal amount must be greater than zero.");
                if(amount>Balance)
                    throw new InsufficientBalanceException($"Insufficient Balance. Current Balance:{Balance}, Requested:{amount}");
                Balance-=amount;
                Console.WriteLine($"Withdrawal Successful! Remaining Balance:{Balance}");
            }
            catch(InsufficientBalanceException ex)
            {
                LogException(ex);
                Console.WriteLine("Withdrawal Failed:"+ex.Message);
                throw;
            }
            catch(Exception ex)
            {
                LogException(ex);
                throw new BankOperationException("Unexpected banking error occurred.",ex);
            }
        }

        private void LogException(Exception ex)
        {
            string path="BankLogs.txt";
            string log="\n----------------------------------------"+
                       $"\nDateTime:{DateTime.Now}"+
                       $"\nAccountNo:{AccountNumber}"+
                       $"\nException:{ex}"+
                       "\n----------------------------------------";
            File.AppendAllText(path,log);
        }
    }