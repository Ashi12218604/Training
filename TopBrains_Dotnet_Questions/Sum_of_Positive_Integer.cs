using System;

public class Solution
{
    public static int SumPositiveUntilZero(int[] nums)
    {
        int sum = 0;

        for (int i = 0; i < nums.Length; i++)
        {
            if (nums[i] == 0)
                break;

            if (nums[i] < 0)
                continue;

            sum += nums[i];
        }

        return sum;
    }

    public static void Main()
    {
        int n = Convert.ToInt32(Console.ReadLine());
        int[] nums = new int[n];

        for (int i = 0; i < n; i++)
            nums[i] = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(SumPositiveUntilZero(nums));
    }
}
