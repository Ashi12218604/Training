using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace _06Jan2026.EcommereceAssessment
{
    class Program
    {
        static void Main(String[] args)
        {
            Repository<Order> orderRepo = new Repository<Order>();
            orderRepo.Add(new Order {OrderId = 1, CustomerName = "Alice", Amount = 5000});
            orderRepo.Add(new Order {OrderId = 2, CustomerName = "Bob", Amount = 2000});
            orderRepo.Add(new Order {OrderId = 3, CustomerName = "Charlie", Amount = 8000});
            Func<double, double> taxCalculator = amount => amount * 0.18;
            Func<double, double> discountCalculator = amount => amount * 0.05;
            Predicate<Order> validator = order => order.Amount >= 3000;
            OrderCallback callback = message =>
            {
                Console.WriteLine($"Callback: {message}");
            };
            OrderProcessor processor = new OrderProcessor();
            Action<string> logger = msg => Console.WriteLine($"Logger: {msg}");
            Action<string> notifier = msg => Console.WriteLine($"Notifier: {msg}");
            processor.OrderProcessed += logger;
            processor.OrderProcessed += notifier;
            foreach (Order order in orderRepo.GetAll())
            {
                processor.ProcessOrder(
                    order,
                    taxCalculator,
                    discountCalculator,
                    validator,
                    callback
                );
                Console.WriteLine();
            }
            List<Order> processedOrders = orderRepo.GetAll();
            processedOrders.Sort((o1, o2) => o2.Amount.CompareTo(o1.Amount));
            Console.WriteLine("Sorted Orders (Descending Amount): ");
            foreach(Order order in processedOrders)
            {
                Console.WriteLine(order);
            }
        }
    }
}