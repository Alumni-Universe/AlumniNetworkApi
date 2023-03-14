using AlumniNetworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Services.Events
{
    public class EventService : IEventService
    {
        private readonly AlumniDbContext _context;
        public EventService(AlumniDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Event obj)
        {
            await _context.Events.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var @event = await _context.Events.FindAsync(id);
            if (@event == null)
            {
                // Exception
                Console.WriteLine("Event not found with id: " + id);
            }
            _context.Events.Remove(@event);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Event>> GetAllAsync()
        {
            return await _context.Events
                .Include(p => p.Posts)
                .Include(r => r.Rsvps)
                .Include(g => g.Groups)
                .Include(t => t.Topics)
                .Include(u => u.Users)
                .ToListAsync();
        }

        public async Task<Event> GetByIdAsync(int id)
        {
            return await _context.Events
                .Where(e => e.EventId == id)
                .Include(p => p.Posts)
                .Include(r => r.Rsvps)
                .Include(g => g.Groups)
                .Include(t => t.Topics)
                .Include(u => u.Users)
                .FirstAsync();
        }

        public async Task<IEnumerable<AlumniGroup>> GetGroups(int id)
        {
            return (await _context.Events
                .Where(e => e.EventId == id)
                .Include(g => g.Groups)
                .FirstAsync()).Groups;
        }

        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            return (await _context.Events
                .Where(e => e.EventId == id)
                .Include(p => p.Posts)
                .FirstAsync()).Posts;
        }

        public async Task<IEnumerable<Rsvp>> GetRsvps(int id)
        {
            return (await _context.Events
                .Where(e => e.EventId == id)
                .Include(r => r.Rsvps)
                .FirstAsync()).Rsvps;
        }

        public async Task<IEnumerable<Topic>> GetTopics(int id)
        {
            return (await _context.Events
                .Where(e => e.EventId == id)
                .Include(t => t.Topics)
                .FirstAsync()).Topics;
        }

        public async Task<IEnumerable<AlumniUser>> GetUsers(int id)
        {
            return (await _context.Events
                .Where(e => e.EventId == id)
                .Include(u => u.Users)
                .FirstAsync()).Users;
        }

        public async Task<Event> UpdateAsync(Event obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
