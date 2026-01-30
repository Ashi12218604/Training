using System;
using System.IO;
using System.Collections.Generic;

public class Solution
{
    public static void Main()
    {
        string inputFile = "log.txt";
        string outputFile = "error.txt";

        if (!File.Exists(inputFile))
        {
            Console.WriteLine("log.txt not found");
            return;
        }

        string[] lines = File.ReadAllLines(inputFile);
        List<string> errorLogs = new List<string>();

        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("ERROR"))
                errorLogs.Add(lines[i]);
        }

        File.WriteAllLines(outputFile, errorLogs);

        Console.WriteLine("ERROR logs saved to error.txt");
    }
}
