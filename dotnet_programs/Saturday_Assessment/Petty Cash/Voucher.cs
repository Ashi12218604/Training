using System;
namespace PettyCash
{
    public class Voucher
    {
        public string ExpenseType {get;}
        public decimal Amount {get;}
        public DateTime Date {get;}
        public Voucher(string exp, decimal amount, DateTime date)
        {
            ExpenseType = exp;
            Amount = amount;
            Date = date;
        }
    }
}