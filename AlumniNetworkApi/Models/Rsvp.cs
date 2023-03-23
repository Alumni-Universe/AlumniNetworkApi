using AlumniNetworkApi.Models;
using System;
using System.Collections.Generic;

namespace AlumniNetworkApi.Models;

public partial class Rsvp
{
    public DateTime LastUpdated { get; set; }

    public int GuestCount { get; set; }

    public string UserId { get; set; } = null!;

    public int EventId { get; set; }

    public virtual Event Event { get; set; } = null!;

    public virtual AlumniUser User { get; set; } = null!;
}
