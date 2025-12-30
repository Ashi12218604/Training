using System;
public class SaleTransaction
{
    public string InvoiceNo{get; set;}
    public string CustomerName{get; set;}
    public string ItemName{get; set;}
    public int Quantity{get; set;}
    public decimal PurchaseAmount{get; set;}
    public decimal SellingAmount{get; set;}
    public string ProfitOrLossStatus{get; set;}
    public decimal ProfitOrLossAount{get; set;}
    public decimal ProfitMarginPercent{get; set;}
}
public class QuickMart
    {
        public static SaleTransaction LastTransaction = null;
        public static bool HasLastTransaction = false;
        public static void CreateTransaction()
    {
        Console.WriteLine("Enter InvoiceNo: ");
        string inv = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(inv))
        {
            Console.WriteLine("Invoice can't be Empty");
            return;
        }
        Console.WriteLine("Enter Customer Name: ");
        string name = Console.ReadLine();
        Console.WriteLine("Enter Item Name: ");
        string Item = Console.ReadLine();
        Console.WriteLine("Enter the Quantity: ");
        int quan = Convert.ToInt32(Console.ReadLine());
        if (quan <= 0)
        {
            Console.WriteLine("Quantity must be above zero");
            return;
        }
        Console.WriteLine("Enter Purchase Amount: ");
        decimal purAount = Convert.ToDecimal(Console.ReadLine());
        if (purAount <= 0)
        {
            Console.WriteLine("Quantity must be above zero");
            return;
        }
        Console.WriteLine("Enter the Selling Amount: ");
        decimal Sellamt = Convert.ToDecimal(Console.ReadLine());
        if (Sellamt < 0)
        {
            Console.WriteLine("Quantity cannot be Negative");
            return;
        }
        SaleTransaction s = new SaleTransaction();
        s.InvoiceNo = inv;
        s.CustomerName = name;
        s.ItemName = Item;
        s.Quantity = quan;
        s.PurchaseAmount = purAount;
        s.SellingAmount = Sellamt;
        if(Sellamt > purAount)
        {
            s.ProfitOrLossStatus = "PROFIT";
            s.ProfitOrLossAount = Sellamt - purAount;
        }
        else if(Sellamt < purAount)
        {
            s.ProfitOrLossStatus = "LOSS";
            s.ProfitOrLossAount = purAount - Sellamt;
        }
        else
        {
            s.ProfitOrLossStatus = "BREAK-EVEN";
            s.ProfitOrLossAount = 0;
        }
        s.ProfitMarginPercent = (s.ProfitOrLossAount/s.PurchaseAmount) * 100;
        LastTransaction = s;
        HasLastTransaction = true;
        Console.WriteLine("Transaction saved successfully..");
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAount.ToString("0.00"));
        Console.WriteLine("Profit Margin(%): " + LastTransaction.ProfitMarginPercent);
        Console.WriteLine("-------------------------------------------------------------------------------------");
    }
    public static void ViewTransaction()
    {
        if (!HasLastTransaction || LastTransaction == null)
        {
            Console.WriteLine("No transaction available. Please create a new transaction first.");
            return;
        }
        Console.WriteLine("-------------- Last Transaction----------------");
        Console.WriteLine("Invoice No: " + LastTransaction.InvoiceNo);
        Console.WriteLine("Customer: " + LastTransaction.CustomerName);
        Console.WriteLine("Item: " + LastTransaction.ItemName);
        Console.WriteLine("Quantity: " + LastTransaction.Quantity);
        Console.WriteLine("Purchase Amount: " + LastTransaction.PurchaseAmount.ToString("0.00"));
        Console.WriteLine("Selling Amount: " + LastTransaction.SellingAmount.ToString("0.00"));
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAount.ToString("0.00"));
        Console.WriteLine("Profit Margin: " + LastTransaction.ProfitMarginPercent.ToString("0.00"));
        Console.WriteLine("-----------------------------------------------------------------------------");
    }
    public static void CalculatePorL()
    {
        Console.WriteLine("Status: " + LastTransaction.ProfitOrLossStatus);
        Console.WriteLine("Profit/Loss Amount: " + LastTransaction.ProfitOrLossAount.ToString("0.00"));
    }
    }