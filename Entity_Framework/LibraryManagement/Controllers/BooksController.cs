using Microsoft.AspNetCore.Mvc;
using LibraryManagement.Models;
using LibraryManagement.Repositories;

namespace LibraryManagement.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBookRepository _repository;

        public BooksController(IBookRepository repository)
        {
            _repository = repository;
        }

        // GET: Books (All books)
        public IActionResult Index()
        {
            var books = _repository.GetAllBooks();
            return View(books);
        }

        // GET: Books/Details/5
        public IActionResult Details(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // Retrieve by Author
        public IActionResult ByAuthor(string author)
        {
            var books = _repository.GetBooksByAuthor(author);
            return View("Index", books);
        }

        // Retrieve by Name
        public IActionResult ByName(string name)
        {
            var books = _repository.GetBooksByName(name);
            return View("Index", books);
        }

        // Retrieve by Price
        public IActionResult ByPrice(decimal price)
        {
            var books = _repository.GetBooksByPrice(price);
            return View("Index", books);
        }

        // GET: Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _repository.AddBook(book);
                _repository.Save();
                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Book book)
        {
            if (id != book.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _repository.UpdateBook(book);
                _repository.Save();

                return RedirectToAction(nameof(Index));
            }

            return View(book);
        }

        // GET: Delete
        public IActionResult Delete(int id)
        {
            var book = _repository.GetBookById(id);

            if (book == null)
            {
                return NotFound();
            }

            return View(book);
        }

        // POST: Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _repository.DeleteBook(id);
            _repository.Save();

            return RedirectToAction(nameof(Index));
        }
    }
}