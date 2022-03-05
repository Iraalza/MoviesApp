using System.Collections.Generic;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MoviesApp.Controllers;
using MoviesApp.Filters;
using MoviesApp.Services;
using MoviesApp.Services.Dto;
using MoviesApp.ViewModels;

namespace ActorApp.Controllers
{
    public class ActorsController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMapper _mapper;
        private readonly IActorsService _service;


        public ActorsController(ILogger<HomeController> logger, IMapper mapper, IActorsService service)
        {
            _logger = logger;
            _mapper = mapper;
            _service = service;
        }

        // GET: Actors
        [HttpGet]
        //[Authorize]
        public IActionResult Index()
        {
            var actors = _mapper.Map<IEnumerable<ActorsDto>, IEnumerable<ActorViewModel>>(_service.GetAllActors());
            return View(actors);
        }

        // GET: Actors/Details/5
        [HttpGet]
        //[Authorize]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var viewModel = _mapper.Map<ActorViewModel>(_service.GetActor((int)id));

            if (viewModel == null)
            {
                return NotFound();
            }

            return View(viewModel);
        }

        // GET: Actors/Create
        [HttpGet]
        //[Authorize(Roles = "Admin")]
        public IActionResult Create()
        {
            return View();
        }

        // POST: Actors/Create  
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("FirstName,LastName,BerthDay")] InputActorViewModel inputModel)
        {
            if (ModelState.IsValid)
            {
                _service.AddActor(_mapper.Map<ActorsDto>(inputModel));
                return RedirectToAction(nameof(Index));
            }
            return View(inputModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        // GET: Actors/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var editModel = _mapper.Map<EditActorViewModel>(_service.GetActor((int)id));

            if (editModel == null)
            {
                return NotFound();
            }

            return View(editModel);
        }

        // POST: Actors/Edit/5
        [HttpPost]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("FirstName,LastName,BerthDay")] EditActorViewModel editModel)
        {
            if (ModelState.IsValid)
            {
                var actior = _mapper.Map<ActorsDto>(editModel);
                actior.ActorId = id;

                var result = _service.UpdateActor(actior);

                if (result == null)
                {
                    return NotFound();
                }

                return RedirectToAction(nameof(Index));
            }
            return View(editModel);
        }

        [HttpGet]
        //[Authorize(Roles = "Admin")]
        // GET: Actors/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var deleteModel = _mapper.Map<DeleteActorViewModel>(_service.GetActor((int)id));

            if (deleteModel == null)
            {
                return NotFound();
            }

            return View(deleteModel);
        }

        // POST: Actors/Delete/5
        [HttpPost, ActionName("Delete")]
        //[Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor == null)
            {
                return NotFound();
            }
            _logger.LogTrace($"Movie with id {actor.ActorId} has been deleted!");
            return RedirectToAction(nameof(Index));
        }
    }
}