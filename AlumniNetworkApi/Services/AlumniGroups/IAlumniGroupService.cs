using AlumniNetworkApi.Models;

namespace AlumniNetworkApi.Services.AlumniGroups
{
    public interface IAlumniGroupService : ICrudService<AlumniGroup, int>
    {
        Task<IEnumerable<Post>> GetPosts(int id);
        Task<IEnumerable<Event>> GetEvents(int id);
        Task<IEnumerable<AlumniUser>> GetUsers(int id);
    }
}
