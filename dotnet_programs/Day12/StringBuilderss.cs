using System;
using System.Text;

public class StringBuilderss
{
    public static void Run()
    {
        StringBuilder sb = new StringBuilder();

        // Append with chaining
        sb.Append("Text")
          .Append(" text2")
          .Append(" text3");

        Console.WriteLine("After Append:");
        Console.WriteLine(sb.ToString());

        // AppendLine
        sb.AppendLine();
        sb.AppendLine("Line");

        Console.WriteLine("\nAfter AppendLine:");
        Console.WriteLine(sb.ToString());

        // Insert at beginning
        sb.Insert(0, "Start ");

        Console.WriteLine("After Insert:");
        Console.WriteLine(sb.ToString());

        // Remove characters (start index, length)
        sb.Remove(0, 6);

        Console.WriteLine("After Remove:");
        Console.WriteLine(sb.ToString());

        // Replace text
        sb.Replace("Text", "New");

        Console.WriteLine("After Replace:");
        Console.WriteLine(sb.ToString());

        // Clear all content
        sb.Clear();

        Console.WriteLine("After Clear:");
        Console.WriteLine($"Length = {sb.Length}");
    }
}
