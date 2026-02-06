using System;
using System.Collections.Generic;

public class Order
{
    public int OrderId { get; set; }
    public string CustomerName { get; set; }
    public string Item { get; set; }

    public Stack<Order> AddOrderDetails(int orderId, string customerName, string item)
    {
        Order order = new Order();
        order.OrderId = orderId;
        order.CustomerName = customerName;
        order.Item = item;

        Program.OrderStack.Push(order);

        return Program.OrderStack;
    }

    public string GetOrderDetails()
    {
        if (Program.OrderStack.Count == 0)
            return "No Orders";

        Order order = Program.OrderStack.Peek();

        return order.OrderId + " " + order.CustomerName + " " + order.Item;
    }

    public Stack<Order> RemoveOrderDetails()
    {
        if (Program.OrderStack.Count > 0)
        {
            Program.OrderStack.Pop();
        }

        return Program.OrderStack;
    }
}
