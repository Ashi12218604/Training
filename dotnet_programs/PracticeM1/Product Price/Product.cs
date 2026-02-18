public class Product
{
    public int Id{get;set;}
    public string Name{get;set;}
    public double? Price{get;set;}
    public double DiscountPercentage{get;set;}
   public  Product(int id, string name, double? d, double dp)
    {
        Id=id;
        Name=name;
        Price=d;
        DiscountPercentage=dp;
    }
}