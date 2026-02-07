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
//                 Console.WriteLine(" Connected Successfully!");

//                 // Query College table
//                 string query = "SELECT * FROM College";

//                 SqlCommand cmd = new SqlCommand(query, con);

//                 using (SqlDataReader reader = cmd.ExecuteReader())
//                 {
//                     Console.WriteLine("\n College Table Data:\n");

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
//                 Console.WriteLine(" Error: " + ex.Message);
//             }
//         }

//         Console.WriteLine("\nPress any key to exit...");
//         Console.ReadKey();
//     }
// }

// ----------------------------------------------------------------------------------------
// using System;
// using Microsoft.Data.SqlClient;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=localhost\\SQLEXPRESS;" +
//             "Database=sqlprograms;" +
//             "Trusted_Connection=True;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection connection = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 connection.Open();
//                 Console.WriteLine(" Connection successful!");

//                 Console.Write("Enter Gender (Male/Female): ");
//                 string gender = Console.ReadLine() ?? "";

//                 string query =
//                     "SELECT Name, Department, gender " +
//                     "FROM College " +
//                     "WHERE gender = @gender";

//                 using (SqlCommand command = new SqlCommand(query, connection))
//                 {
//                     command.Parameters.AddWithValue("@gender", gender);

//                     using (SqlDataReader reader = command.ExecuteReader())
//                     {
//                         Console.WriteLine("\n Result:\n");

//                         bool found = false;

//                         while (reader.Read())
//                         {
//                             found = true;

//                             Console.WriteLine(
//                                 $"Name: {reader["Name"]}, " +
//                                 $"Department: {reader["Department"]}, " +
//                                 $"Gender: {reader["gender"]}"
//                             );
//                         }

//                         if (!found)
//                         {
//                             Console.WriteLine(" No records found.");
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Error: " + ex.Message);
//             }

//             Console.WriteLine("\nPress any key to exit...");
//             Console.ReadKey();
//         }
//     }
// }

//----------------------------------------------------------------------------------------
//  printing month wise birthdays after input
// using System;
// using Microsoft.Data.SqlClient;
// using System.Data;

// class Program
// {
//     static void Main()
//     {
//         string connectionString =
//             "Server=localhost\\SQLEXPRESS;" +
//             "Database=sqlprograms;" +
//             "Trusted_Connection=True;" +
//             "TrustServerCertificate=True;";

//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 con.Open();
//                 Console.WriteLine("Connected Successfully!");

//                 // Take Month & Year Input
//                 Console.Write("Enter Month (1-12): ");
//                 int month = int.Parse(Console.ReadLine() ?? "1");

//                 Console.Write("Enter Year (YYYY): ");
//                 int year = int.Parse(Console.ReadLine() ?? "2026");

//                 // Create a Date (1st day of that month)
//                 DateTime selectedDate = new DateTime(year, month, 1);

//                 Console.WriteLine($"\n Searching birthdays for: {selectedDate:MMMM yyyy}");

//                 using (SqlCommand cmd =
//                     new SqlCommand("dbo.uspGetBirthdaysInMyMonth", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;

//                     // Pass Date Parameter
//                     cmd.Parameters.Add("@month", SqlDbType.Date)
//                                   .Value = selectedDate;

//                     using (SqlDataReader reader = cmd.ExecuteReader())
//                     {
//                         Console.WriteLine("\n Birthdays:\n");

//                         bool found = false;

//                         while (reader.Read())
//                         {
//                             found = true;

//                             Console.WriteLine(
//                                 $"ID: {reader["Id"]}, " +
//                                 $"Name: {reader["Name"]}, " +
//                                 $"DOB: {reader["DOB"]}"
//                             );
//                         }

//                         if (!found)
//                         {
//                             Console.WriteLine("No birthdays found.");
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine(" Error: " + ex.Message);
//             }

//             Console.WriteLine("\nPress any key to exit...");
//             Console.ReadKey();
//         }
//     }
// }
// ---------------------------------------------------------------------------------------------------------------------

// ques: create stored procedure with parameter, test sp many times, add two parameter in c# code
// using System;
// using Microsoft.Data.SqlClient;
// using System.Data;
// class Program
// {
//         static void Main()
//     {
//         string connectionString =
//             "Server=localhost\\SQLEXPRESS;" +
//             "Database=sqlprograms;" +
//             "Trusted_Connection=True;" +
//             "TrustServerCertificate=True;";
//         using (SqlConnection con = new SqlConnection(connectionString))
//         {
//             try
//             {
//                 con.Open();
//                 Console.WriteLine("Connected Successfully!");
//                 Console.Write("Enter Month (1-12): ");
//                 int month = int.Parse(Console.ReadLine());
//                 Console.Write("Enter Department: ");
//                 string department = Console.ReadLine();
//                using (SqlCommand cmd =
//                     new SqlCommand("dbo.uspGetBirthdaysByMonthAndDept", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;
//                     cmd.Parameters.Add("@Month", SqlDbType.Int).Value = month;
//                     cmd.Parameters.Add("@Department", SqlDbType.VarChar, 50)
//                                   .Value = department;
//                     using (SqlDataReader reader = cmd.ExecuteReader())
//                     {
//                         Console.WriteLine("\n Birthdays:\n");
//                         bool found = false;
//                         while (reader.Read())
//                         {
//                             found = true;
//                             Console.WriteLine(
//                                 $"ID: {reader["Id"]}, " +
//                                 $"Name: {reader["Name"]}, " +
//                                 $"DOB: {reader["DOB"]}, " +
//                                 $"Dept: {reader["Department"]}"
//                             );
//                         }
//                         if (!found)
//                         {
//                             Console.WriteLine("No records found.");
//                         }
//                     }
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Error: " + ex.Message);
//             }
//             Console.ReadKey();
//         }
//     }
// }

//---------------------------------------------------------------------------------------------------------------

// Q: Gender based total count from College using input and output parameters and stored procedures

using System;
using Microsoft.Data.SqlClient;
using System.Data;

class Program
{
    static void Main()
    {
        string cs =
            "Server=localhost\\SQLEXPRESS;" +
            "Database=sqlprograms;" +
            "Trusted_Connection=True;" +
            "TrustServerCertificate=True;";

        using (SqlConnection con = new SqlConnection(cs))
        {
            try
            {
                con.Open();
                Console.WriteLine("Connected Successfully!");

                Console.Write("Enter Gender: ");
                string gender = Console.ReadLine();

                using (SqlCommand cmd =
                    new SqlCommand("dbo.uspgetstudentcountbydept", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // input parameter
                    cmd.Parameters.Add("@gender",
                        SqlDbType.NVarChar, 50).Value = gender;

                    // output parameter
                    SqlParameter p =
                        new SqlParameter("@studentcount", SqlDbType.Int);

                    p.Direction = ParameterDirection.Output;

                    cmd.Parameters.Add(p);

                    // execute
                    cmd.ExecuteNonQuery();

                    // get output
                    int count =
                        Convert.ToInt32(cmd.Parameters["@studentcount"].Value);

                    Console.WriteLine("Count : " + count);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error : " + ex.Message);
            }

            Console.ReadKey();
        }
    }
}
