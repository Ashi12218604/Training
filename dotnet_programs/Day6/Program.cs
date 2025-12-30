using System;
using System.Linq.Expressions;
using System.Runtime.InteropServices.Marshalling;
class Program
{
    public static void Main(String[] args)
    {
        // StockPrice st=new StockPrice
        // {
        //     symbol="AAPL",
        //     price=150
        // };
        // StockPrice copy=st;
        // copy.price=155;
        // Console.WriteLine("Original Price:"+st.price);
        // Console.WriteLine("Copied Price:"+copy.price);

        // Trade t=new Trade
        // {
        //     tradeid=101,
        //     symbol="AAPL",
        //     quant=100            
        // };
        // Trade cp=t;
        // cp.quant=200;
        // Console.WriteLine("Original Quantity:"+t.quant);
        // Console.WriteLine("Copied Quantity:"+cp.quant);

/* In case of struct : When you write StockPrice copy = st, creates a complete independent copy of the data
Both st and copy exist as separate blocks in memory
**IDEAL FOR HIGH FREQUENCY DATA**

In case of class:   When you write Trade cp = t;
we are not copying the data. Instead copying the address (reference) to the data in memory.
Both t and cp point to the same object on the heap */

//******************************************************************************************************************
Portfolio p1=new Portfolio{Name="Ashi"};
Portfolio p2=new Portfolio{Name="Ashi"};
Console.WriteLine("The two words are same:"+p1.Equals(p2));
// I we wrote Console.WriteLine(p1==p2) -> It will give False as output because it check for Reference Equality
        int a = p1.GetHashCode();
        int b = p2.GetHashCode();
        Console.WriteLine(a);
        Console.WriteLine(b);

//******************************************************************************************************************
Trade t=new EquityTrade();
Console.WriteLine(t.GetType());
//******************************************************************************************************************
Repository<Customer> customerRepo = new Repository<Customer>();
customerRepo.Data = new Customer { name = "Ashi" };
Console.WriteLine("Generics data is: " + customerRepo.Data.name);
//******************************************************************************************************************
Calculator calc=new Calculator();
int c=calc.Calculate(10,20);
string res=calc.Calculate("Ashi","Arnav");
Console.WriteLine("Integer Result: " + c);
Console.WriteLine("String Result: " + res);
// Console.WriteLine("String Result: " + calc.Calculate(10.33,67.5));
//******************************************************************************************************************
    }
}