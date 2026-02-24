using System;
using System.Data;
using Microsoft.Data.SqlClient;

class Employee_Count
{
    static void Main()
    {
        string cs =
            "Data Source=localhost\\SQLEXPRESS;Initial Catalog=LPU;Integrated Security=True;TrustServerCertificate=True";

        using SqlConnection con = new SqlConnection(cs);
        using SqlCommand cmd = new SqlCommand("sp_GetTotalEmployeeCount", con);

        cmd.CommandType = CommandType.StoredProcedure;

        SqlParameter p = new SqlParameter("@TotalCount", SqlDbType.Int);
        p.Direction = ParameterDirection.Output;
        cmd.Parameters.Add(p);

        con.Open();
        cmd.ExecuteNonQuery();

        Console.WriteLine("Employee Count: " + p.Value);
    }
}