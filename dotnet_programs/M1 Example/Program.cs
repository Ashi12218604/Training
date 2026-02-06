using System;
using System.Collections.Generic;

public class Program
{
    public static Stack<Order> OrderStack { get; set; } = new Stack<Order>();

    public static void Main(string[] args)
    {
        Order obj = new Order();

        int orderId = Convert.ToInt32(Console.ReadLine());
        string customerName = Console.ReadLine();
        string item = Console.ReadLine();

        obj.AddOrderDetails(orderId, customerName, item);

        Console.WriteLine(obj.GetOrderDetails());

        obj.RemoveOrderDetails();

        if (OrderStack.Count == 0)
        {
            Console.WriteLine("No Orders");
        }
        else
        {
            foreach (Order o in OrderStack)
            {
                Console.WriteLine(o.OrderId + " " + o.CustomerName + " " + o.Item);
            }
        }
    }
}
