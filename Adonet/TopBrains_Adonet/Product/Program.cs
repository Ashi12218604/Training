using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient;

public class Pg
{
   public static void Main(string[] args)
    {
        List<Product> products = new List<Product>();

        string connectionString =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog= LPU;Integrated Security=True;TrustServerCertificate=True";

        string query = "SELECT ProductId, ProductName, Price FROM Product";

        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                Product p = new Product
                {
                    ProductId = reader.GetInt32(0),
                    ProductName = reader.GetString(1),
                    Price = reader.GetDecimal(2)
                };

                products.Add(p);
            }
            reader.Close();
        }

        // Output check
        foreach (var p in products)
        {
            Console.WriteLine($"{p.ProductId} {p.ProductName} {p.Price}");
        }
    }
}