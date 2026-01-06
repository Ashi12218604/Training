using System;
class Program
{
    static void Main()
    {
        PaymentService service=new PaymentService();
        PaymentDelegate payment = service.ProcessPayment; //delegate assignment
        decimal amount=5000;
        if(amount.IsValidPayment())
        {
        payment(amount);
    }
    else
        {
            Console.WriteLine("Invalid Payment Amount");
        }
}
}