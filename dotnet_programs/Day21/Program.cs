using System;
using StoreApp;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Customer c1=new Customer
        {
            CustomerId=1,
            FirstName="Ashi",
            LastName="Gupta",
            Email="ashi@gmail.com",
            Phone="8791379845",
            City="Dehradun"
        };

        Store s1=new Store
        {
            StoreId=1,
            StoreName="Capgemini",
            City="Mumbai"
        };

        Staff st1=new Staff
        {
            StaffId=1,
            FirstName="Tamanna",
            LastName="Singh",
            StoreId=1,
            Active=true
        };

        Order order=new Order
        {
            OrderId=101,
            CustomerId=c1.CustomerId,
            StoreId=s1.StoreId,
            StaffId=st1.StaffId,
            OrderStatus="Confirmed",
            OrderDate=DateTime.Now,
            RequiredDate=DateTime.Now.AddDays(3)
        };

        order.Items.Add(new OrderItem
        {
            OrderId=101,
            ItemId=1,
            ProductId=501,
            Quantity=2,
            ListPrice=1500,
            Discount=0.1f
        });

        Console.WriteLine("Order Created Successfully\n");

        Console.WriteLine("Customer: "+c1.FirstName+" "+c1.LastName);
        Console.WriteLine("Store: "+s1.StoreName);
        Console.WriteLine("Handled By: "+st1.FirstName);
        Console.WriteLine("Order Status: "+order.OrderStatus);

        foreach(var item in order.Items)
        {
            Console.WriteLine($"Product:{item.ProductId} Qty:{item.Quantity} Price:{item.ListPrice}");
        }
    }
}
