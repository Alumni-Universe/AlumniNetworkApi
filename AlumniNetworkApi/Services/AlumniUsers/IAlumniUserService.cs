using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.AlumniUsers
{
    public interface IAlumniUserService : ICrudService<AlumniUser, string>
    {
        Task<IEnumerable<AlumniGroup>> GetAlumniGroups(string id);
        Task<IEnumerable<Event>> GetEvents(string id);
        Task<IEnumerable<Post>> GetPostSenders(string id);
        Task<IEnumerable<Post>> GetPostTargetUserNavigations(string id);
        Task<IEnumerable<Rsvp>> GetRsvps(string id);
        Task<IEnumerable<Event>> GetEventsNavigation(string id);
        Task<IEnumerable<AlumniGroup>> GetGroups(string id);
        Task<IEnumerable<Topic>> GetTopics(string id);
    }
}
