using System;
using System.Collections.Generic;
public class RealEstateListing
{
    public int ID { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Price { get; set; }
    public string Location { get; set; }

    public RealEstateListing() { }

    public RealEstateListing(int id, string title, string descr, int p, string location)
    {
        ID = id;
        Title = title;
        Description = descr;
        Price = p;
        Location = location;
    }
}
