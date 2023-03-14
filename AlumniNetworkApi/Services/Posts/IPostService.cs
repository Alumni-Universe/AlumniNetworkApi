using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.Posts
{
    public interface IPostService : ICrudService<Post, int>
    {
        Task<IEnumerable<Post>> GetInverseReplyParent(int id);
    }
}
