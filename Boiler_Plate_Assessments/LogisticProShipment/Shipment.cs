using System;
    public class Shipment
    {
        public string ShipmentCode{get;set;}
        public string TransportMode{get;set;}
        public double Weight{get;set;}
        public int StorageDays{get;set;}
        public Shipment(string sc, string t, double w, int sd)
        {
            ShipmentCode=sc;
            TransportMode=t;
            Weight=w;
            StorageDays=sd;
        }
    }
