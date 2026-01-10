using System;

namespace LogisticsApp
{
    public class Shipment
    {
        public string ShipmentCode { get; set; }
        public string TransportMode { get; set; }
        public double Weight { get; set; }
        public int StorageDays { get; set; }
    }

    public class ShipmentDetails : Shipment
    {
        public bool ValidateShipmentCode()
        {
            if (string.IsNullOrEmpty(ShipmentCode))
                return false;

            if (ShipmentCode.Length != 6)
                return false;

            if (!ShipmentCode.StartsWith("GC#"))
                return false;

            string digits = ShipmentCode.Substring(3);

            foreach (char c in digits)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }

        public double CalculateTotalCost()
        {
            double pricePerKg = 0;

            if (TransportMode == "Sea")
                pricePerKg = 15;
            else if (TransportMode == "Air")
                pricePerKg = 50;
            else if (TransportMode == "Land")
                pricePerKg = 25;

            double total = (Weight * pricePerKg) + Math.Sqrt(StorageDays);
            return total;
        }
    }
}
