using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace _06Jan2026.EcommereceAssessment
{
    public class Repository<T>
    {
        private List<T> items = new List<T>();
        public void Add(T item)
        {
            items.Add(item);
        }
        public List<T> GetAll()
        {
            return items;
        }
    }
    public class Order
    {
        public int OrderId{get; set;}
        public string CustomerName{get; set;}
        public double Amount{get; set;}
        public override string ToString()
        {
            return $"OrderId: {OrderId}, Customer: {CustomerName}, Amount: {Amount}";
        }
    }
    public delegate void OrderCallback(string message);
    public class OrderProcessor
    {
        public event Action<string> OrderProcessed;
        public void ProcessOrder(Order order,
            Func<double, double> taxCalculator,
            Func<double, double> discountCalculator,
            Predicate<Order> validator,
            OrderCallback callback)
        {
            if (!validator(order))
            {
                callback("Order Validation failed.");
                return;
            }
            double tax = taxCalculator(order.Amount);
            double discount = discountCalculator(order.Amount);
            order.Amount = order.Amount + tax - discount;
            callback($"Order {order.OrderId} processed successfully.");
            OrderProcessed?.Invoke($"Event: Order {order.OrderId} completed.");
        }
    }
}