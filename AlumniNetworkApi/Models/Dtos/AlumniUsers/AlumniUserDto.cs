namespace AlumniNetworkApi.Models.Dtos.AlumniUsers
{
    public class AlumniUserDto
    {
        public int UserId { get; set; }

        public string Name { get; set; } = null!;

        public string Picture { get; set; } = null!;

        public string? Status { get; set; }

        public string? Bio { get; set; }

        public string? FunFact { get; set; }
        public List<int>? AlumniGroups { get; set; }
        public List<int>? Events { get; set; }
        public List<int>? PostSenders { get; set; }
        public List<int>? PostTargetUserNavigations { get; set; }
        public List<int>? Rsvps { get; set; }
        public List<int>? EventsNavigation { get; set; }
        public List<int>? Groups { get; set; }
        public List<int>? Topics { get; set; }
    }
}
