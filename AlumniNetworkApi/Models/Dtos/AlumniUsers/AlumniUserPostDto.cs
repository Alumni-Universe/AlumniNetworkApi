namespace AlumniNetworkApi.Models.Dtos.AlumniUsers
{
    public class AlumniUserPostDto
    {
        public string UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public string? Status { get; set; }

        public string? Bio { get; set; }

        public string? FunFact { get; set; }
    }
}
