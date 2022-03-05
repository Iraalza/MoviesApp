using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class OldActorAttribute : ValidationAttribute
    {
        public OldActorAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Actors must be born no later than {Year}.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var releaseYear = ((DateTime)value).Year;

            if (releaseYear < Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
