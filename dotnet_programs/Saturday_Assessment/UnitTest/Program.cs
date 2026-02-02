using NUnit.Framework;
using System;

public class UnitTest
{

    public void Test_Deposit_ValidAmount()
    {
        Program account = new Program(1000);

        account.Deposit(500);

        Assert.AreEqual(1500, account.Balance);
    }

 
    public void Test_Deposit_NegativeAmount()
    {
        Program account = new Program(1000);

        var ex = Assert.Throws<Exception>(() => account.Deposit(-200));

        Assert.AreEqual("Deposit amount cannot be negative", ex.Message);
    }


    public void Test_Withdraw_ValidAmount()
    {
        Program account = new Program(1000);

        account.Withdraw(400);

        Assert.AreEqual(600, account.Balance);
    }

    
    public void Test_Withdraw_InsufficientFunds()
    {
        Program account = new Program(500);

        var ex = Assert.Throws<Exception>(() => account.Withdraw(1000));

        Assert.AreEqual("Insufficient funds.", ex.Message);
    }
}
