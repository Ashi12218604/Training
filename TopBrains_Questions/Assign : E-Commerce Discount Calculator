using System;
using System.Collections.Generic;

class ECommerceDiscount
{
    static void Main()
    {
        Console.WriteLine("=== E-COMMERCE DISCOUNT CALCULATOR ===\n");
        
        // Sample data: CustomerType, PurchaseAmount
        List<(char, double)> purchases = new List<(char, double)>
        {
            ('R', 150.00),  // Regular, > $100
            ('R', 80.00),   // Regular, < $100
            ('P', 120.00),  // Premium
            ('V', 250.00),  // VIP, > $200
            ('V', 180.00),  // VIP, < $200
            ('R', 500.00)   // Regular, large purchase
        };
        
        foreach (var purchase in purchases)
        {
            ProcessPurchase(purchase.Item1, purchase.Item2);
            Console.WriteLine("------------------------");
        }
    }
    
    static void ProcessPurchase(char customerType, double purchaseAmount)
    {
        //Write Your Logic here
        string customerName = GetCustomerTypeName(customerType);
        double discountRate = CalculateDiscountRate(customerType, purchaseAmount);
        double discountAmount = purchaseAmount * discountRate;
        double finalPrice = purchaseAmount - discountAmount;
        Console.WriteLine($"Customer Type: {customerName}");
        Console.WriteLine($"Original Price: ${purchaseAmount:F2}");
        Console.WriteLine($"Discount Applied: {discountRate:P0}");
        Console.WriteLine($"Discount Amount: ${discountAmount:F2}");
        Console.WriteLine($"Final Price: ${finalPrice:F2}");
    }
    
    static double CalculateDiscountRate(char customerType, double purchaseAmount)
    {
       //Write your logic here
       if(customerType == 'R')
       {
            if(purchaseAmount > 100)
            {
                return 0.05;
            }
            else 
            {
                return 0.0;
            }
       }
       else if(customerType == 'P')
       {
        return 0.10;
       }
       else if(customerType == 'V')
        {
             if(purchaseAmount > 200)
             {
                return 0.20;
             }
            else{
                return 0.15;
            }
       }
       return 0.0;
    }
    
    static string GetCustomerTypeName(char customerType)
    {
        return customerType switch
        {
            'R' => "Regular",
            'P' => "Premium",
            'V' => "VIP",
            _ => "Unknown"
        };
    }
}
