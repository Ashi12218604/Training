using System;
using System.ComponentModel.DataAnnotations;

namespace CollegeEFMVC.Models.Validation
{
    public class MinimumAgeAttribute : ValidationAttribute
    {
        private readonly int _minAge;

        public MinimumAgeAttribute(int minAge)
        {
            _minAge = minAge;
        }

        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value == null)
                return new ValidationResult("Date of Birth is required");

            DateTime dob = (DateTime)value;

            // Future date check
            if (dob > DateTime.Today)
                return new ValidationResult("Date of Birth cannot be in the future");

            int age = DateTime.Today.Year - dob.Year;

            if (dob > DateTime.Today.AddYears(-age))
                age--;

            if (age < _minAge)
                return new ValidationResult($"Applicant must be at least {_minAge} years old");

            return ValidationResult.Success;
        }
    }
}