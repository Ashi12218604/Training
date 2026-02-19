using System;

public class PhoneCall
{
    public delegate void Notify();

    public event Notify PhoneCallEvent;

    public string Message { get; private set; }

    private void OnSubscribe()
    {
        Message = "Subscribed to Call";
    }

    private void OnUnSubscribe()
    {
        Message = "UnSubscribed to Call";
    }

    public void MakeAPhoneCall(bool notify)
    {
        PhoneCallEvent = null;

        if (notify)
            PhoneCallEvent += OnSubscribe;
        else
            PhoneCallEvent += OnUnSubscribe;

        PhoneCallEvent?.Invoke();
    }
}

public class Program
{
    public static void Main()
    {
        PhoneCall call = new PhoneCall();

        call.MakeAPhoneCall(true);
        Console.WriteLine(call.Message);

        call.MakeAPhoneCall(false);
        Console.WriteLine(call.Message);
    }
}
