using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Program
{
    static string connectionString =
        "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EFTestMVC;Integrated Security=True;TrustServerCertificate=True";

    static void Main()
    {
        Console.Write("Enter Department: ");
        string department = Console.ReadLine();

        ShowEmployeesByDepartment(department);
        ShowDepartmentCount(department);
        ShowEmployeeOrders();
        ShowDuplicateEmployees();
    }

    // PART 1
    static void ShowEmployeesByDepartment(string department)
    {
        Console.WriteLine("\nEmployees in Department:");

        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetEmployeesByDepartment", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@Department", department);

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine($"{reader["EmpId"]} | {reader["Name"]} | {reader["Department"]}");
        }
        reader.Close();
    }

    // PART 2
    static void ShowDepartmentCount(string department)
    {
        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDepartmentEmployeeCount", con);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@Department", department);

        SqlParameter output = new SqlParameter("@TotalEmployees", SqlDbType.Int);
        output.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(output);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine($"\nTotal employees in {department}: {output.Value}");
    }

    // PART 3
    static void ShowEmployeeOrders()
    {
        Console.WriteLine("\nEmployee Order Report:");

        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetEmployeeOrders", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        while (reader.Read())
        {
            Console.WriteLine(
                $"{reader["Name"]} | {reader["Department"]} | {reader["OrderId"]} | {reader["OrderAmount"]} | {reader["OrderDate"]}"
            );
        }
        reader.Close();
    }

    // PART 4
    static void ShowDuplicateEmployees()
    {
        Console.WriteLine("\nDuplicate Employees:");

        using SqlConnection con = new SqlConnection(connectionString);
        using SqlCommand cmd = new SqlCommand("sp_GetDuplicateEmployees", con);
        cmd.CommandType = CommandType.StoredProcedure;

        con.Open();
        SqlDataReader reader = cmd.ExecuteReader();

        bool found = false;
        while (reader.Read())
        {
            found = true;
            Console.WriteLine(
                $"{reader["EmpId"]} | {reader["Name"]} | {reader["Phone"]} | {reader["Email"]}"
            );
        }

        if (!found)
            Console.WriteLine("No duplicate records found.");

        reader.Close();
    }
}