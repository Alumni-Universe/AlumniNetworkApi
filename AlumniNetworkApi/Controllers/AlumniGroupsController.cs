using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkApi.Models;
using AlumniNetworkApi.Services.AlumniGroups;
using AutoMapper;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using Microsoft.AspNetCore.Authorization;

namespace AlumniNetworkAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AlumniGroupsController : ControllerBase
    {
        private readonly IAlumniGroupService _alumniGroupService;
        private readonly IMapper _mapper;

        public AlumniGroupsController(IAlumniGroupService alumniGroupService, IMapper mapper)
        {
            _mapper = mapper;
            _alumniGroupService = alumniGroupService;
        }

        // GET: api/AlumniGroups
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlumniGroupDto>>> GetAlumniGroups()
        {
            return Ok(_mapper.Map<List<AlumniGroupDto>>
                (
                    await _alumniGroupService.GetAllAsync()
                )
            );
        }

        // GET: api/AlumniGroups/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AlumniGroupDto>> GetAlumniGroup(int id)
        {
            var alumniGroup = _mapper.Map<AlumniGroupDto>(await _alumniGroupService.GetByIdAsync(id));

            if (alumniGroup == null)
            {
                return NotFound();
            }

            return alumniGroup;
        }

        // PUT: api/AlumniGroups/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAlumniGroup(int id, AlumniGroupPutDto dto)
        {
            if (id != dto.GroupId)
            {
                return NotFound();
            }

            try
            {
                await _alumniGroupService.UpdateAsync(_mapper.Map<AlumniGroup>(dto));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/AlumniGroups
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostAlumniGroup(AlumniGroupPostDto dto)
        {
            AlumniGroup alumniGroup = _mapper.Map<AlumniGroup>(dto);
            await _alumniGroupService.AddAsync(alumniGroup);
            return CreatedAtAction("GetAlumniGroup", new { id = alumniGroup.GroupId }, alumniGroup);
        }

        // DELETE: api/AlumniGroups/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAlumniGroup(int id)
        {
            var alumniGroup = await _alumniGroupService.GetByIdAsync(id);
            if (alumniGroup == null)
            {
                return NotFound();
            }

            try
            {
                await _alumniGroupService.DeleteByIdAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
