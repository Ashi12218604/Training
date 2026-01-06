using System;
delegate void OrderDelegate(string orderId);
class NotificationService
{
    public void SendEmail(String id)
    {
        Console.WriteLine("Email sent for Order "+ id);
    }
    public void SendSMS(string id)
    {
        Console.WriteLine("SMS sent for order "+id);
    }
}