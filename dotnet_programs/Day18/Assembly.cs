using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Reflection;
// public class InfoAttribute : Attribute
// {
//     public string Description{get;}
//     public InfoAttribute(string decription)
//     {
//         Description = description;
//     }
// }
public class Employee
{
    private int salary;
    public int Id {get; set;}
    public string Name{get; set;}
    public event EventHandler EmployeeWorked;
    public Employee(){ }
    public Employee(int id, string name)
    {
        Id = id;
        Name = name;
    }
    public void Work()
    {
        Console.WriteLine("Employee is working");
        EmployeeWorked?.Invoke(this, EventArgs.Empty);
    }
    private void Secret()
    {
        Console.WriteLine("Private Method");
    }
}