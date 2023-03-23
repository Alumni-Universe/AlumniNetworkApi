using AlumniNetworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Services.AlumniUsers
{
    public class AlumniUserService : IAlumniUserService
    {
        private readonly AlumniDbContext _context;
        public AlumniUserService(AlumniDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AlumniUser obj)
        {
            await _context.AlumniUsers.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(string id)
        {
            var alumniUser = await _context.AlumniUsers.FindAsync(id);
            if (alumniUser == null)
            {
                // Exception
                Console.WriteLine("Alumni user not found with id: " + id);
            }
            _context.AlumniUsers.Remove(alumniUser);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlumniUser>> GetAllAsync()
        {
            return await _context.AlumniUsers
                .Include(g => g.AlumniGroups)
                .Include(e => e.Events)
                .Include(p => p.PostSenders)
                .Include(t => t.PostTargetUserNavigations)
                .Include(r => r.Rsvps)
                .Include(e => e.EventsNavigation)
                .Include(p => p.PostSenders)
                .Include(g => g.Groups)
                .Include(t => t.Topics)
                .ToListAsync();
        }

        public async Task<AlumniUser> GetByIdAsync(string id)
        {
            return await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(g => g.AlumniGroups)
                .Include(e => e.Events)
                .Include(p => p.PostSenders)
                .Include(t => t.PostTargetUserNavigations)
                .Include(r => r.Rsvps)
                .Include(e => e.EventsNavigation)
                .Include(p => p.PostSenders)
                .Include(g => g.Groups)
                .Include(t => t.Topics)
                .FirstAsync();
        }

        public async Task<IEnumerable<AlumniGroup>> GetAlumniGroups(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(g => g.AlumniGroups)
                .FirstAsync()).AlumniGroups;
        }

        public async Task<IEnumerable<Event>> GetEvents(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(e => e.Events)
                .FirstAsync()).Events;
        }

        public async Task<IEnumerable<Event>> GetEventsNavigation(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(e => e.EventsNavigation)
                .FirstAsync()).EventsNavigation;
        }

        public async Task<IEnumerable<AlumniGroup>> GetGroups(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(g => g.Groups)
                .FirstAsync()).Groups;
        }

        public async Task<IEnumerable<Post>> GetPostSenders(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(p => p.PostSenders)
                .FirstAsync()).PostSenders;
        }

        public async Task<IEnumerable<Post>> GetPostTargetUserNavigations(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(p => p.PostTargetUserNavigations)
                .FirstAsync()).PostTargetUserNavigations;
        }

        public async Task<IEnumerable<Rsvp>> GetRsvps(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(r => r.Rsvps)
                .FirstAsync()).Rsvps;
        }

        public async Task<IEnumerable<Topic>> GetTopics(string id)
        {
            return (await _context.AlumniUsers
                .Where(c => c.UserId == id)
                .Include(t => t.Topics)
                .FirstAsync()).Topics;
        }

        public async Task<AlumniUser> UpdateAsync(AlumniUser obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
