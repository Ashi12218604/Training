using System.ComponentModel.DataAnnotations;

namespace StudentManagement.Models
{
    public class Student
    {
        [Key]
        public int StudentId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        public string Course { get; set; } = string.Empty;

        public int Semester { get; set; }

        public string Photo { get; set; } = string.Empty;

        public ICollection<Marks> Marks { get; set; } = new List<Marks>();
    }
}