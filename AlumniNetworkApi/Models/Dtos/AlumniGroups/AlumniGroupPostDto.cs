namespace AlumniNetworkApi.Models.Dtos.AlumniGroups
{
    public class AlumniGroupPostDto
    {
        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public bool IsPrivate { get; set; }

        public int CreatedBy { get; set; }
    }
}
