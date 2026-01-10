using System;
using System.Collections.Generic;
using DialingCodesApp;

class Program
{
    static void Main()
    {
        var emptyDict = DialingCodes.GetEmptyDictionary();
        var existingDict = DialingCodes.GetExistingDictionary();

        var single = DialingCodes.AddCountryToEmptyDictionary(81, "Japan");

        existingDict = DialingCodes.AddCountryToExistingDictionary(existingDict, 44, "United Kingdom");

        string result1 = DialingCodes.GetCountryNameFromDictionary(existingDict, 91);
        string result2 = DialingCodes.GetCountryNameFromDictionary(existingDict, 999);

        bool check1 = DialingCodes.CheckCodeExists(existingDict, 1);
        bool check2 = DialingCodes.CheckCodeExists(existingDict, 500);

        DialingCodes.UpdateDictionary(existingDict, 91, "Republic of India");

        DialingCodes.RemoveCountryFromDictionary(existingDict, 1);

        string longest = DialingCodes.FindLongestCountryName(existingDict);

        Console.WriteLine(result1);
        Console.WriteLine(result2);
        Console.WriteLine(check1);
        Console.WriteLine(check2);
        Console.WriteLine(longest);
    }
}
