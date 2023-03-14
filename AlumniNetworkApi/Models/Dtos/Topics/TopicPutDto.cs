namespace AlumniNetworkApi.Models.Dtos.Topics
{
    public class TopicPutDto
    {
        public int TopicId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;
    }
}
