﻿using AlumniNetworkApi.Models.Dtos.AlumniUsers;
using AlumniNetworkApi.Models.Dtos.Events;
using AlumniNetworkApi.Models.Dtos.AlumniGroups;
using AlumniNetworkApi.Models.Dtos.Topics;

namespace AlumniNetworkApi.Models.Dtos.Posts
{
    public class PostDto
    {
        public int PostId { get; set; }

        public DateTime LastUpdated { get; set; }

        public string PostTitle { get; set; }

        public string? PostMessage { get; set; }

        public string PostTarget { get; set; } = null!;

        public string SenderId { get; set; }

        public int? ReplyParentId { get; set; }

        public string? TargetUser { get; set; }

        public int? TargetGroup { get; set; }

        public int? TargetTopic { get; set; }

        public int? TargetEvent { get; set; }

        public List<PostReplyDto>? InverseReplyParent { get; set; }
        public virtual AlumniUserInfoDto Sender { get; set; } = null!;
        public virtual EventInfoDto? TargetEventNavigation { get; set; }
        public virtual AlumniGroupInfoDto? TargetGroupNavigation { get; set; }
        public virtual TopicInfoDto? TargetTopicNavigation { get; set; }
        public virtual AlumniUserInfoDto? TargetUserNavigation { get; set; }
    }
}
