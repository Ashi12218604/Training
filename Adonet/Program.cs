// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//         "Server=localhost\\SQLEXPRESS;Database=sqlprograms;Trusted_Connection=True;TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 con.Open();
//                 Console.WriteLine("✅ Connected Successfully!");

//                 // Query College table
//                 string query = "SELECT * FROM College";

//                 SqlCommand cmd = new SqlCommand(query, con);

//                 using (SqlDataReader reader = cmd.ExecuteReader())
//                 {
//                     Console.WriteLine("\n📄 College Table Data:\n");

//                     while (reader.Read())
//                     {
//                         Console.WriteLine(
//                             "ID: " + reader["Id"] +
//                             ", Name: " + reader["Name"] +
//                             ", Location: " + reader["Location"] +
//                             ", Dept: " + reader["Department"] +
//                             ", Phone: " + reader["PhoneNo"] +
//                             ", Gender: " + reader["gender"] +
//                             ", M1: " + reader["M1"]
//                         );
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("❌ Error: " + ex.Message);
//             }
//         }

//         Console.WriteLine("\nPress any key to exit...");
//         Console.ReadKey();
//     }
// }
using System;
using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=sqlprograms;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                Console.WriteLine("✅ Connection successful!");

                Console.Write("Enter Gender (Male/Female): ");
                string gender = Console.ReadLine() ?? "";

                string query =
                    "SELECT Name, Department, gender " +
                    "FROM College " +
                    "WHERE gender = @gender";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@gender", gender);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        Console.WriteLine("\n📄 Result:\n");

                        bool found = false;

                        while (reader.Read())
                        {
                            found = true;

                            Console.WriteLine(
                                $"Name: {reader["Name"]}, " +
                                $"Department: {reader["Department"]}, " +
                                $"Gender: {reader["gender"]}"
                            );
                        }

                        if (!found)
                        {
                            Console.WriteLine("❌ No records found.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("❌ Error: " + ex.Message);
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
