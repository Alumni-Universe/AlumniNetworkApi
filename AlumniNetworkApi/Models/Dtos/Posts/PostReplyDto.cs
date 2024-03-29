﻿using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.Topics;

namespace AlumniNetworkApi.Models.Dtos.Posts
{
    public class PostReplyDto
    {
        public int PostId { get; set; }

        public DateTime LastUpdated { get; set; }

        public string? PostMessage { get; set; }

        public string PostTarget { get; set; } = null!;

        public string SenderId { get; set; }

        public int? ReplyParentId { get; set; }

        public string? TargetUser { get; set; }

        public int? TargetGroup { get; set; }

        public int? TargetTopic { get; set; }

        public int? TargetEvent { get; set; }

        public virtual AlumniUserInfoDto Sender { get; set; } = null!;
    }
}
