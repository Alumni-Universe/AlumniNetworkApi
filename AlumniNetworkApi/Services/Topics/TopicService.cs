using AlumniNetworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Services.Topics
{
    public class TopicService : ITopicService
    {
        private readonly AlumniDbContext _context;
        public TopicService(AlumniDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Topic obj)
        {
            await _context.Topics.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var topic = await _context.Topics.FindAsync(id);
            if (topic == null)
            {
                // Exception
                Console.WriteLine("Topic not found with id: " + id);
            }
            _context.Topics.Remove(topic);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Topic>> GetAllAsync()
        {
            return await _context.Topics
                .Include(p => p.Posts)
                .Include(e => e.Events)
                .Include(u => u.Users)
                .ToListAsync();
        }

        public async Task<Topic> GetByIdAsync(int id)
        {
            return await _context.Topics
                .Where(e => e.TopicId == id)
                .Include(p => p.Posts)
                .Include(e => e.Events)
                .Include(u => u.Users)
                .FirstAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents(int id)
        {
            return (await _context.Topics
                .Where(t => t.TopicId == id)
                .Include(e => e.Events)
                .FirstAsync()).Events;
        }

        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            return (await _context.Topics
                .Where(t => t.TopicId == id)
                .Include(p => p.Posts)
                .FirstAsync()).Posts;
        }

        public async Task<IEnumerable<AlumniUser>> GetUsers(int id)
        {
            return (await _context.Topics
                .Where(t => t.TopicId == id)
                .Include(u => u.Users)
                .FirstAsync()).Users;
        }

        public async Task<Topic> UpdateAsync(Topic obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
