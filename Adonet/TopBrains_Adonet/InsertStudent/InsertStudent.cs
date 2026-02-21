using System;
using System.Data;
using Microsoft.Data.SqlClient;
public class Program
{
    static void Main(string[] args)
    {
        int id = int.Parse(Console.ReadLine());
        string name = Console.ReadLine();
        int marks = int.Parse(Console.ReadLine());
string connectionString ="Data Source=localhost\\SQLEXPRESS;" +"Initial Catalog=LPU;" +"Integrated Security=True;" +"TrustServerCertificate=True;";
string query ="INSERT INTO Student (Id, Name, Marks) VALUES (@Id, @Name, @Marks)";

        using (SqlConnection con = new SqlConnection(connectionString))
        using (SqlCommand cmd = new SqlCommand(query, con))
        {
            cmd.Parameters.AddWithValue("@Id", id);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Marks", marks);

            con.Open();
            cmd.ExecuteNonQuery();
        }

        Console.WriteLine("Inserted Successfully");
    }
}