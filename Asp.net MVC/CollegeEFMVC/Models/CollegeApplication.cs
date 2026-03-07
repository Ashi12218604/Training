using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeEFMVC.Models
{
    public class CollegeApplication
    {
        [Key]
        public int ApplicationId { get; set; }

        // NAME
        [Required(ErrorMessage = "Full Name is required")]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z\s]+$", ErrorMessage = "Name must contain only letters")]
        public string FullName { get; set; } = string.Empty;

        // EMAIL
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email format")]
        public string Email { get; set; } = string.Empty;

        // PHONE
        [Required(ErrorMessage = "Phone number is required")]
        [RegularExpression(@"^[6-9]\d{9}$", ErrorMessage = "Enter valid Indian phone number")]
        public string Phone { get; set; } = string.Empty;

        // GENDER
        [Required(ErrorMessage = "Gender is required")]
        public string Gender { get; set; } = string.Empty;

        // DOB
        [Required(ErrorMessage = "Date of Birth is required")]
        [DataType(DataType.Date)]
        public DateTime DateOfBirth { get; set; }

        // COURSE
        [Required(ErrorMessage = "Course is required")]
        public string Course { get; set; } = string.Empty;

        // PERCENTAGE
        [Required]
        [Range(0, 100, ErrorMessage = "Percentage must be between 0 and 100")]
        public decimal Percentage { get; set; }

        // ADDRESS
        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, MinimumLength = 10)]
        [RegularExpression(@"^(?=.*[A-Za-z]).+$", ErrorMessage = "Address cannot be only numbers")]
        public string Address { get; set; } = string.Empty;
    }
}