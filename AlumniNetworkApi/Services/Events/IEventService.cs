using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.Events
{
    public interface IEventService : ICrudService<Event, int>
    {
        Task<IEnumerable<Post>> GetPosts(int id);
        Task<IEnumerable<Rsvp>> GetRsvps(int id);
        Task<IEnumerable<AlumniGroup>> GetGroups(int id);
        Task<IEnumerable<Topic>> GetTopics(int id);
        Task<IEnumerable<AlumniUser>> GetUsers(int id);
    }
}
