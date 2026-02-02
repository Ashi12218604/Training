using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static SortedDictionary<string, long> itemDetails =
        new SortedDictionary<string, long>()
        {
            { "Pen", 150 },
            { "Notebook", 300 },
            { "Pencil", 100 },
            { "Eraser", 50 }
        };

    public static SortedDictionary<string, long> FindItemDetails(long soldCount)
    {
        SortedDictionary<string, long> result = new SortedDictionary<string, long>();

        foreach (var item in itemDetails)
        {
            if (item.Value == soldCount)
            {
                result.Add(item.Key, item.Value);
            }
        }

        return result;
    }

    public static List<string> FindMinandMaxSoldItems()
    {
        List<string> result = new List<string>();

        long min = itemDetails.Values.Min();
        long max = itemDetails.Values.Max();

        string minItem = itemDetails.First(x => x.Value == min).Key;
        string maxItem = itemDetails.First(x => x.Value == max).Key;

        result.Add(minItem);
        result.Add(maxItem);

        return result;
    }

    public static Dictionary<string, long> SortByCount()
    {
        Dictionary<string, long> sortedResult =
            itemDetails
            .OrderBy(x => x.Value)
            .ToDictionary(x => x.Key, x => x.Value);

        return sortedResult;
    }

    static void Main(string[] args)
    {
        long soldCount = 100;

        SortedDictionary<string, long> foundItems = FindItemDetails(soldCount);

        if (foundItems.Count == 0)
        {
            Console.WriteLine("Invalid sold count");
        }
        else
        {
            Console.WriteLine("Item Details:");
            foreach (var item in foundItems)
            {
                Console.WriteLine(item.Key + " : " + item.Value);
            }
        }

        List<string> minMaxItems = FindMinandMaxSoldItems();

        Console.WriteLine("Minimum Sold Item: " + minMaxItems[0]);
        Console.WriteLine("Maximum Sold Item: " + minMaxItems[1]);

        Dictionary<string, long> sortedItems = SortByCount();

        Console.WriteLine("Items Sorted by Sold Count:");

        foreach (var item in sortedItems)
        {
            Console.WriteLine(item.Key + " : " + item.Value);
        }
    }
}
