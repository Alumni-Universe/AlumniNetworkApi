using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AlumniNetworkApi.Models;
using AutoMapper;
using AlumniNetworkApi.Services.Topics;
using AlumniNetworkApi.Models.Dtos.Topics;

namespace AlumniNetworkApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TopicsController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicsController(ITopicService topicService, IMapper mapper)
        {
            _mapper = mapper;
            _topicService = topicService;
        }

        // GET: api/Topics
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TopicDto>>> GetTopics()
        {
            return Ok(_mapper.Map<List<TopicDto>>
                (
                    await _topicService.GetAllAsync()
                )
            );
        }

        // GET: api/Topics/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TopicDto>> GetTopic(int id)
        {
            var topic = _mapper.Map<TopicDto>(await _topicService.GetByIdAsync(id));

            if (topic == null)
            {
                return NotFound();
            }

            return topic;
        }

        // PUT: api/Topics/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTopic(int id, TopicPutDto dto)
        {
            if (id != dto.TopicId)
            {
                return NotFound();
            }

            try
            {
                await _topicService.UpdateAsync(_mapper.Map<Topic>(dto));
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }

        // POST: api/Topics
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult> PostTopic(TopicPostDto dto)
        {
            Topic topic = _mapper.Map<Topic>(dto);
            await _topicService.AddAsync(topic);
            return CreatedAtAction("GetTopic", new { id = topic.TopicId }, topic);
        }

        // DELETE: api/Topics/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTopic(int id)
        {
            var topic = await _topicService.GetByIdAsync(id);
            if (topic == null)
            {
                return NotFound();
            }

            try
            {
                await _topicService.DeleteByIdAsync(id);
            }
            catch (DbUpdateConcurrencyException)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
