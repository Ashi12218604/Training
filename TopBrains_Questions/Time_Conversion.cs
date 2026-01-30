using System;

public class Solution
{
    public static string TimeConversion(int totalSeconds)
    {
        int minutes = totalSeconds / 60;
        int seconds = totalSeconds % 60;
        return minutes + ":" + seconds.ToString("D2");
    }

    public static void Main()
    {
        int totalSeconds = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine(TimeConversion(totalSeconds));
    }
}
