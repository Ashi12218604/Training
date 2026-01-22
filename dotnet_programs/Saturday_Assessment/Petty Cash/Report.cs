using System;
using System.Linq;
using System.Collections.Generic;

namespace PettyCash
{
    public class Report
    {
        public void Show(List<Voucher> vouchers, string expenseType)
        {
            var filtered=vouchers
                .Where(v=>v.ExpenseType.Equals(expenseType, StringComparison.OrdinalIgnoreCase)).ToList();
            if (!filtered.Any())
            {
                Console.WriteLine("There is no expense that you have entered.");
                return;
            }
            decimal total = 0;
            Console.WriteLine($"\nExpense Report for: {expenseType}");
            foreach (var v in filtered)
            {
                Console.WriteLine($"{v.Date:dd-MMM-yyyy} | Amount: {v.Amount}");
                total+=v.Amount;
            }
            Console.WriteLine($"Total {expenseType} Expense: {total}");
        }
    }
}
