using System;
using System.Collections.Generic;

namespace AlumniNetworkApi.Models;

public partial class AlumniGroup
{
    public int GroupId { get; set; }

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public bool IsPrivate { get; set; }

    public int CreatedBy { get; set; }

    public virtual AlumniUser CreatedByNavigation { get; set; } = null!;

    public virtual ICollection<Post> Posts { get; } = new List<Post>();

    public virtual ICollection<Event> Events { get; } = new List<Event>();

    public virtual ICollection<AlumniUser> Users { get; } = new List<AlumniUser>();
}
