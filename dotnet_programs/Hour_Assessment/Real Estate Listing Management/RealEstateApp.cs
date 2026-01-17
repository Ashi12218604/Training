using System;
using System.Collections.Generic;
using System.Linq;
public class RealEstateApp
{
    private List<IRealEstateListing> estates =new List<IRealEstateListing>();
    public void AddListing(IRealEstateListing estate)
    {
        if(estate!=null)
        {
            estates.Add(estate);
        }
    }
    public void RemoveListing(int listingID)
    {
        var estate=estates.FirstOrDefault(e => e.ID ==listingID);
        if(estate!=null)
                {
          estates.Remove(estate);  
        }
    }
    public void UpdateListing(IRealEstateListing updatedListing)
    {
        var estate= estate.FirstOrDefault(e =>e.ID ==UpdateListing.ID);
        if(estate!=null)
        {
            estate.Title=UpdateListing.Title;
            estate.Description = updatedListing.Description;
            estate.Price = updatedListing.Price;
            estate.Location = updatedListing.Location;    
        }
    }
    public void GetListings()
    {
        retuns estates;
    }
   public List<RealEstateListing> GetListingsByLocation(string location)
    {
        return estates
            .Where(e=> e.Location.Equals(location, StringComparison.OrdinalIgnoreCase))
            .ToList();
    }
    public List<RealEstateListing> GetListingsByPriceRange(int minPrice, int maxPrice)
    {
        return estates
            .Where(e => e.Price >= minPrice && e.Price <= maxPrice)
            .ToList();
    }
}