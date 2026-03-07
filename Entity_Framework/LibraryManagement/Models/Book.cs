using System.ComponentModel.DataAnnotations;

namespace LibraryManagement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [StringLength(15, ErrorMessage = "Book name cannot exceed 15 characters")]
        public string Name { get; set; }

        public string Author { get; set; }

        public decimal Price { get; set; }
    }
}