namespace AlumniNetworkApi.Models.Dtos.AlumniGroups
{
    public class AlumniGroupDto
    {
        public int GroupId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedBy { get; set; }
        public List<int>? Posts { get; set; }
        public List<int>? Events { get; set; }
        public List<int>? Users { get; set; }
    }
}
