using AutoMapper;
using MoviesApp.Models;
using MoviesApp.ViewModels;

namespace MoviesApp.Services.Dto.AutoMapperProfiles
{
    public class ActorsDtoProfile : Profile
    {
        public ActorsDtoProfile()
        {
            CreateMap<Actors, ActorsDto>().ReverseMap();
        }
    }
}
