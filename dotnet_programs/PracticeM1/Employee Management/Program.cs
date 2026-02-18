using System;
using System.Collections.Generic;
using System.Linq;

class Employee
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Department { get; set; }
    public double Salary { get; set; }

    // Constructor
    public Employee(int id, string name, string department, double salary)
    {
        // TODO
        Id=id;
        Name=name;
        Department=department;
        Salary=salary;
    }
}

class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        List<Employee> employees = new List<Employee>();

        for(int i = 0; i < n; i++)
        {
            string[] input = Console.ReadLine().Split();
            
            int id = int.Parse(input[0]);
            string name = input[1];
            string department = input[2];
            double salary = double.Parse(input[3]);

            // TODO: Add employee to list
            employees.Add(new Employee(id,name,department,salary));
        }
        string searchDept = Console.ReadLine();

        // TODO 1: Print employees with salary > 50000
        Console.WriteLine("Employee with salary greater than 50000 are:");
        foreach(var e in employees)
        {
        if(e.Salary>50000)
        {
        Console.WriteLine(e.Id);
        }
        }

        // TODO 2: Print average salary
        double total=0;
        foreach(var s in employees)
        {
            total+=s.Salary;
        }
        double avg=total/employees.Count;
        Console.WriteLine("Average salary is:"+avg);

        // TODO 3: Print employees by department
        Console.WriteLine("Employee in:"+searchDept+"is");
        foreach(var d in employees)
        {
            if(d.Department==searchDept)
            {
                Console.WriteLine($"{d.Id}| {d.Name} | {d.Salary}");
            }
        }

    }
}
