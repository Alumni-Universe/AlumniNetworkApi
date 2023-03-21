using AlumniNetworkApi.Models;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Services.Posts
{
    public class PostService : IPostService
    {
        private readonly AlumniDbContext _context;
        public PostService(AlumniDbContext context)
        {
            _context = context;
        }
        public async Task AddAsync(Post obj)
        {
            await _context.Posts.AddAsync(obj);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteByIdAsync(int id)
        {
            var post = await _context.Posts.FindAsync(id);
            if (post == null)
            {
                // Exception
                Console.WriteLine("Post not found with id: " + id);
            }
            _context.Posts.Remove(post);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Post>> GetAllAsync()
        {
            return await _context.Posts
                .Include(p => p.InverseReplyParent)
                .Include(p => p.Sender)
                .Include(p => p.TargetEventNavigation)
                .Include(p => p.TargetGroupNavigation)
                .Include(p => p.TargetTopicNavigation)
                .Include(p => p.TargetUserNavigation)
                .ToListAsync();
        }

        public async Task<Post> GetByIdAsync(int id)
        {
            return await _context.Posts
                .Where(e => e.PostId == id)
                .Include(p => p.InverseReplyParent)
                .FirstAsync();
        }

        public async Task<IEnumerable<Post>> GetInverseReplyParent(int id)
        {
            return (await _context.Posts
                .Where(e => e.PostId == id)
                .Include(p => p.InverseReplyParent)
                .FirstAsync()).InverseReplyParent;
        }

        public async Task<Post> UpdateAsync(Post obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return obj;
        }
    }
}
