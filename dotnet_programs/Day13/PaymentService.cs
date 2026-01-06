using System;
delegate void PaymentDelegate(decimal amount);
class PaymentService
{
    public void ProcessPayment(decimal amount)
    {
        Console.WriteLine("Payment of "+amount+ " processed successfully.");
    }
}
static class PaymentExtensions
{
    public static bool IsValidPayment(this decimal amount)
    {
        return amount>0 && amount<=1_000_000;
    }
}
