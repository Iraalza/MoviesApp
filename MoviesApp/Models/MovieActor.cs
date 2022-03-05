using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace MoviesApp.Models
{
    public class MovieActor
    {
        [Key]
        public int MovieActorId { get; set; }
        [ForeignKey("Actors")]
        public int ActorId { get; set; }
        public virtual Actors Actor { get; set; }
        [ForeignKey("Movie")]
        public int MovieId { get; set; }
        public virtual Movie Movie { get; set; }
        
    }
}
