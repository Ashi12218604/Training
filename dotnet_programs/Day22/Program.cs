using System;
public class Program
{
    public static void Main(String[] args)
    {
        // Export.ListAdd();


        // ICar car=new Car();
        // car.Gear1();
        // car.Gear2();
        // car.Gear3();
        // car.Gear4();
        // car.Gear5();
        // car.Gear6();

        // NanoCar n=new Nano();
        // n.Gear1();
        // n.Gear2();
        // n.Gear3();
        // n.Audio();

        AddDelegate a=new AddDelegate(Delegates.Add);
        SubtDelegate s=new SubtDelegate(Delegates.Sub);
        FindLengthDelegate f=new FindLengthDelegate(Delegates.FindLength);

        // Console.WriteLine("Add: " + a(10, 5));
        // Console.WriteLine("Sub: " + s(10, 5));
        // Console.WriteLine("Length: " + f("Ashi"));

        Console.WriteLine(Calculator.Add(10, 5));
        Console.WriteLine(Calculator.Mul(10, 5));
        Console.WriteLine(Calculator.Subtract(10, 5));


    }
}

