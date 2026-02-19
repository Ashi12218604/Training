using System;
using System.Collections.Generic;
using System.Linq;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public double Amount { get; set; }
    public string Status { get; set; }

    public Order(int id, string name, double amount, string status)
    {
        OrderId = id;
        CustomerName = name;
        Amount = amount;
        Status = status;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Order> orders = new List<Order>();

        for (int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            orders.Add(new Order(
                int.Parse(input[0]),
                input[1],
                double.Parse(input[2]),
                input[3]
            ));
        }

        var completed = orders
            .Where(o => o.Status == "Completed")
            .OrderByDescending(o => o.Amount)
            .ThenBy(o => o.CustomerName);

        double totalRevenue = 0;

        foreach (var order in completed)
        {
            Console.WriteLine($"{order.OrderId} {order.CustomerName} {order.Amount}");
            totalRevenue += order.Amount;
        }

        Console.WriteLine("Total Revenue: " + totalRevenue);
    }
}
