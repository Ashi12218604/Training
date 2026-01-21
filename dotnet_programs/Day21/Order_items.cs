using System;
using System.Collections.Generic;
namespace StoreApp
{
    public class OrderItem
    {
        public int OrderId{get;set;}
        public int ItemId{get;set;}
        public int ProductId{get;set;}
        public int Quantity{get;set;}
        public decimal ListPrice{get;set;}
        public float Discount{get;set;}
    }
}
