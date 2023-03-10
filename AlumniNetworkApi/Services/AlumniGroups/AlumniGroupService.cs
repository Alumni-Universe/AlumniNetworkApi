using AlumniNetworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Services.AlumniGroups
{
    public class AlumniGroupService : IAlumniGroupService
    {
        private readonly AlumniDbContext _context;
        public AlumniGroupService(AlumniDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(AlumniGroup obj)
        {
            await _context.AlumniGroups.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var alumniGroup = await _context.AlumniGroups.FindAsync(id);
            if (alumniGroup == null)
            {
                // Exception
                Console.WriteLine("Alumni Group not found with id: " + id);
            }
            _context.AlumniGroups.Remove(alumniGroup);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<AlumniGroup>> GetAllAsync()
        {
            return await _context.AlumniGroups
                .Include(p => p.Posts)
                .Include(e => e.Events)
                .Include(u => u.Users)
                .ToListAsync();
        }

        public async Task<AlumniGroup> GetByIdAsync(int id)
        {
            return await _context.AlumniGroups
                .Where(c => c.GroupId == id)
                .Include(p => p.Posts)
                .Include(e => e.Events)
                .Include(u => u.Users)
                .FirstAsync();
        }

        public async Task<IEnumerable<Event>> GetEvents(int id)
        {
            return (await _context.AlumniGroups
                .Where(c => c.GroupId == id)
                .Include(e => e.Events)
                .FirstAsync()).Events;
        }

        public async Task<IEnumerable<Post>> GetPosts(int id)
        {
            return (await _context.AlumniGroups
                .Where(c => c.GroupId == id)
                .Include(p => p.Posts)
                .FirstAsync()).Posts;
        }

        public async Task<IEnumerable<AlumniUser>> GetUsers(int id)
        {
            return (await _context.AlumniGroups
                .Where(c => c.GroupId == id)
                .Include(u => u.Users)
                .FirstAsync()).Users;
        }

        public async Task<AlumniGroup> UpdateAsync(AlumniGroup obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
