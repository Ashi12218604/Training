using System;
class Program
{
    static void Main()
    {

        Container<double> stockPrices = new Container<double>();
        Console.WriteLine("Enter Stock Prices");
        for (int i=1;i<=2;i++)
        {
            Console.Write($"Enter Stock Price {i}: ");
            stockPrices.Add(double.Parse(Console.ReadLine()));
        }
        Console.WriteLine("\nStock Prices List:");
        foreach (var price in stockPrices.GetAll()) 
            Console.WriteLine(price);

        Container<int> transactionIds = new Container<int>();
        Console.WriteLine("\nEnter Transaction IDs");
        for (int i=1;i<=2;i++)
        {
            Console.Write($"Enter Transaction ID {i}: ");
            transactionIds.Add(int.Parse(Console.ReadLine()));
        }
        Console.WriteLine("\nTransaction IDs List:");
        foreach (var id in transactionIds.GetAll()) 
            Console.WriteLine(id);

        Console.WriteLine("\nEnter Trade Details");
        Trade userTrade=new Trade();
        Console.Write("Enter Trade ID: ");
        userTrade.TradeId=int.Parse(Console.ReadLine());
        Console.Write("Enter Stock Symbol: ");
        userTrade.Symbol=Console.ReadLine();
        Repository<Trade> tradeRepo=new Repository<Trade>();
        tradeRepo.Item=userTrade;
        Console.WriteLine("Stored Trade in Repository:");
        Console.WriteLine(tradeRepo.Item);
        Console.WriteLine("\nPrinter Generic Method");
        Printer printer=new Printer();
        Console.Write("Enter a string: ");
        printer.PrintData(Console.ReadLine());
        Console.Write("Enter an integer: ");
        printer.PrintData(int.Parse(Console.ReadLine()));
        Console.Write("Enter a decimal: ");
        printer.PrintData(decimal.Parse(Console.ReadLine()));
    }
}





 
    
