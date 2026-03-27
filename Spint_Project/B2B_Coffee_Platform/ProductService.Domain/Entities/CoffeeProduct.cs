using System;
using System.Collections.Generic;
using System.Text;

namespace ProductService.Domain.Entities
{
    public class CoffeeProduct
    {
        // Primary Key
        public Guid Id { get; private set; }

        // Product Specifics
        public string Sku { get; private set; }
        public string Name { get; private set; } // e.g., "Ethiopian Yirgacheffe Single Origin"
        public string Description { get; private set; }
        public string RoastLevel { get; private set; } // Light, Medium, Dark, Espresso
        public string Origin { get; private set; } // Colombia, Ethiopia, Blend

        // Packaging & Wholesale Volumes
        public int BagWeightGrams { get; private set; } // 250, 500, 1000
        public int BagsPerCarton { get; private set; } // e.g., 10 bags per wholesale carton

        // Pricing & Ordering
        public decimal CartonPrice { get; private set; }
        public int MinimumOrderQuantityCartons { get; private set; }

        // State
        public bool IsActive { get; private set; }
        public DateTime CreatedAt { get; private set; }

        // 1. EF Core requires a parameterless constructor to recreate the object from the database.
        // We make it 'private' so other developers can't create empty, invalid coffees in your code.
        private CoffeeProduct() { }

        // 2. Primary Constructor (Notice 'moq' is now 'minimumOrderQuantityCartons')
        public CoffeeProduct(string sku, string name, string description, string roastLevel,
                             string origin, int bagWeightGrams, int bagsPerCarton,
                             decimal cartonPrice, int minimumOrderQuantityCartons)
        {
            Id = Guid.NewGuid();
            Sku = sku;
            Name = name;
            Description = description;
            RoastLevel = roastLevel;
            Origin = origin;
            BagWeightGrams = bagWeightGrams;
            BagsPerCarton = bagsPerCarton;
            CartonPrice = cartonPrice;
            MinimumOrderQuantityCartons = minimumOrderQuantityCartons; // Updated mapping

            IsActive = true;
            CreatedAt = DateTime.UtcNow;
        }

        // Behavior Methods (Rich Domain Model)
        public void UpdatePricing(decimal newCartonPrice)
        {
            if (newCartonPrice <= 0)
                throw new ArgumentException("Carton price must be greater than zero.");

            CartonPrice = newCartonPrice;
        }

        public void DeactivateProduct()
        {
            IsActive = false;
        }
    }
}