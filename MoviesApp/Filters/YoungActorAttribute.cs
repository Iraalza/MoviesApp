using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Models;

namespace MoviesApp.Filters
{
    public class YoungActorAttribute : ValidationAttribute
    {
        public YoungActorAttribute(int year)
        {
            Year = year;
        }

        public int Year { get; }

        public string GetErrorMessage() =>
            $"Actors should not be born before {Year}.";

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var releaseYear = ((DateTime)value).Year;

            if (releaseYear > Year)
            {
                return new ValidationResult(GetErrorMessage());
            }

            return ValidationResult.Success;
        }
    }
}
