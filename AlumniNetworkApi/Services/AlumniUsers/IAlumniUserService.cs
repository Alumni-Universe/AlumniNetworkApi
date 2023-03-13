using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.AlumniUsers
{
    public interface IAlumniUserService : ICrudService<AlumniUser, int>
    {
        Task<IEnumerable<AlumniGroup>> GetAlumniGroups(int id);
        Task<IEnumerable<Event>> GetEvents(int id);
        Task<IEnumerable<Post>> GetPostSenders(int id);
        Task<IEnumerable<Post>> GetPostTargetUserNavigations(int id);
        Task<IEnumerable<Rsvp>> GetRsvps(int id);
        Task<IEnumerable<Event>> GetEventsNavigation(int id);
        Task<IEnumerable<AlumniGroup>> GetGroups(int id);
        Task<IEnumerable<Topic>> GetTopics(int id);
    }
}
