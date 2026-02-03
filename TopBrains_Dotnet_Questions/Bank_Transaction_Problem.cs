using System;

public class Solution
{
    public static int FinalBalance(int initialBalance, int[] transactions)
    {
        int balance = initialBalance;

        for (int i = 0; i < transactions.Length; i++)
        {
            int t = transactions[i];

            if (t >= 0)
                balance += t;
            else if (balance + t >= 0)
                balance += t;
        }

        return balance;
    }

    public static void Main()
    {
        int initialBalance = Convert.ToInt32(Console.ReadLine());
        int n = Convert.ToInt32(Console.ReadLine());
        int[] transactions = new int[n];

        for (int i = 0; i < n; i++)
            transactions[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(FinalBalance(initialBalance, transactions));
    }
}
