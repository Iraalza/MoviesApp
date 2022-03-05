using System.Collections.Generic;
using MoviesApp.Models;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services
{
    public interface IActorsService
    {
        ActorsDto GetActor(int id);
        IEnumerable<ActorsDto> GetAllActors();
        ActorsDto UpdateActor(ActorsDto actorDto);
        ActorsDto AddActor(ActorsDto actorDto);
        ActorsDto DeleteActor(int id);
    }
}
