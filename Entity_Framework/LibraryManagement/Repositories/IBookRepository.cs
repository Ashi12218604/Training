using LibraryManagement.Models;

namespace LibraryManagement.Repositories
{
    public interface IBookRepository
    {
        IEnumerable<Book> GetAllBooks();

        Book GetBookById(int id);

        IEnumerable<Book> GetBooksByAuthor(string author);

        IEnumerable<Book> GetBooksByName(string name);

        IEnumerable<Book> GetBooksByPrice(decimal price);

        void AddBook(Book book);

        void UpdateBook(Book book);

        void DeleteBook(int id);

        void Save();
    }
}   