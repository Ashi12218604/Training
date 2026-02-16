using System;

namespace BookStoreApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            // Read initial book details
            string[] input = Console.ReadLine().Split(' ');
            string Id = input[0];
            string Title = input[1];
            int Price = int.Parse(input[2]);
            int Stock = int.Parse(input[3]);
            Book book = new Book(Id, Title, Price, Stock);
            BookUtility utility = new BookUtility(book);
            while (true)
            {
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        utility.GetBookDetails();
                        break;
                    case 2:
                        int np = int.Parse(Console.ReadLine());
                        utility.UpdateBookPrice(np);
                        break;
                    case 3:
                        int nst = int.Parse(Console.ReadLine());
                        utility.UpdateBookStock(nst);
                        break;
                    case 4:
                        Console.WriteLine("Thank You");
                        return;
                    default:
                        Console.WriteLine("Invalid Choice. Enter choice from 1 to 4");
                        break;
                }
            }
        }
    }
}
