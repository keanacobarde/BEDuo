using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace BEDuo.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Classes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    isPublic = table.Column<bool>(type: "boolean", nullable: false),
                    UserId = table.Column<int>(type: "integer", nullable: false),
                    University = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Notes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ClassId = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Title = table.Column<string>(type: "text", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    UserID = table.Column<int>(type: "integer", nullable: false),
                    IsPublic = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Username = table.Column<string>(type: "text", nullable: false),
                    UserImageURL = table.Column<string>(type: "text", nullable: true),
                    University = table.Column<string>(type: "text", nullable: true),
                    Uid = table.Column<string>(type: "text", nullable: false),
                    Bio = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClassesSchedule",
                columns: table => new
                {
                    ClassesId = table.Column<int>(type: "integer", nullable: false),
                    SchedulesId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClassesSchedule", x => new { x.ClassesId, x.SchedulesId });
                    table.ForeignKey(
                        name: "FK_ClassesSchedule_Classes_ClassesId",
                        column: x => x.ClassesId,
                        principalTable: "Classes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClassesSchedule_Schedules_SchedulesId",
                        column: x => x.SchedulesId,
                        principalTable: "Schedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Classes",
                columns: new[] { "Id", "Description", "EndDate", "Name", "StartDate", "University", "UserId", "isPublic" },
                values: new object[,]
                {
                    { 1, "An introductory course on basic mathematics.", new DateTime(2025, 5, 31, 10, 0, 0, 0, DateTimeKind.Unspecified), "Mathematics 101", new DateTime(2024, 9, 1, 9, 0, 0, 0, DateTimeKind.Unspecified), "Western Governor's University", 1, true },
                    { 2, "A comprehensive study of English literature.", new DateTime(2025, 5, 31, 12, 30, 0, 0, DateTimeKind.Unspecified), "English Literature", new DateTime(2024, 9, 1, 11, 0, 0, 0, DateTimeKind.Unspecified), "Western Governor's University", 1, true },
                    { 3, "An advanced course on classical and modern physics.", new DateTime(2025, 5, 31, 15, 30, 0, 0, DateTimeKind.Unspecified), "Physics", new DateTime(2024, 9, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), "Western Governor's University", 2, true },
                    { 4, "An exploration of art history from ancient to modern times.", new DateTime(2025, 5, 31, 17, 30, 0, 0, DateTimeKind.Unspecified), "Art History", new DateTime(2024, 9, 1, 16, 0, 0, 0, DateTimeKind.Unspecified), null, 2, true },
                    { 5, "Learn the basics of cooking, including recipes and techniques.", new DateTime(2024, 12, 15, 19, 30, 0, 0, DateTimeKind.Unspecified), "Cooking Basics", new DateTime(2024, 9, 1, 18, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true },
                    { 6, "A class on the fundamentals of photography.", new DateTime(2024, 12, 15, 11, 30, 0, 0, DateTimeKind.Unspecified), "Photography", new DateTime(2024, 10, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), null, 1, true }
                });

            migrationBuilder.InsertData(
                table: "Notes",
                columns: new[] { "Id", "ClassId", "DateCreated", "Description" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Introduction to basic algebra. Today's class was really boring. -Caleb" },
                    { 2, 1, new DateTime(2024, 9, 3, 0, 0, 0, 0, DateTimeKind.Unspecified), "Went over Shakespeare today. A really interesting dude, I guess. Study session at 5 PM? - Mindy" },
                    { 3, 3, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "I do not know what I may appear to the world, but to myself I seem to have been only like a boy playing on the seashore, and diverting myself in now and then finding a smoother pebble or a prettier shell than ordinary, whilst the great ocean of truth lay all undiscovered before me. - Issac Newton" },
                    { 4, 4, new DateTime(2024, 9, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "The Renaissance and its impact on art." },
                    { 5, 5, new DateTime(2024, 9, 6, 0, 0, 0, 0, DateTimeKind.Unspecified), "Basic knife skills and safety." },
                    { 6, 6, new DateTime(2024, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Understanding camera settings and functions." },
                    { 7, 3, new DateTime(2024, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Physics is hard. - Max" }
                });

            migrationBuilder.InsertData(
                table: "Schedules",
                columns: new[] { "Id", "EndDate", "IsPublic", "StartDate", "Title", "UserID" },
                values: new object[,]
                {
                    { 1, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "A.P. Exams", 1 },
                    { 2, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), false, new DateTime(2023, 8, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Programming", 1 },
                    { 3, new DateTime(2024, 9, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), true, new DateTime(2023, 10, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), "Music", 2 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Bio", "Uid", "University", "UserImageURL", "Username" },
                values: new object[,]
                {
                    { 1, "Night Owl looking to learn!", "RjGMb2h53VelT6Mis05ekXrRxvG2", "Western Governor's University", null, "kikilearn" },
                    { 2, "THS <3, cat mom first, AP student second.", "EBdW2g5N9xddUcK048GpXjvaUrq1", null, null, "zel" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClassesSchedule_SchedulesId",
                table: "ClassesSchedule",
                column: "SchedulesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClassesSchedule");

            migrationBuilder.DropTable(
                name: "Notes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Classes");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
