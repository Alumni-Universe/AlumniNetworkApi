using System;
using System.Collections.Generic;

namespace AlumniNetworkApi.Models;

public partial class Post
{
    public int PostId { get; set; }

    public DateTime LastUpdated { get; set; }

    public string? PostMessage { get; set; }

    public string PostTarget { get; set; } = null!;

    public int SenderId { get; set; }

    public int? ReplyParentId { get; set; }

    public int? TargetUser { get; set; }

    public int? TargetGroup { get; set; }

    public int? TargetTopic { get; set; }

    public int? TargetEvent { get; set; }

    public virtual ICollection<Post> InverseReplyParent { get; } = new List<Post>();

    public virtual Post? ReplyParent { get; set; }

    public virtual AlumniUser Sender { get; set; } = null!;

    public virtual Event? TargetEventNavigation { get; set; }

    public virtual AlumniGroup? TargetGroupNavigation { get; set; }

    public virtual Topic? TargetTopicNavigation { get; set; }

    public virtual AlumniUser? TargetUserNavigation { get; set; }
}
