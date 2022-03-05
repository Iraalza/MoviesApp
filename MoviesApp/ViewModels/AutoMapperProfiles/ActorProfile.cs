using MoviesApp.Services.Dto;
using AutoMapper;

namespace MoviesApp.ViewModels.AutoMapperProfiles
{
    public class ActorProfile : Profile
    {
        public ActorProfile()
        {
            CreateMap<ActorsDto, InputActorViewModel>().ReverseMap();
            CreateMap<ActorsDto, DeleteActorViewModel>();
            CreateMap<ActorsDto, EditActorViewModel>().ReverseMap();
            CreateMap<ActorsDto, ActorViewModel>();
        }
    }
}
