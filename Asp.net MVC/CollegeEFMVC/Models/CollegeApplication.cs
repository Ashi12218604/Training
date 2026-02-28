using CollegeEFMVC.Models.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CollegeEFMVC.Models
{
    [Index(nameof(Email), IsUnique = true)]
    [Index(nameof(Phone), IsUnique = true)]
    [Index(nameof(AadhaarNumber), IsUnique = true)]
    public class CollegeApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        // ---------------- BASIC DETAILS ----------------

        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(10)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid Indian phone number")]
        public string Phone { get; set; } = string.Empty;

        // ---------------- AADHAAR ----------------

        [Required(ErrorMessage = "Aadhaar number is required")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "Aadhaar must be exactly 12 digits")]
        [RegularExpression(@"^\d{12}$", ErrorMessage = "Aadhaar must contain only digits")]
        public string AadhaarNumber { get; set; } = string.Empty;

        // ---------------- OTHER DETAILS ----------------

        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;

        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [MinimumAge(18, ErrorMessage = "Applicant must be at least 18 years old")]
        public DateTime DateOfBirth { get; set; }

        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; } = string.Empty;

        [Required(ErrorMessage = "Percentage is required")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal Percentage { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Address must be at least 10 characters")]
        [RegularExpression(@"^(?=.*[A-Za-z]).+$", ErrorMessage = "Address cannot be only numbers")]
        public string Address { get; set; } = string.Empty;

        // ---------------- PHOTO ----------------

        public string? PhotoPath { get; set; }

        [NotMapped]
        public IFormFile? PhotoFile { get; set; }
    }
}