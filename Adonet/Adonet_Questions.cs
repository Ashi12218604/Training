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
    delete one/more student based on your category}
    else
   {
   show all the records}*/

        // using System;
        // using Microsoft.Data.SqlClient;
        // class Program
        // {    static void Main()
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
        //                 string countQuery =
        //                     "SELECT COUNT(*) FROM studentscsharp";
        //                 SqlCommand countCmd = new SqlCommand(countQuery, con);
        //                 int totalCount =(int)countCmd.ExecuteScalar();  // Scalar -- because single aggregated value
        //                 Console.WriteLine("Total Students: " + totalCount);
        //                 if (totalCount > 5)
        //                 {
        //                     Console.WriteLine("Deleted students");
        //                     string deleteQuery = "DELETE TOP (2) FROM studentscsharp";
        //                     SqlCommand deleteCmd =new SqlCommand(deleteQuery, con);
        //                     int deleted =deleteCmd.ExecuteNonQuery();   // Non- Query --  because Insert , Delete , Update
        //                     Console.WriteLine("Deleted Rows: " + deleted);
        //                     ShowAllStudents(con);
        //                 }
        //                 else
        //                 {
        //                     Console.WriteLine("\n Students data:\n");
        //                     ShowAllStudents(con);
        //                 }
        //             }
        //             catch (Exception ex)
        //             {
        //                 Console.WriteLine("Error: " + ex.Message);
        //             }
        //         }
        //         Console.ReadKey();
        //     }
        //         static void ShowAllStudents(SqlConnection con)
        //     {
        //         string query ="SELECT * FROM studentscsharp";
        //         SqlCommand cmd =
        //             new SqlCommand(query, con);
        //         SqlDataReader reader =cmd.ExecuteReader();    //  // Execute Reader-- because all records had to printed
        //         Console.WriteLine("\nRemaining Students:\n");
        //         while (reader.Read())
        //         {
        //             Console.WriteLine(
        //                 "Id: " + reader["Id"] +
        //                 ", Name: " + reader["Name"] +
        //                 ", Dept: " + reader["Department"] +
        //                 ", Gender: " + reader["Gender"] +
        //                 ", Location: " + reader["Location"]
        //             );
        //         }
        //         reader.Close();
        //     }
        // }
 // ----------------------------------------------------------------------------------------------------------------------------------
 
// Square of a function
        // using System;
        // using System.Data;
        // using Microsoft.Data.SqlClient;

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
        //             // Open Connection
        //             con.Open();
        //             Console.WriteLine("Connection successful!");

        //             // Query
        //             string query = "SELECT dbo.Fnsquare(@num)";

        //             using (SqlCommand command = new SqlCommand(query, con))
        //             {
        //                 command.CommandType = CommandType.Text;

        //                 // Parameter
        //                 command.Parameters.AddWithValue("@num", 6);

        //                 // ExecuteScalar
        //                 int square =
        //                     Convert.ToInt32(command.ExecuteScalar());

        //                 Console.WriteLine("Square = " + square);
        //             }
        //         }

        //         Console.ReadKey();
        //     }
        // } 
// ----------------------------------------------------------------------------------------------------------------------------------------

// Connecting with IPv4 Address Server=192.168.232.60
            // using System;
            // using System.Data;
            // using Microsoft.Data.SqlClient;

            // class Program
            // {
            //     static void Main()
            //     {
            //         string cs =
            //             "Server=192.168.232.60;" +
            //             "Database=sqlprograms;" +
            //             "Trusted_Connection=True;" +
            //             "TrustServerCertificate=True;";

            //         using (SqlConnection con = new SqlConnection(cs))
            //         {
            //             // Open Connection
            //             con.Open();
            //             Console.WriteLine("Connection successful!");

            //             // Query
            //             string query = "SELECT dbo.Fnsquare(@num)";

            //             using (SqlCommand command = new SqlCommand(query, con))
            //             {
            //                 command.CommandType = CommandType.Text;

            //                 // Parameter
            //                 command.Parameters.AddWithValue("@num", 6);

            //                 // ExecuteScalar
            //                 int square =
            //                     Convert.ToInt32(command.ExecuteScalar());

            //                 Console.WriteLine("Square = " + square);
            //             }
            //         }

            //         Console.ReadKey();
            //     }
            // }
// ------------------------------------------------------------------------------------------------------------------------------------------------

/* Disconnected Architecture
1. Connection
2. Command
3. Connection Builder (optional)
for the first time in disconnected architecture we need to connect with the server next time you can go without connectiong or mentioning server connection */

        // using System;
        // using System.Data;
        // using Microsoft.Data.SqlClient;

        // class Program
        // {
        //     static void Main()
        //     {
        //         string cs =
        //             "Server=localhost\\SQLEXPRESS;" +
        //             "Database=sqlprograms;" +
        //             "Trusted_Connection=True;" +
        //             "TrustServerCertificate=True;";

        //         // Create Connection
        //         using (SqlConnection con = new SqlConnection(cs))
        //         {
        //             // Query
        //             string query = "SELECT * FROM studentscsharp";

        //             // Create Adapter
        //             SqlDataAdapter da =
        //                 new SqlDataAdapter(query, con);

        //             // Create DataSet
        //             DataSet ds = new DataSet();

        //             // Fill DataSet (Connection opens & closes automatically)
        //             da.Fill(ds, "Students");

        //             // Access DataTable from DataSet
        //             DataTable dt = ds.Tables["Students"];

        //             Console.WriteLine("Disconnected Data:\n");

        //             // Read Data (No DB Connection Needed Now)
        //             foreach (DataRow row in dt.Rows)
        //             {
        //                 Console.WriteLine(
        //                     "Id: " + row["Id"] +
        //                     ", Name: " + row["Name"] +
        //                     ", Dept: " + row["Department"] +
        //                     ", Gender: " + row["Gender"] +
        //                     ", Location: " + row["Location"]
        //                 );
        //             }
        //         }

        //         Console.ReadKey();
        //     }
//          }
// ------------------------------------------------------------------------------------------------------------------------------------------------
 
 // making dataset and datatableS
        // using System;
        // using System.Data;

        // class Program
        // {
        //     static void Main()
        //     {
        //         // Create DataSet
        //         DataSet ds = new DataSet();

        //         // Create DataTable
        //         DataTable dt = new DataTable("Students");

        //         // Add Columns
        //         dt.Columns.Add("Id", typeof(int));
        //         dt.Columns.Add("Name", typeof(string));
        //         dt.Columns.Add("Department", typeof(string));

        //         // Add Rows
        //         dt.Rows.Add(1, "Ashi", "IT");
        //         dt.Rows.Add(2, "Mari", "MCA");
        //         dt.Rows.Add(3, "Sanjana", "Art");

        //         // Add DataTable to DataSet
        //         ds.Tables.Add(dt);

        //         // Display Data
        //         Console.WriteLine("Student Data:\n");

        //         foreach (DataRow row in dt.Rows)
        //         {
        //             Console.WriteLine(
        //                 "Id: " + row["Id"] +
        //                 ", Name: " + row["Name"] +
        //                 ", Department: " + row["Department"]
        //             );
        //         }

        //         Console.ReadKey();
        //     }
        // }
 //------------------------------------------------------------------------------------------------------

 // CRUD OPERATIONS

    using System;
    using System.Data;
    using Microsoft.Data.SqlClient;

class Program
{
    static void Main()
    {
        string connectionString =
            "Data Source=localhost\\SQLEXPRESS;" +
            "Initial Catalog=sqlprograms;" +
            "Integrated Security=True;" +
            "Encrypt=True;TrustServerCertificate=True;";

        DataSet ds = new DataSet();

        using (SqlConnection con = new SqlConnection(connectionString))
        {
            con.Open();

            SqlDataAdapter da = new SqlDataAdapter("sp_GetStudents", con);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;

            SqlCommandBuilder cb = new SqlCommandBuilder(da);

            // Fill
            da.Fill(ds, "Students");

            DataTable dt = ds.Tables["Students"];

            // CREATE
            DataRow newRow = dt.NewRow();
            newRow["Name"] = "Arun";
            newRow["Department"] = "IT";
            dt.Rows.Add(newRow);

            // UPDATE
            dt.Rows[0]["Department"] = "CSE";

            // DELETE
            if (dt.Rows.Count > 1)
                dt.Rows[1].Delete();

            //UPDATE MUST BE HERE
            da.Update(dt);
        }

        Console.WriteLine("CRUD operations completed successfully");
    }
}