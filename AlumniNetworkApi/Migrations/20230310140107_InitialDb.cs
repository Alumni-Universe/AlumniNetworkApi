using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AlumniNetworkApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AlumniUser",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    picture = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    status = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    bio = table.Column<string>(type: "text", nullable: true),
                    fun_fact = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AlumniUs__B9BE370FB48C207B", x => x.user_id);
                });

            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    topic_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Topic__D5DAA3E99DC2689F", x => x.topic_id);
                });

            migrationBuilder.CreateTable(
                name: "AlumniGroup",
                columns: table => new
                {
                    group_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    is_private = table.Column<bool>(type: "bit", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__AlumniGr__D57795A029A768D7", x => x.group_id);
                    table.ForeignKey(
                        name: "FK__AlumniGro__creat__4BAC3F29",
                        column: x => x.created_by,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    allow_guests = table.Column<bool>(type: "bit", nullable: false),
                    banner_img = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: true),
                    start_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    end_time = table.Column<DateTime>(type: "datetime", nullable: false),
                    created_by = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Event__2370F727C1FB703A", x => x.event_id);
                    table.ForeignKey(
                        name: "FK__Event__created_b__5070F446",
                        column: x => x.created_by,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "TopicMember",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    topic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__TopicMem__34E39D3103B88F96", x => new { x.user_id, x.topic_id });
                    table.ForeignKey(
                        name: "FK__TopicMemb__topic__6EF57B66",
                        column: x => x.topic_id,
                        principalTable: "Topic",
                        principalColumn: "topic_id");
                    table.ForeignKey(
                        name: "FK__TopicMemb__user___6E01572D",
                        column: x => x.user_id,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "GroupMember",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__GroupMem__A4E94E551A5715B1", x => new { x.user_id, x.group_id });
                    table.ForeignKey(
                        name: "FK__GroupMemb__group__5441852A",
                        column: x => x.group_id,
                        principalTable: "AlumniGroup",
                        principalColumn: "group_id");
                    table.ForeignKey(
                        name: "FK__GroupMemb__user___534D60F1",
                        column: x => x.user_id,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "EventGroupInvite",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false),
                    group_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventGro__3E278E7D001DEEA7", x => new { x.event_id, x.group_id });
                    table.ForeignKey(
                        name: "FK__EventGrou__event__5AEE82B9",
                        column: x => x.event_id,
                        principalTable: "Event",
                        principalColumn: "event_id");
                    table.ForeignKey(
                        name: "FK__EventGrou__group__5BE2A6F2",
                        column: x => x.group_id,
                        principalTable: "AlumniGroup",
                        principalColumn: "group_id");
                });

            migrationBuilder.CreateTable(
                name: "EventTopicInvite",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false),
                    topic_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventTop__AE2D5D19BF8C0416", x => new { x.event_id, x.topic_id });
                    table.ForeignKey(
                        name: "FK__EventTopi__event__6A30C649",
                        column: x => x.event_id,
                        principalTable: "Event",
                        principalColumn: "event_id");
                    table.ForeignKey(
                        name: "FK__EventTopi__topic__6B24EA82",
                        column: x => x.topic_id,
                        principalTable: "Topic",
                        principalColumn: "topic_id");
                });

            migrationBuilder.CreateTable(
                name: "EventUserInvite",
                columns: table => new
                {
                    event_id = table.Column<int>(type: "int", nullable: false),
                    user_id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__EventUse__C8EB14572252FAAC", x => new { x.event_id, x.user_id });
                    table.ForeignKey(
                        name: "FK__EventUser__event__571DF1D5",
                        column: x => x.event_id,
                        principalTable: "Event",
                        principalColumn: "event_id");
                    table.ForeignKey(
                        name: "FK__EventUser__user___5812160E",
                        column: x => x.user_id,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "Post",
                columns: table => new
                {
                    post_id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    last_updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    post_message = table.Column<string>(type: "text", nullable: true),
                    post_target = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    sender_id = table.Column<int>(type: "int", nullable: false),
                    reply_parent_id = table.Column<int>(type: "int", nullable: false),
                    target_user = table.Column<int>(type: "int", nullable: true),
                    target_group = table.Column<int>(type: "int", nullable: true),
                    target_topic = table.Column<int>(type: "int", nullable: true),
                    target_event = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__Post__3ED7876664865E6C", x => x.post_id);
                    table.ForeignKey(
                        name: "FK__Post__reply_pare__6383C8BA",
                        column: x => x.reply_parent_id,
                        principalTable: "Post",
                        principalColumn: "post_id");
                    table.ForeignKey(
                        name: "FK__Post__sender_id__628FA481",
                        column: x => x.sender_id,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                    table.ForeignKey(
                        name: "FK__Post__target_eve__6754599E",
                        column: x => x.target_event,
                        principalTable: "Event",
                        principalColumn: "event_id");
                    table.ForeignKey(
                        name: "FK__Post__target_gro__656C112C",
                        column: x => x.target_group,
                        principalTable: "AlumniGroup",
                        principalColumn: "group_id");
                    table.ForeignKey(
                        name: "FK__Post__target_top__66603565",
                        column: x => x.target_topic,
                        principalTable: "Topic",
                        principalColumn: "topic_id");
                    table.ForeignKey(
                        name: "FK__Post__target_use__6477ECF3",
                        column: x => x.target_user,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateTable(
                name: "RSVP",
                columns: table => new
                {
                    user_id = table.Column<int>(type: "int", nullable: false),
                    event_id = table.Column<int>(type: "int", nullable: false),
                    last_updated = table.Column<DateTime>(type: "datetime", nullable: false),
                    guest_count = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__RSVP__DB89387D413DA912", x => new { x.user_id, x.event_id });
                    table.ForeignKey(
                        name: "FK__RSVP__event_id__5FB337D6",
                        column: x => x.event_id,
                        principalTable: "Event",
                        principalColumn: "event_id");
                    table.ForeignKey(
                        name: "FK__RSVP__user_id__5EBF139D",
                        column: x => x.user_id,
                        principalTable: "AlumniUser",
                        principalColumn: "user_id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlumniGroup_created_by",
                table: "AlumniGroup",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_Event_created_by",
                table: "Event",
                column: "created_by");

            migrationBuilder.CreateIndex(
                name: "IX_EventGroupInvite_group_id",
                table: "EventGroupInvite",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_EventTopicInvite_topic_id",
                table: "EventTopicInvite",
                column: "topic_id");

            migrationBuilder.CreateIndex(
                name: "IX_EventUserInvite_user_id",
                table: "EventUserInvite",
                column: "user_id");

            migrationBuilder.CreateIndex(
                name: "IX_GroupMember_group_id",
                table: "GroupMember",
                column: "group_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_reply_parent_id",
                table: "Post",
                column: "reply_parent_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_sender_id",
                table: "Post",
                column: "sender_id");

            migrationBuilder.CreateIndex(
                name: "IX_Post_target_event",
                table: "Post",
                column: "target_event");

            migrationBuilder.CreateIndex(
                name: "IX_Post_target_group",
                table: "Post",
                column: "target_group");

            migrationBuilder.CreateIndex(
                name: "IX_Post_target_topic",
                table: "Post",
                column: "target_topic");

            migrationBuilder.CreateIndex(
                name: "IX_Post_target_user",
                table: "Post",
                column: "target_user");

            migrationBuilder.CreateIndex(
                name: "IX_RSVP_event_id",
                table: "RSVP",
                column: "event_id");

            migrationBuilder.CreateIndex(
                name: "IX_TopicMember_topic_id",
                table: "TopicMember",
                column: "topic_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventGroupInvite");

            migrationBuilder.DropTable(
                name: "EventTopicInvite");

            migrationBuilder.DropTable(
                name: "EventUserInvite");

            migrationBuilder.DropTable(
                name: "GroupMember");

            migrationBuilder.DropTable(
                name: "Post");

            migrationBuilder.DropTable(
                name: "RSVP");

            migrationBuilder.DropTable(
                name: "TopicMember");

            migrationBuilder.DropTable(
                name: "AlumniGroup");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "AlumniUser");
        }
    }
}
