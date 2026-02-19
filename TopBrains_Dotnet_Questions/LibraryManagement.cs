using System;
using System.Collections.Generic;
using System.Linq;

public class Book
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Publisher { get; set; }
    public double Price { get; set; }

    public Book(int id, string name, string publisher, double price)
    {
        Id = id;
        Name = name;
        Publisher = publisher;
        Price = price;
    }
}

public class Library
{
    private List<dynamic> books = new List<dynamic>();

    public void AddBook(int id, string name, string publisher, double price)
    {
        books.Add(new Book(id, name, publisher, price));
        Console.WriteLine("Book added successfully.");
    }

    public void UpdateBook(int id, string name, string publisher, double price)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        book.Name = name;
        book.Publisher = publisher;
        book.Price = price;

        Console.WriteLine("Book updated successfully.");
    }

    public void DeleteBook(int id)
    {
        var book = books.FirstOrDefault(b => b.Id == id);
        if (book == null)
        {
            Console.WriteLine("Book not found.");
            return;
        }

        books.Remove(book);
        Console.WriteLine("Book deleted successfully.");
    }

    public void ViewAllBooks()
    {
        foreach (var book in books)
        {
            Console.WriteLine($"{book.Id} {book.Name} {book.Publisher} {book.Price}");
        }
    }

    public void SearchByName(string name)
    {
        var result = books.Where(b => b.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        foreach (var book in result)
        {
            Console.WriteLine($"{book.Id} {book.Name} {book.Publisher} {book.Price}");
        }
    }

    public void SearchByPublisher(string publisher)
    {
        var result = books.Where(b => b.Publisher.Contains(publisher, StringComparison.OrdinalIgnoreCase));

        foreach (var book in result)
        {
            Console.WriteLine($"{book.Id} {book.Name} {book.Publisher} {book.Price}");
        }
    }

    public void ViewHighestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        var book = books.OrderByDescending(b => b.Price).First();
        Console.WriteLine($"{book.Id} {book.Name} {book.Publisher} {book.Price}");
    }

    public void ViewLowestPriceBook()
    {
        if (books.Count == 0)
        {
            Console.WriteLine("No books available.");
            return;
        }

        var book = books.OrderBy(b => b.Price).First();
        Console.WriteLine($"{book.Id} {book.Name} {book.Publisher} {book.Price}");
    }
}

public class Program
{
    public static void Main()
    {
        Library library = new Library();

        while (true)
        {
            Console.WriteLine("\n1.Add 2.Update 3.Delete 4.ViewAll 5.SearchByName 6.SearchByPublisher 7.Highest 8.Lowest 9.Exit");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    Console.WriteLine("Enter Id Name Publisher Price:");
                    var add = Console.ReadLine().Split();
                    library.AddBook(int.Parse(add[0]), add[1], add[2], double.Parse(add[3]));
                    break;

                case 2:
                    Console.WriteLine("Enter Id Name Publisher Price:");
                    var upd = Console.ReadLine().Split();
                    library.UpdateBook(int.Parse(upd[0]), upd[1], upd[2], double.Parse(upd[3]));
                    break;

                case 3:
                    Console.WriteLine("Enter Id:");
                    library.DeleteBook(int.Parse(Console.ReadLine()));
                    break;

                case 4:
                    library.ViewAllBooks();
                    break;

                case 5:
                    Console.WriteLine("Enter Name:");
                    library.SearchByName(Console.ReadLine());
                    break;
