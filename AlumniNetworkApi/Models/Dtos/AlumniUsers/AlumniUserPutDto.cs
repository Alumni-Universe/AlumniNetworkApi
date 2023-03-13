namespace AlumniNetworkApi.Models.Dtos.AlumniUsers
{
    public class AlumniUserPutDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public string? Status { get; set; }

        public string? Bio { get; set; }

        public string? FunFact { get; set; }
    }
}
