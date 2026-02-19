using System;
using System.Collections.Generic;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int CopiesAvailable { get; set; }

    public Book(int id, string title, int copies)
    {
        Id = id;
        Title = title;
        CopiesAvailable = copies;
    }
}

public class Library
{
    private Dictionary<int, Book> books = new Dictionary<int, Book>();

    public void AddBook(Book b)
    {
        if (books.ContainsKey(b.Id))
            books[b.Id].CopiesAvailable += b.CopiesAvailable;
        else
            books[b.Id] = b;
    }

    public void BorrowBook(int id)
    {
        if (!books.ContainsKey(id))
        {
            Console.WriteLine("Book Not Found");
            return;
        }

        if (books[id].CopiesAvailable == 0)
        {
            Console.WriteLine("Out of Stock");
            return;
        }

        books[id].CopiesAvailable--;
        Console.WriteLine("Borrowed: " + books[id].Title);
    }

    public int GetTotalBooksAvailable()
    {
        int total = 0;
        foreach (var b in books.Values)
            total += b.CopiesAvailable;

        return total;
    }
}

class Program
{
    static void Main()
    {
        Library lib = new Library();

        lib.AddBook(new Book(1, "Math", 3));
        lib.AddBook(new Book(2, "Science", 2));

        lib.BorrowBook(1);
        lib.BorrowBook(2);
        lib.BorrowBook(5);

        Console.WriteLine("Total Available: " + lib.GetTotalBooksAvailable());
    }
}
