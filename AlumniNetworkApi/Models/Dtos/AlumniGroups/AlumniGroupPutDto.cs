namespace AlumniNetworkApi.Models.Dtos.AlumniGroups
{
    public class AlumniGroupPutDto
    {
        public int GroupId { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedBy { get; set; }
    }
}
