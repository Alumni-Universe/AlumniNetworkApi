using System;
using System.Collections.Generic;

namespace AlumniNetworkApi.Models;

public partial class Event
{
    public int EventId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool AllowGuests { get; set; }

    public string? BannerImg { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime EndTime { get; set; }

    public int CreatedBy { get; set; }

    public virtual AlumniUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual ICollection<Rsvp> Rsvps { get; } = new List<Rsvp>();

    public virtual ICollection<AlumniGroup> Groups { get; } = new List<AlumniGroup>();

    public virtual ICollection<Topic> Topics { get; } = new List<Topic>();

    public virtual ICollection<AlumniUser> Users { get; } = new List<AlumniUser>();
}
