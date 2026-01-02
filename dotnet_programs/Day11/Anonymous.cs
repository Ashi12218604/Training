using System;

public class Anonymous
{
        public static void Print()
    {
        // 1. Unnamed Tuple
        (int, string) student1=(101, "Amit");
        // 2. Named Tuple
        var student2=(Id: 102, Name: "Rahul");
        // 3. Anonymous Type
        var student3 = new
        {
            Id = 103,
            Name= "Sneha"
        };

        Console.WriteLine("VALUES");
        Console.WriteLine(student1.Item1 + " " + student1.Item2);
        Console.WriteLine(student2.Id + " " + student2.Name);
        Console.WriteLine(student3.Id + " " + student3.Name);

        Console.WriteLine();
        Console.WriteLine("TYPES");
        Console.WriteLine("student1 type: " + student1.GetType());
        Console.WriteLine("student2 type: " + student2.GetType());
        Console.WriteLine("student3 type: " + student3.GetType());
    }
}
