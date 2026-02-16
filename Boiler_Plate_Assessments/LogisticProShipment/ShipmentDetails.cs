 public class ShipmentDetails : Shipment
    {
        public ShipmentDetails(string sc, string t, double w, int sd):base(sc, t, w, sd)
        {
        }
        public bool ValidateShipmentCode()
        {
            if (ShipmentCode.Length!=7)
                return false;
            if (!ShipmentCode.StartsWith("GC#"))
                return false;
            return int.TryParse(ShipmentCode.Substring(3), out _);
        }
        public double Rate(string str)
        {
            if (str.Equals("Sea",StringComparison.OrdinalIgnoreCase))
                return 15.00;
            if (str.Equals("Air",StringComparison.OrdinalIgnoreCase))
                return 50.00;
            if (str.Equals("Land",StringComparison.OrdinalIgnoreCase))
                return 25.00;
            return 0.00;
        }

        public double CalculateTotalCost()
        {
            double rate=Rate(TransportMode);
            if (rate==0) return 0;
            return (Weight*rate)+Math.Sqrt(StorageDays);
        }
    }