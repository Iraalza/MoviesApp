using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MoviesApp.Services;
using MoviesApp.Services.Dto;

namespace MoviesApp.Controllers
{
    [Route("api/actors")]
    [ApiController]
    public class ActorsApiController : ControllerBase
    {
        private readonly IActorsService _service;

        public ActorsApiController(IActorsService service)
        {
            _service = service;
        }

        [HttpGet] // GET: /api/actors
        [ProducesResponseType(200, Type = typeof(IEnumerable<ActorsDto>))]
        [ProducesResponseType(404)]
        public ActionResult<IEnumerable<ActorsDto>> GetActors()
        {
            return Ok(_service.GetAllActors());
        }

        [HttpGet("{id}")] // GET: /api/actors/5
        [ProducesResponseType(200, Type = typeof(ActorsDto))]
        [ProducesResponseType(404)]
        public IActionResult GetById(int id)
        {
            var actor = _service.GetActor(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }

        [HttpPost] // POST: api/actors
        public ActionResult<ActorsDto> PostActor(ActorsDto inputDto)
        {
            var actor = _service.AddActor(inputDto);
            return CreatedAtAction("GetById", new { id = actor.ActorId }, actor);
        }

        [HttpPut("{id}")] // PUT: api/actors/5
        public IActionResult UpdateActor(int id, ActorsDto editDto)
        {
            var actor = _service.UpdateActor(editDto);

            if (actor == null)
            {
                return BadRequest();
            }

            return Ok(actor);
        }

        [HttpDelete("{id}")] // DELETE: api/actor/5
        public ActionResult<ActorsDto> DeleteActor(int id)
        {
            var actor = _service.DeleteActor(id);
            if (actor == null) return NotFound();
            return Ok(actor);
        }
    }
}
