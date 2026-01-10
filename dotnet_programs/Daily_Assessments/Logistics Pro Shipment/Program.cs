using System;
using LogisticsApp;

class Program
{
    static void Main(string[] args)
    {
        ShipmentDetails shipment = new ShipmentDetails();

        Console.WriteLine("Enter the shipment code:");
        shipment.ShipmentCode = Console.ReadLine();

        if (shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Enter transport mode (Sea/Air/Land):");
            shipment.TransportMode = Console.ReadLine();

            Console.WriteLine("Enter weight (kg):");
            shipment.Weight = double.Parse(Console.ReadLine());

            Console.WriteLine("Enter storage days:");
            shipment.StorageDays = int.Parse(Console.ReadLine());

            double finalCost = shipment.CalculateTotalCost();
            Console.WriteLine($"The total shipping cost is {finalCost:F2}");
        }
        else
        {
            Console.WriteLine("Invalid shipment code");
        }
    }
}
