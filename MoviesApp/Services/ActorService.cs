using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using MoviesApp.Data;
using MoviesApp.Models;
using MoviesApp.Services.Dto;

namespace MoviesApp.Services
{
    public class ActorsService : IActorsService
    {
        private readonly MoviesContext _context;
        private readonly IMapper _mapper;

        public ActorsService(MoviesContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public ActorsDto GetActor(int id)
        {
            return _mapper.Map<ActorsDto>(_context.Actor.FirstOrDefault(m => m.ActorId == id));
        }

        public IEnumerable<ActorsDto> GetAllActors()
        {
            return _mapper.Map<IEnumerable<Actors>, IEnumerable<ActorsDto>>(_context.Actor.ToList());
        }

        public ActorsDto UpdateActor(ActorsDto actorDto)
        {
            if (actorDto.ActorId == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            try
            {
                var actor = _mapper.Map<Actors>(actorDto);

                _context.Update(actor);
                _context.SaveChanges();

                return _mapper.Map<ActorsDto>(actor);
            }
            catch (DbUpdateException)
            {
                if (!ActorExists((int)actorDto.ActorId))
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
                else
                {
                    //упрощение для примера
                    //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                    return null;
                }
            }
        }

        public ActorsDto AddActor(ActorsDto actorsDto)
        {
            var actor = _context.Add(_mapper.Map<Actors>(actorsDto)).Entity;
            _context.SaveChanges();
            return _mapper.Map<ActorsDto>(actor);
        }

        public ActorsDto DeleteActor(int id)
        {
            var actor = _context.Actor.Find(id);
            if (actor == null)
            {
                //упрощение для примера
                //лучше всего генерировать ошибки и обрабатывать их на уровне конроллера
                return null;
            }

            _context.Actor.Remove(actor);
            _context.SaveChanges();

            return _mapper.Map<ActorsDto>(actor);
        }

        private bool ActorExists(int id)
        {
            return _context.Actor.Any(e => e.ActorId == id);
        }
    }
}
