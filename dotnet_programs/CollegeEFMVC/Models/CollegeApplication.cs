using System;
using System.ComponentModel.DataAnnotations;
using CollegeEFMVC.Models.Validation;

namespace CollegeEFMVC.Models
{
    public class CollegeApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        // ---------- FULL NAME ----------
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Name must be at least 3 characters")]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only alphabets")]
        public string FullName { get; set; } = string.Empty;

        // ---------- EMAIL ----------
        [Required(ErrorMessage = "Email is required")]
        [StringLength(150)]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        [RegularExpression(
            @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$",
            ErrorMessage = "Email must contain a valid domain like .com, .in, .edu"
        )]
        public string Email { get; set; } = string.Empty;

        // ---------- PHONE ----------
        [Required(ErrorMessage = "Phone number is required")]
        [StringLength(15)]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid Indian phone number")]
        public string Phone { get; set; } = string.Empty;

        // ---------- GENDER ----------
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;

        // ---------- DATE OF BIRTH ----------
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        [MinimumAge(18)]
        public DateTime DateOfBirth { get; set; }

        // ---------- COURSE ----------
        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; } = string.Empty;

        // ---------- PERCENTAGE ----------
        [Required(ErrorMessage = "Percentage is required")]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal Percentage { get; set; }

        // ---------- ADDRESS ----------
        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, MinimumLength = 10, ErrorMessage = "Address must be at least 10 characters")]
        [RegularExpression(
            @"^(?=.*[A-Za-z])[A-Za-z0-9\s,./-]+$",
            ErrorMessage = "Address must contain meaningful text, not only numbers"
        )]
        public string Address { get; set; } = string.Empty;
    }
}