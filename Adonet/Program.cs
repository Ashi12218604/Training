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

// using System;
// using Microsoft.Data.SqlClient;
// using System.Data;
// class Program
// {
//     static void Main()
//     {
//         string cs =
//             "Server=localhost\\SQLEXPRESS;" +
//             "Database=sqlprograms;" +
//             "Trusted_Connection=True;" +
//             "TrustServerCertificate=True;";
//         using (SqlConnection con = new SqlConnection(cs))
//         {
//             try
//             {
//                 con.Open();
//                 Console.WriteLine("Connected Successfully!");
//                 Console.Write("Enter Gender: ");
//                 string gender = Console.ReadLine();
//                 using (SqlCommand cmd =
//                     new SqlCommand("dbo.uspgetstudentcountbydept", con))
//                 {
//                     cmd.CommandType = CommandType.StoredProcedure;
//                     cmd.Parameters.Add("@gender", 
//                         SqlDbType.NVarChar, 50).Value = gender;          // input parameter
//                     SqlParameter p =
//                         new SqlParameter("@studentcount", SqlDbType.Int);
//                     p.Direction = ParameterDirection.Output;   // output parameter
//                     cmd.Parameters.Add(p);
//                     cmd.ExecuteNonQuery();
//                     int count =
//                         Convert.ToInt32(cmd.Parameters["@studentcount"].Value);
//                     Console.WriteLine("Count : " + count);
//                 }
//             }
//             catch (Exception ex)
//             {
//                 Console.WriteLine("Error : " + ex.Message);
//             }
//             Console.ReadKey();
//         }
//     }
// }
//----------------------------------------------------------------------------------------------------------------------------

// Q: Execute the Non Query Command Reader -- (Insert, Update, Delete)
    // using System;
    // using Microsoft.Data.SqlClient;

    // class Program
    // {    static void Main()
    //     {
    //         string connectionString =
    //             "Server=localhost\\SQLEXPRESS;" +
    //             "Database=sqlprograms;" +
    //             "Trusted_Connection=True;" +
    //             "TrustServerCertificate=True;";

    //         // Create Connection
    //         using (SqlConnection con = new SqlConnection(connectionString))
    //         {
    //             try
    //             {
    //                 con.Open();
    //                 Console.WriteLine("Connected Successfully!");
    //                 string query =
    //                 "INSERT INTO College (Id, Name,Location, Department, PhoneNo, Gender) " +
    //                 "VALUES (21, 'Anushka', 'Delhi','CSE', 9234,'Female')";

    //                 SqlCommand cmd = new SqlCommand(query, con);
    //                 // Execute NonQuery
    //                 int rows = cmd.ExecuteNonQuery();
    //                 Console.WriteLine("Rows Affected: " + rows);
    //             }
    //             catch (Exception ex)
    //             {
    //                 Console.WriteLine("Error: " + ex.Message);
    //             }
    //         }
    //         Console.ReadKey();
    //     }
    // }
//--------------------------------------------------------------------------------------------------------------------------------------

/* Q: 1. Get the total count of hostel students
    if (hostelst count>5)
    {
    delete one/more student based on yjr category}
    else
   {
   show all the records}*/

using System;
using Microsoft.Data.SqlClient;
class Program
{    static void Main()
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
                string countQuery =
                    "SELECT COUNT(*) FROM studentscsharp";
                SqlCommand countCmd = new SqlCommand(countQuery, con);
                int totalCount =(int)countCmd.ExecuteScalar();
                Console.WriteLine("Total Students: " + totalCount);
                if (totalCount > 5)
                {
                    Console.WriteLine("Deleted students");
                    string deleteQuery = "DELETE TOP (2) FROM studentscsharp";
                    SqlCommand deleteCmd =new SqlCommand(deleteQuery, con);
                    int deleted =deleteCmd.ExecuteNonQuery();
                    Console.WriteLine("Deleted Rows: " + deleted);
                    ShowAllStudents(con);
                }
                else
                {
                    Console.WriteLine("\n Students data:\n");
                    ShowAllStudents(con);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
        Console.ReadKey();
    }
        static void ShowAllStudents(SqlConnection con)
    {
        string query ="SELECT * FROM studentscsharp";
        SqlCommand cmd =
            new SqlCommand(query, con);
        SqlDataReader reader =cmd.ExecuteReader();
        Console.WriteLine("\nRemaining Students:\n");
        while (reader.Read())
        {
            Console.WriteLine(
                "Id: " + reader["Id"] +
                ", Name: " + reader["Name"] +
                ", Dept: " + reader["Department"] +
                ", Gender: " + reader["Gender"] +
                ", Location: " + reader["Location"]
            );
        }
        reader.Close();
    }
}

