using System;
using System.Collections.Generic;
using LibItems = LibrarySystem.Items;
using LibrarySystem.Users;

class Program
{
    static void Main()
    {
        List<LibItems.LibraryItem> items = new List<LibItems.LibraryItem>();

        LibItems.Book book = new LibItems.Book { Title = "C# Fundamentals", Author = "John Doe", ItemID = 101 };
        LibItems.Magazine magazine = new LibItems.Magazine { Title = "Tech Today", Author = "Jane Doe", ItemID = 201 };
        LibItems.eBook ebook = new LibItems.eBook { Title = "AI Revolution", Author = "Sam Tech", ItemID = 301 };

        items.Add(book);
        items.Add(magazine);
        items.Add(ebook);

        foreach (var item in items)
        {
            item.DisplayDetails();
            Console.WriteLine($"Late Fee for 3 days: {item.CalculateLateFee(3)}");
            Console.WriteLine();
        }

        Console.WriteLine("Method selection happens at runtime");

        LibItems.IReservable reservable = book;
        LibItems.INotifiable notifiable = book;
        reservable.Reserve();
        notifiable.Notify("Please return the book on time.");

        Console.WriteLine("Direct access restricted; functionality exposed only through interfaces.");
        Console.WriteLine();

        LibrarySystem.LibraryAnalytics.TotalBorrowed = 5;
        LibrarySystem.LibraryAnalytics.ShowAnalytics();

        Member user = new Member { Name = "Sanjana", Role = LibrarySystem.UserRole.Member };
        Console.WriteLine($"User Role: {user.Role}");
        Console.WriteLine($"Item Status: {LibrarySystem.ItemStatus.Borrowed}");

        user.SendRoleBasedNotification();
        ebook.Download();
    }
}