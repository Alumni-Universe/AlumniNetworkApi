using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkApi.Models;
using AlumniNetworkApi.Services.Events;
using AutoMapper;
using AlumniNetworkApi.Models.Dtos.Events;
using Microsoft.AspNetCore.Authorization;

namespace AlumniNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class EventsController : ControllerBase
    {
        private readonly IEventService _eventService;
        private readonly IMapper _mapper;

        public EventsController(IEventService eventService, IMapper mapper)
        {
            _mapper = mapper;
            _eventService = eventService;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EventDto>>> GetEvents()
        {
            return Ok(_mapper.Map<List<EventDto>>
                (
                    await _eventService.GetAllAsync()
                )
            );
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<EventDto>> GetEvent(int id)
        {
            var @event = _mapper.Map<EventDto>(await _eventService.GetByIdAsync(id));

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, EventPutDto dto)
        {
            if (id != dto.EventId)
            {
                return NotFound();
            }

            try
            {
                await _eventService.UpdateAsync(_mapper.Map<Event>(dto));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostEvent(EventPostDto dto)
        {
            Event @event = _mapper.Map<Event>(dto);
            await _eventService.AddAsync(@event);
            return CreatedAtAction("GetEvent", new { id = @event.EventId }, @event);
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _eventService.GetByIdAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            try
            {
                await _eventService.DeleteByIdAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
