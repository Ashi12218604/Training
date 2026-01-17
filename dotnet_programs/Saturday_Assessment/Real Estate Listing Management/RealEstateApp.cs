using System;
using System.Collections.Generic;
using System.Linq;

public class RealEstateApp
{
    private List<RealEstateListing> estates = new List<RealEstateListing>();

    public void AddListing(RealEstateListing estate)
    {
        if (estate != null)
        {
            estates.Add(estate);
        }
    }

    public void RemoveListing(int listingID)
    {
        var estate = estates.FirstOrDefault(e => e.ID == listingID);
        if (estate != null)
        {
            estates.Remove(estate);
        }
    }

    public void UpdateListing(RealEstateListing updatedListing)
    {
        var estate = estates.FirstOrDefault(e => e.ID == updatedListing.ID);
        if (estate != null)
        {
            estate.Title = updatedListing.Title;
            estate.Description = updatedListing.Description;
            estate.Price = updatedListing.Price;
            estate.Location = updatedListing.Location;
        }
    }

    public List<RealEstateListing> GetListings()
    {
        return estates;
    }

    public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return estates
            .Where(e => e.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }

    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        return estates
            .Where(e => e.Price >= minPrice && e.Price <= maxPrice)
            .ToList();
    }
}
