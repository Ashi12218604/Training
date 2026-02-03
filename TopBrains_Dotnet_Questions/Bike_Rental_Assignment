using System;
using System.Collections.Generic;

namespace BikeRental
{
    public class Bike
    {
        public string Model { get; set; }
        public int PricePerDay { get; set; }
        public string Brand { get; set; }

        public Bike(string model, string brand, int pricePerDay)
        {
            Model = model;
            Brand = brand;
            PricePerDay = pricePerDay;
        }
    }

    public class BikeUtility
    {
        public void AddBikeDetails(string model, string brand, int pricePerDay)
        {
            int key = Program.bikeDetails.Count + 1;

            Bike bike = new Bike(model, brand, pricePerDay);

            Program.bikeDetails.Add(key, bike);

            Console.WriteLine("Bike details added successfully");
        }

        public SortedDictionary<string, List<Bike>> GroupBikesByBrand()
        {
            SortedDictionary<string, List<Bike>> result =
                new SortedDictionary<string, List<Bike>>();

            foreach (var item in Program.bikeDetails)
            {
                Bike bike = item.Value;

                if (!result.ContainsKey(bike.Brand))
                {
                    result[bike.Brand] = new List<Bike>();
                }

                result[bike.Brand].Add(bike);
            }

            return result;
        }
    }

    class Program
    {
        public static SortedDictionary<int, Bike> bikeDetails =
            new SortedDictionary<int, Bike>();

        static void Main(string[] args)
        {
            BikeUtility utility = new BikeUtility();

            while (true)
            {
                Console.WriteLine("\n1. Add Bike Details");
                Console.WriteLine("2. Group Bikes By Brand");
                Console.WriteLine("3. Exit");
                Console.Write("\nEnter your choice: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                if (choice == 1)
                {
                    Console.Write("\nEnter the model: ");
                    string model = Console.ReadLine();

                    Console.Write("Enter the brand: ");
                    string brand = Console.ReadLine();

                    Console.Write("Enter the price per day: ");
                    int price = Convert.ToInt32(Console.ReadLine());

                    utility.AddBikeDetails(model, brand, price);
                }
                else if (choice == 2)
                {
                    var grouped = utility.GroupBikesByBrand();

                    foreach (var item in grouped)
                    {
                        string brand = item.Key;
                        List<Bike> bikes = item.Value;

                        foreach (var bike in bikes)
                        {
                            Console.WriteLine(brand + " " + bike.Model);
                        }
                    }
                }
                else if (choice == 3)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice");
                }
            }
        }
    }
}
