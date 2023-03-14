using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace AlumniNetworkApi.Models;

public partial class AlumniDbContext : DbContext
{
    public AlumniDbContext()
    {
    }

    public AlumniDbContext(DbContextOptions<AlumniDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AlumniGroup> AlumniGroups { get; set; }

    public virtual DbSet<AlumniUser> AlumniUsers { get; set; }

    public virtual DbSet<Event> Events { get; set; }

    public virtual DbSet<Post> Posts { get; set; }

    public virtual DbSet<Rsvp> Rsvps { get; set; }

    public virtual DbSet<Topic> Topics { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AlumniGroup>(entity =>
        {
            entity.HasKey(e => e.GroupId).HasName("PK__AlumniGr__D57795A00CAD2856");

            entity.ToTable("AlumniGroup");

            entity.Property(e => e.GroupId).HasColumnName("group_id");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.IsPrivate).HasColumnName("is_private");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.AlumniGroups)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__AlumniGro__creat__38996AB5");
        });

        modelBuilder.Entity<AlumniUser>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__AlumniUs__B9BE370F66C40819");

            entity.ToTable("AlumniUser");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.Bio)
                .HasColumnType("text")
                .HasColumnName("bio");
            entity.Property(e => e.FunFact)
                .HasColumnType("text")
                .HasColumnName("fun_fact");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.Picture)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("picture");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("status");

            entity.HasMany(d => d.Groups).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "GroupMember",
                    r => r.HasOne<AlumniGroup>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GroupMemb__group__412EB0B6"),
                    l => l.HasOne<AlumniUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__GroupMemb__user___403A8C7D"),
                    j =>
                    {
                        j.HasKey("UserId", "GroupId").HasName("PK__GroupMem__A4E94E55BE83AB32");
                        j.ToTable("GroupMember");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                    });

            entity.HasMany(d => d.Topics).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "TopicMember",
                    r => r.HasOne<Topic>().WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TopicMemb__topic__5BE2A6F2"),
                    l => l.HasOne<AlumniUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__TopicMemb__user___5AEE82B9"),
                    j =>
                    {
                        j.HasKey("UserId", "TopicId").HasName("PK__TopicMem__34E39D31EA4E1D2E");
                        j.ToTable("TopicMember");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                        j.IndexerProperty<int>("TopicId").HasColumnName("topic_id");
                    });
        });

        modelBuilder.Entity<Event>(entity =>
        {
            entity.HasKey(e => e.EventId).HasName("PK__Event__2370F727C54D1570");

            entity.ToTable("Event");

            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.AllowGuests).HasColumnName("allow_guests");
            entity.Property(e => e.BannerImg)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("banner_img");
            entity.Property(e => e.CreatedBy).HasColumnName("created_by");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.EndTime)
                .HasColumnType("datetime")
                .HasColumnName("end_time");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
            entity.Property(e => e.StartTime)
                .HasColumnType("datetime")
                .HasColumnName("start_time");

            entity.HasOne(d => d.CreatedByNavigation).WithMany(p => p.Events)
                .HasForeignKey(d => d.CreatedBy)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Event__created_b__3D5E1FD2");

            entity.HasMany(d => d.Groups).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventGroupInvite",
                    r => r.HasOne<AlumniGroup>().WithMany()
                        .HasForeignKey("GroupId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventGrou__group__48CFD27E"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventGrou__event__47DBAE45"),
                    j =>
                    {
                        j.HasKey("EventId", "GroupId").HasName("PK__EventGro__3E278E7DC8FE4DDE");
                        j.ToTable("EventGroupInvite");
                        j.IndexerProperty<int>("EventId").HasColumnName("event_id");
                        j.IndexerProperty<int>("GroupId").HasColumnName("group_id");
                    });

            entity.HasMany(d => d.Topics).WithMany(p => p.Events)
                .UsingEntity<Dictionary<string, object>>(
                    "EventTopicInvite",
                    r => r.HasOne<Topic>().WithMany()
                        .HasForeignKey("TopicId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventTopi__topic__5812160E"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventTopi__event__571DF1D5"),
                    j =>
                    {
                        j.HasKey("EventId", "TopicId").HasName("PK__EventTop__AE2D5D199B41EF44");
                        j.ToTable("EventTopicInvite");
                        j.IndexerProperty<int>("EventId").HasColumnName("event_id");
                        j.IndexerProperty<int>("TopicId").HasColumnName("topic_id");
                    });

            entity.HasMany(d => d.Users).WithMany(p => p.EventsNavigation)
                .UsingEntity<Dictionary<string, object>>(
                    "EventUserInvite",
                    r => r.HasOne<AlumniUser>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventUser__user___44FF419A"),
                    l => l.HasOne<Event>().WithMany()
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK__EventUser__event__440B1D61"),
                    j =>
                    {
                        j.HasKey("EventId", "UserId").HasName("PK__EventUse__C8EB14578960223F");
                        j.ToTable("EventUserInvite");
                        j.IndexerProperty<int>("EventId").HasColumnName("event_id");
                        j.IndexerProperty<int>("UserId").HasColumnName("user_id");
                    });
        });

        modelBuilder.Entity<Post>(entity =>
        {
            entity.HasKey(e => e.PostId).HasName("PK__Post__3ED7876606323A85");

            entity.ToTable("Post");

            entity.Property(e => e.PostId).HasColumnName("post_id");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("last_updated");
            entity.Property(e => e.PostMessage)
                .HasColumnType("text")
                .HasColumnName("post_message");
            entity.Property(e => e.PostTarget)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("post_target");
            entity.Property(e => e.ReplyParentId).HasColumnName("reply_parent_id");
            entity.Property(e => e.SenderId).HasColumnName("sender_id");
            entity.Property(e => e.TargetEvent).HasColumnName("target_event");
            entity.Property(e => e.TargetGroup).HasColumnName("target_group");
            entity.Property(e => e.TargetTopic).HasColumnName("target_topic");
            entity.Property(e => e.TargetUser).HasColumnName("target_user");

            entity.HasOne(d => d.ReplyParent).WithMany(p => p.InverseReplyParent)
                .HasForeignKey(d => d.ReplyParentId)
                .HasConstraintName("FK__Post__reply_pare__5070F446");

            entity.HasOne(d => d.Sender).WithMany(p => p.PostSenders)
                .HasForeignKey(d => d.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Post__sender_id__4F7CD00D");

            entity.HasOne(d => d.TargetEventNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TargetEvent)
                .HasConstraintName("FK__Post__target_eve__5441852A");

            entity.HasOne(d => d.TargetGroupNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TargetGroup)
                .HasConstraintName("FK__Post__target_gro__52593CB8");

            entity.HasOne(d => d.TargetTopicNavigation).WithMany(p => p.Posts)
                .HasForeignKey(d => d.TargetTopic)
                .HasConstraintName("FK__Post__target_top__534D60F1");

            entity.HasOne(d => d.TargetUserNavigation).WithMany(p => p.PostTargetUserNavigations)
                .HasForeignKey(d => d.TargetUser)
                .HasConstraintName("FK__Post__target_use__5165187F");
        });

        modelBuilder.Entity<Rsvp>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.EventId }).HasName("PK__RSVP__DB89387D8F676362");

            entity.ToTable("RSVP");

            entity.Property(e => e.UserId).HasColumnName("user_id");
            entity.Property(e => e.EventId).HasColumnName("event_id");
            entity.Property(e => e.GuestCount).HasColumnName("guest_count");
            entity.Property(e => e.LastUpdated)
                .HasColumnType("datetime")
                .HasColumnName("last_updated");

            entity.HasOne(d => d.Event).WithMany(p => p.Rsvps)
                .HasForeignKey(d => d.EventId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RSVP__event_id__4CA06362");

            entity.HasOne(d => d.User).WithMany(p => p.Rsvps)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__RSVP__user_id__4BAC3F29");
        });

        modelBuilder.Entity<Topic>(entity =>
        {
            entity.HasKey(e => e.TopicId).HasName("PK__Topic__D5DAA3E900D3D5A0");

            entity.ToTable("Topic");

            entity.Property(e => e.TopicId).HasColumnName("topic_id");
            entity.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnName("description");
            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("name");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
