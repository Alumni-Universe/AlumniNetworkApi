namespace AlumniNetworkApi.Models.Dtos.Posts
{
    public class PostPutDto
    {
        public int PostId { get; set; }

        public DateTime LastUpdated { get; set; }

        public string? PostMessage { get; set; }

        public string PostTarget { get; set; } = null!;

        public int SenderId { get; set; }

        public int? ReplyParentId { get; set; }

        public int? TargetUser { get; set; }

        public int? TargetGroup { get; set; }

        public int? TargetTopic { get; set; }

        public int? TargetEvent { get; set; }
    }
}
