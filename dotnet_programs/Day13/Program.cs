
/*
Notes:
Action delgate: represents a method that does not return a value.
*/
using System;
delegate void ErrorDelegate(string msg);

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
// `` Logactivity.cs Action Delegate
// Action<string> logActivity=message => Console.Writealaine("Log Entry: "+ message);
// logActivity("User logged in at 10:30 AM");

  //******************************************************************************************************************************
        // `` Func.cs
// Func<decimal, decimal, decimal> calculateDiscount = (price, discount) => price - (price * discount / 100);
//         Console.WriteLine(calculateDiscount(1000, 10));

  //******************************************************************************************************************************
        // `` Predicate.cs
        // Predicate<int> isEligible = age => age >=18;
        // Console.WriteLine("The user is eligible");

  //******************************************************************************************************************************
        // `` ErrorDelegate.cs
        // ErrorDelegate errorHandler=delegate(string msg)
        // {
        //     Console.WriteLine("Error:"+msg);
        // };
        // errorHandler("File not found");

        //******************************************************************************************************************************
        // `` Button.cs
        // Button btn=new Button();
        // btn.Clicked+=()=>Console.WriteLine("Button1 was clicked");
        // btn.Clicked+=()=>Console.WriteLine("Button2 was clicked");
        // btn.Clicked+=()=>Console.WriteLine("Button3 was clicked");
        // btn.Click();
        //******************************************************************************************************************************
        // `` Downloader.cs
        // Downloader d=new Downloader();
        // d.DownloadCompleted+=() => Console.WriteLine("Download completed");
        // d.CompleteDownload();



        Comparison<int> sortdescending=(a,b) =>b.CompareTo(a);
        Console.WriteLine(sortdescending(5,10));
Console.WriteLine(sortdescending(10,5));
Console.WriteLine(sortdescending(5,5));
        }
}

    //******************************************************************************************************************************
    // `` MotionSensor.cs
// using System;

// namespace SmartHomeSecurity
// {
//     class Program
//     {
//         static void Main()
//         {
//             MotionSensor livingRoomSensor = new MotionSensor();
//             AlarmSystem siren = new AlarmSystem();
//             PoliceNotifier police = new PoliceNotifier();

//             SecurityAction panicSequence = siren.SoundSiren;
//             panicSequence += police.CallDispatch;

//             livingRoomSensor.OnEmergency = panicSequence;

//             livingRoomSensor.DetectIntruder("Main Lobby");
//         }
//     }
// }
