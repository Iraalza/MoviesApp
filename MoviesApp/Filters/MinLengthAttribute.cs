using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class MinLengthAttribute : ValidationAttribute
    {
        public MinLengthAttribute()
        {
        }

        public string GetErrorMessage() =>
            $"The actor's first name and last name nave at least 4 characters.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var str = (string)value;
            if(str.Length < 4)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
