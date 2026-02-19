public class Jewellery
{
    public string Id{get;set;}
    public string Type{get;set;}
     public string Material{get;set;}
    public int Price{get;set;}
    public Jewellery(string id,string type,string material,int p)
    {
        Id=id;
        Type=type;
        Material=material;
        Price=p;    
    }
}