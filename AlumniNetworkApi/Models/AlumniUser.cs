using System;
using System.Collections.Generic;

namespace AlumniNetworkApi.Models;

public partial class AlumniUser
{
    public int UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Picture { get; set; } = null!;

    public string? Status { get; set; }

    public string? Bio { get; set; }

    public string? FunFact { get; set; }

    public virtual ICollection<AlumniGroup> AlumniGroups { get; } = new List<AlumniGroup>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<Post> PostSenders { get; } = new List<Post>();

    public virtual ICollection<Post> PostTargetUserNavigations { get; } = new List<Post>();

    public virtual ICollection<Rsvp> Rsvps { get; } = new List<Rsvp>();

    public virtual ICollection<Event> EventsNavigation { get; } = new List<Event>();

    public virtual ICollection<AlumniGroup> Groups { get; } = new List<AlumniGroup>();

    public virtual ICollection<Topic> Topics { get; } = new List<Topic>();
}
