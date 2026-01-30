using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

public record Student(string Name, int Score);

public class Solution
{
    public static string BuildJson(string[] items, int minScore)
    {
        List<Student> students = new List<Student>();

        for (int i = 0; i < items.Length; i++)
        {
            string[] parts = items[i].Split(':');
            if (parts.Length != 2)
                continue;

            int score;
            if (!int.TryParse(parts[1], out score))
                continue;

            students.Add(new Student(parts[0], score));
        }

        var filtered = students
            .Where(s => s.Score >= minScore)
            .OrderByDescending(s => s.Score)
            .ThenBy(s => s.Name)
            .ToList();

        return JsonSerializer.Serialize(filtered);
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        string[] items = new string[n];

        for (int i = 0; i < n; i++)
            items[i] = Console.ReadLine();

        int minScore = Convert.ToInt32(Console.ReadLine());

        string json = BuildJson(items, minScore);
        Console.WriteLine(json);
    }
}
