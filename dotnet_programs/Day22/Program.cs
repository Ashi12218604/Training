// using System;
// public class Program
// {
//     public static void Main(String[] args)
//     {
//         // Export.ListAdd();


//         // ICar car=new Car();
//         // car.Gear1();
//         // car.Gear2();
//         // car.Gear3();
//         // car.Gear4();
//         // car.Gear5();
//         // car.Gear6();

//         // NanoCar n=new Nano();
//         // n.Gear1();
//         // n.Gear2();
//         // n.Gear3();
//         // n.Audio();

//         AddDelegate a=new AddDelegate(Delegates.Add);
//         SubtDelegate s=new SubtDelegate(Delegates.Sub);
//         FindLengthDelegate f=new FindLengthDelegate(Delegates.FindLength);

//         // Console.WriteLine("Add: " + a(10, 5));
//         // Console.WriteLine("Sub: " + s(10, 5));
//         // Console.WriteLine("Length: " + f("Ashi"));

//         Console.WriteLine(Calculator.Add(10, 5));
//         Console.WriteLine(Calculator.Mul(10, 5));
//         Console.WriteLine(Calculator.Subtract(10, 5));


//     }
// }
using System;
using System.Collections.Generic;
public class Program
{
public static Stack<Order> OStack { get; set; } = new Stack<Order>();
public static void Main(string[] args)
{
Order ob=new Order();
int orderId=Convert.ToInt32(Console.ReadLine());
string customerName=Console.ReadLine();
string item=Console.ReadLine();
ob.AddOrderDetails(orderId, customerName, item);
Console.WriteLine(ob.GetOrderDetails());
ob.RemoveOrderDetails();
  foreach (Order o in OStack)
    {
        Console.WriteLine(o.OrderId + " " + o.CustomerName + " " + o.Item);
    }
}
}