using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkApi.Models;
using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Services.AlumniUsers;
using AutoMapper;

namespace AlumniNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlumniUsersController : ControllerBase
    {
        private readonly IAlumniUserService _alumniUserService;
        private readonly IMapper _mapper;

        public AlumniUsersController(IAlumniUserService alumniUserService, IMapper mapper)
        {
            _mapper = mapper;
            _alumniUserService = alumniUserService;
        }

        // GET: api/AlumniUsers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumniUserDto>>> GetAlumniUsers()
        {
            return Ok(_mapper.Map<List<AlumniUserDto>>
                (
                    await _alumniUserService.GetAllAsync()
                )
            );
        }

        // GET: api/AlumniUsers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumniUserDto>> GetAlumniUser(int id)
        {
            var alumniUser = _mapper.Map<AlumniUserDto>(await _alumniUserService.GetByIdAsync(id));

            if (alumniUser == null)
            {
                return NotFound();
            }

            return alumniUser;
        }

        // PUT: api/AlumniUsers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumniUser(int id, AlumniUserPutDto dto)
        {
            if (id != dto.UserId)
            {
                return NotFound();
            }

            try
            {
                await _alumniUserService.UpdateAsync(_mapper.Map<AlumniUser>(dto));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/AlumniUsers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostAlumniUser(AlumniUserPostDto dto)
        {
            AlumniUser alumniUser = _mapper.Map<AlumniUser>(dto);
            await _alumniUserService.AddAsync(alumniUser);
            return CreatedAtAction("GetAlumniUser", new { id = alumniUser.UserId }, alumniUser);
        }

        // DELETE: api/AlumniUsers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumniUser(int id)
        {
            var alumniUser = await _alumniUserService.GetByIdAsync(id);
            if (alumniUser == null)
            {
                return NotFound();
            }

            try
            {
                await _alumniUserService.DeleteByIdAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
