using LibraryManagement.Data;
using LibraryManagement.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly LibraryDbContext _context;

        public BookRepository(LibraryDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Book> GetAllBooks()
        {
            return _context.Books.ToList();
        }

        public Book GetBookById(int id)
        {
            return _context.Books.Find(id);
        }

        public IEnumerable<Book> GetBooksByAuthor(string author)
        {
            return _context.Books.Where(b => b.Author == author).ToList();
        }

        public IEnumerable<Book> GetBooksByName(string name)
        {
            return _context.Books
                .Where(b => b.Name.Contains(name))
                .ToList();
        }

        public IEnumerable<Book> GetBooksByPrice(decimal price)
        {
            return _context.Books.Where(b => b.Price == price).ToList();
        }

        public void AddBook(Book book)
        {
            _context.Books.Add(book);
        }

        public void UpdateBook(Book book)
        {
            _context.Books.Update(book);
        }

        public void DeleteBook(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Books.Remove(book);
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}