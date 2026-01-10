    using System;
    class Program
    {
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
        public static void Main()
    {
        Chocolate choco = new Chocolate();

        Console.WriteLine("Enter the flavour");
        choco.Flavour = Console.ReadLine();

        Console.WriteLine("Enter the quantity");
        choco.Quantity = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter the price per unit");
        choco.PricePerUnit = Convert.ToInt32(Console.ReadLine());

        if (!choco.ValidateChocolateFlavour())
        {
            Console.WriteLine("Invalid flavour");
            return;
        }

        choco = CalculateDiscountedPrice(choco);

        Console.WriteLine("Flavour : " + choco.Flavour);
        Console.WriteLine("Quantity : " + choco.Quantity);
        Console.WriteLine("Price Per Unit : " + choco.PricePerUnit);
        Console.WriteLine("Total Price : " + choco.TotalPrice);
        Console.WriteLine("Discounted Price : " + choco.DiscountedPrice);
    }
}
