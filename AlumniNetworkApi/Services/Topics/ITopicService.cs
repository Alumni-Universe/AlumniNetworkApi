using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.Topics
{
    public interface ITopicService : ICrudService<Topic, int>
    {
        Task<IEnumerable<Post>> GetPosts(int id);
        Task<IEnumerable<Event>> GetEvents(int id);
        Task<IEnumerable<AlumniUser>> GetUsers(int id);
    }
}
