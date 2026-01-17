using System;
class Program
{    static void Main(string[] args)
    {
        RealEstateApp app = new RealEstateApp();
        app.AddListing(new RealEstateListing(1, "2BHK Flat", "Near metro", 5000000, "Delhi"));
        app.AddListing(new RealEstateListing(2, "Villa", "Sea view", 12000000, "Goa"));
        app.AddListing(new RealEstateListing(3, "Studio Apartment", "City center", 3000000, "Delhi"));
        Console.WriteLine("All Listings:");
        foreach (var e in app.GetListings())
        {
            Console.WriteLine($"ID: {e.ID}, Title: {e.Title}, Price: {e.Price}, Location: {e.Location}");
        }
        Console.WriteLine("\nListings in Delhi:");
        foreach (var e in app.GetListingsByLocation("Delhi"))
        {
            Console.WriteLine($"ID: {e.ID}, Title: {e.Title}, Price: {e.Price}, Location: {e.Location}");
        }
        Console.WriteLine("\nListings between 4M and 10M:");
        foreach (var e in app.GetListingsByPriceRange(4000000, 10000000))
        {
            Console.WriteLine($"ID: {e.ID}, Title: {e.Title}, Price: {e.Price}, Location: {e.Location}");
        }
        app.UpdateListing(new RealEstateListing(1, "2BHK Flat", "Renovated", 5500000, "Delhi"));
        app.RemoveListing(2);
        Console.WriteLine("\nAfter Update and Removal:");
        foreach (var e in app.GetListings())
        {
            Console.WriteLine($"ID: {e.ID}, Title: {e.Title}, Price: {e.Price}, Location: {e.Location}");
        }
    }
}
