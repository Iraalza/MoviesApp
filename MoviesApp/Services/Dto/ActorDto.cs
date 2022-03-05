using System;
using System.ComponentModel.DataAnnotations;
using MoviesApp.Filters;

namespace MoviesApp.Services.Dto
{
    public class ActorsDto
    {
        //Id - null, когда отправлена нам для создания
        //Обратите внимание на конфигурацию мэппинга
        //Id может отсуствовать в DTO, если практикуются разделения на Input/Output модели
        public int? ActorId { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "FirstName length can't be more than 32.")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(32, ErrorMessage = "LastName length can't be more than 32.")]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [OldActor(1922)]
        [YoungActor(2014)]
        public DateTime BerthDay { get; set; }
    }
}
