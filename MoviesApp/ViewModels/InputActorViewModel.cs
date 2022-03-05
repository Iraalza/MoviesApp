using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.ViewModels
{
    public class InputActorViewModel
    {
        [Required]
        [Filters.MinLength]
        public string FirstName { get; set; }

        [Required]
        [Filters.MinLength]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [OldActor(1922)]
        [YoungActor(2014)]
        public DateTime BerthDay { get; set; }
        
    }
}
