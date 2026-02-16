class Program
{    static void Main(string[] args)
    {
        string id = Console.ReadLine();
        string mode = Console.ReadLine();
        double weight = double.Parse(Console.ReadLine());
        int storage = int.Parse(Console.ReadLine());
        ShipmentDetails shipment =new ShipmentDetails(id, mode, weight, storage);
        if (!shipment.ValidateShipmentCode())
        {
            Console.WriteLine("Invalid shipment code");
            return;
        }
        double total = shipment.CalculateTotalCost();
        Console.WriteLine("The total shipping cost is " + total.ToString("F2"));
    }
}