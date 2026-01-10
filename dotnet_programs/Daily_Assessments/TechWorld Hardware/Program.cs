using System;
public class Program
{
    public static void Main()
    {
        Console.WriteLine("1.Desktop");
        Console.WriteLine("2.Laptop");
        Console.WriteLine("Choose the option");

        int option = Convert.ToInt32(Console.ReadLine());

        if (option == 1)
        {
            Desktop d = new Desktop();

            Console.WriteLine("Enter the processor");
            d.Processor = Console.ReadLine();

            Console.WriteLine("Enter the ram size");
            d.RamSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the hard disk size");
            d.HardDiskSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the graphic card size");
            d.GraphicCard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the monitor size");
            d.MonitorSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the power supply volt");
            d.PowerSupplyVolt = Convert.ToInt32(Console.ReadLine());

            double price = d.DesktopPriceCalculation();
            Console.WriteLine("Desktop price is " + price);
        }
        else if (option == 2)
        {
            Laptop l = new Laptop();

            Console.WriteLine("Enter the processor");
            l.Processor = Console.ReadLine();

            Console.WriteLine("Enter the ram size");
            l.RamSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the hard disk size");
            l.HardDiskSize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the graphic card size");
            l.GraphicCard = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the display size");
            l.DisplaySize = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter the battery volt");
            l.BatteryVolt = Convert.ToInt32(Console.ReadLine());

            double price = l.LaptopPriceCalculation();
            Console.WriteLine("Laptop price is " + price);
        }
    }
}
