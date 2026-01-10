using System;
using System.Collections.Generic;

public class Trade
{
    public int TradeId { get; set; }
    public string Symbol { get; set; }
    
    public override string ToString()
    {
        return $"TradeId: {TradeId}, Stock Symbol: {Symbol}";
    }
}
public class Repository<T>
{
    public T Item {get;set;}
}

public class Printer
{
    public void PrintData<T>(T value)
    {
        Console.WriteLine($"Printer Output: {value}");
    }
}

public class Container<T>
{
    private List<T> items=new List<T>();
    public void Add(T item)
    {
        items.Add(item);
    }
    public List<T> GetAll()
    {
        return items;
    }
}