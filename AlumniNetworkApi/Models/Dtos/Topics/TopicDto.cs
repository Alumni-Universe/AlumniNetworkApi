namespace AlumniNetworkApi.Models.Dtos.Topics
{
    public class TopicDto
    {
        public int TopicId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<int>? Posts { get; set; }
        public List<int>? Events { get; set; }
        public List<int>? Users { get; set; }
    }
}
