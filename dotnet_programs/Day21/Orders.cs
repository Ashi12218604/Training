using System;
using System.Collections.Generic;

namespace StoreApp
{
    public class Order
    {
        public int OrderId{get;set;}
        public int CustomerId{get;set;}
        public string OrderStatus{get;set;}
        public DateTime OrderDate{get;set;}
        public DateTime RequiredDate{get;set;}
        public DateTime ShippedDate{get;set;}

        public int StoreId{get;set;}
        public int StaffId{get;set;}

        public List<OrderItem> Items{get;set;}=new();
    }
}
