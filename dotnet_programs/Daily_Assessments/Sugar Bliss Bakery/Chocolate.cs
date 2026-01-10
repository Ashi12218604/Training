using System;
public class Chocolate
{
    public string Flavour { get; set; }
    public int Quantity { get; set; }
    public int PricePerUnit { get; set; }
    public double TotalPrice { get; set; }
    public double DiscountedPrice { get; set; }

    public bool ValidateChocolateFlavour()
    {
        if (Flavour == "Dark" || Flavour == "Milk" || Flavour == "White")
            return true;
        return false;
    }
    public static Chocolate CalculateDiscountedPrice(Chocolate chocolate)
    {
        chocolate.TotalPrice = chocolate.Quantity * chocolate.PricePerUnit;

        double discountPercent = 0;

        if (chocolate.Flavour == "Dark")
            discountPercent = 18;
        else if (chocolate.Flavour == "Milk")
            discountPercent = 12;
        else if (chocolate.Flavour == "White")
            discountPercent = 6;

        chocolate.DiscountedPrice = chocolate.TotalPrice -
                                   (chocolate.TotalPrice * discountPercent / 100);

        return chocolate;
    }
}

