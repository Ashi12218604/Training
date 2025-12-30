// //**************************************************************************************************************
// using System;

// class Program
// {
//     static void Main(string[] args)
//     {
//         Console.WriteLine("Enter input:");
//         RegexMatch.res();
//     }
// }

// // string sentence = "abc123"; ->true   (@"\d")
// // string sentence = "123123"; ->true   (@"\d")
// // string sentence = "123_123"; ->true   (@"\d")

// //**************************************************************************************************************

using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<string> emails = new List<string>();
        Console.WriteLine("Enter number of emails");
        int n=Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter email addresses:");

        for (int i = 1; i <= n; i++)
        {
            Console.Write("Email " + i + ": ");
            emails.Add(Console.ReadLine());
        }

        Console.WriteLine("\nEmail Validation Result:");

        foreach (string email in emails)
        {
            bool isValid = EmailValidation.IsValidEmail(email);
            Console.WriteLine(email + " -> " + (isValid ? "Valid" : "Invalid"));
        }
    }
}

