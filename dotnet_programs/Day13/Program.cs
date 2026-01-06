
/*
Notes:
Action delgate: represents a method that does not return a value.
*/
using System;
class Program
{
    static void Main()
    {
     //*******************************************************************************************
// `` PaymentService.cs
    //     PaymentService service=new PaymentService();
    //     PaymentDelegate payment = service.ProcessPayment; //delegate assignment
    //     decimal amount=5000;
    //     if(amount.IsValidPayment())
    //     {
    //     payment(amount);
    // }
    // else
    //     {
    //         Console.WriteLine("Invalid Payment Amount");
    //     }
    //*******************************************************************************************
// `` OrderDelegate.cs 
    // NotificationService service=new NotificationService();
    // OrderDelegate notify=null;
    // notify+=service.SendEmail;
    // notify+=service.SendSMS;
    // notify("ORD1001");
    //*******************************************************************************************
// `` Logactivity
// Action<string> logActivity=message => Console.Writealaine("Log Entry: "+ message);
// logActivity("User logged in at 10:30 AM");

Func<decimal, decimal, decimal> calculateDiscount = (price, discount) => price - (price * discount / 100);
        Console.WriteLine(calculateDiscount(1000, 10));

        Predicate<int> isEligible = age => age >=18;
        Console.WriteLine("The user is eligible");


        ErrorDelegate errorHandler=delegate(string msg)
        {
            Console.WriteLine("Error:"+msg);
        };
        errorHandler("File not found");



        }
}
