using System;
using ReverseStudent;

class Program
{
    static void Main()
    {
        ReverseStudentLogic rs = new ReverseStudentLogic();
        var result = rs.GetReversedStudents();

        foreach (var name in result)
        {
            Console.WriteLine(name);
        }
    }
}
