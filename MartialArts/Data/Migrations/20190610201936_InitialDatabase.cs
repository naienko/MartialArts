using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialArts.Data.Migrations
{
    public partial class InitialDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Phone",
                table: "AspNetUsers",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Address = table.Column<string>(nullable: false),
                    Phone = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: false),
                    FirstClass = table.Column<DateTime>(nullable: false),
                    InternalRankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Style",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 100, nullable: false),
                    Description = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Style", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: false),
                    IsTesting = table.Column<bool>(nullable: false),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Location = table.Column<string>(nullable: true),
                    LocationNotes = table.Column<string>(nullable: true),
                    StaffId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Event_Student_StaffId",
                        column: x => x.StaffId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StartTime = table.Column<DateTime>(nullable: false),
                    EndTime = table.Column<DateTime>(nullable: false),
                    DayOfWeek = table.Column<string>(nullable: true),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Class_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Rank",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    TimeInRank = table.Column<string>(nullable: false),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rank", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Rank_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance_Test",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    EventId = table.Column<int>(nullable: false),
                    did_pass = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance_Test", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Test_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Test_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventStyle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    EventId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventStyle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventStyle_Event_EventId",
                        column: x => x.EventId,
                        principalTable: "Event",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventStyle_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Attendance_Class",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    ClassId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Attendance_Class", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Attendance_Class_Class_ClassId",
                        column: x => x.ClassId,
                        principalTable: "Class",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Attendance_Class_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Form",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    RankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Form", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Form_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Form_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentStyle",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    RankId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentStyle", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentStyle_Rank_RankId",
                        column: x => x.RankId,
                        principalTable: "Rank",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStyle_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentStyle_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentForms",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    StudentId = table.Column<int>(nullable: false),
                    StyleId = table.Column<int>(nullable: false),
                    FormId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentForms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentForms_Form_FormId",
                        column: x => x.FormId,
                        principalTable: "Form",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentForms_Student_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentForms_Style_StyleId",
                        column: x => x.StyleId,
                        principalTable: "Style",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "FirstName", "LastName", "Phone" },
                values: new object[] { "07df3208-07fc-4661-920c-8e1f02316760", 0, "d0053eb2-e654-4aeb-842f-2b84c7b9b4fc", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEKH1qLZDHRXnPDm5oKhlHtAg9rJoBCHfVj8MTfutHm0ugkZZZ5rtByo3HM5Of1pwgA==", null, false, "782abf4a-0990-432c-b547-71297ecf01e4", false, "admin@admin.com", "3804 Round Rock Dr Antioch TN 37013", "Panya", "Farnette", "(615) 438-2777" });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Name", "StyleId", "TimeInRank" },
                values: new object[,]
                {
                    { 2, "Senior Instructor", 0, "0 invalid" },
                    { 1, "Student", 0, "0 invalid" }
                });

            migrationBuilder.InsertData(
                table: "Student",
                columns: new[] { "Id", "Address", "Email", "FirstClass", "FirstName", "InternalRankId", "LastName", "Phone" },
                values: new object[,]
                {
                    { 1, "3804 Round Rock", "oddball79@gmail.com", new DateTime(1990, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Michael", 2, "Farnette", null },
                    { 2, "3804 Round Rock", "naienko@gmail.com", new DateTime(2008, 9, 4, 0, 0, 0, 0, DateTimeKind.Unspecified), "Panya", 1, "Farnette", null }
                });

            migrationBuilder.InsertData(
                table: "Style",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[,]
                {
                    { 1, "pseudo-style to hold ranks internal to the school", "Internal" },
                    { 2, "A style focused on kicking", "Tae Kwon Do" }
                });

            migrationBuilder.InsertData(
                table: "Class",
                columns: new[] { "Id", "DayOfWeek", "EndTime", "StartTime", "StyleId" },
                values: new object[,]
                {
                    { 1, "Tuesday", new DateTime(2019, 6, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 17, 30, 0, 0, DateTimeKind.Unspecified), 2 },
                    { 2, "Wednesday", new DateTime(2019, 6, 10, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 10, 18, 0, 0, 0, DateTimeKind.Unspecified), 2 }
                });

            migrationBuilder.InsertData(
                table: "Event",
                columns: new[] { "Id", "Description", "EndTime", "IsTesting", "Location", "LocationNotes", "StaffId", "StartTime", "Title" },
                values: new object[] { 1, "testing", new DateTime(2019, 6, 9, 17, 0, 0, 0, DateTimeKind.Unspecified), true, "4908-B Charlotte Ave Nashville TN 37209", "parking available across the street", 1, new DateTime(2019, 6, 9, 9, 0, 0, 0, DateTimeKind.Unspecified), "Testing" });

            migrationBuilder.InsertData(
                table: "Rank",
                columns: new[] { "Id", "Name", "StyleId", "TimeInRank" },
                values: new object[] { 3, "White Belt", 1, "2 months" });

            migrationBuilder.InsertData(
                table: "Form",
                columns: new[] { "Id", "Name", "RankId", "StyleId" },
                values: new object[] { 1, "Basic One", 3, 2 });

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Class_ClassId",
                table: "Attendance_Class",
                column: "ClassId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Class_StudentId",
                table: "Attendance_Class",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Test_EventId",
                table: "Attendance_Test",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_Attendance_Test_StudentId",
                table: "Attendance_Test",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Class_StyleId",
                table: "Class",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Event_StaffId",
                table: "Event",
                column: "StaffId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStyle_EventId",
                table: "EventStyle",
                column: "EventId");

            migrationBuilder.CreateIndex(
                name: "IX_EventStyle_StyleId",
                table: "EventStyle",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_RankId",
                table: "Form",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_Form_StyleId",
                table: "Form",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_Rank_StyleId",
                table: "Rank",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentForms_FormId",
                table: "StudentForms",
                column: "FormId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentForms_StudentId",
                table: "StudentForms",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentForms_StyleId",
                table: "StudentForms",
                column: "StyleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStyle_RankId",
                table: "StudentStyle",
                column: "RankId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStyle_StudentId",
                table: "StudentStyle",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentStyle_StyleId",
                table: "StudentStyle",
                column: "StyleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Attendance_Class");

            migrationBuilder.DropTable(
                name: "Attendance_Test");

            migrationBuilder.DropTable(
                name: "EventStyle");

            migrationBuilder.DropTable(
                name: "StudentForms");

            migrationBuilder.DropTable(
                name: "StudentStyle");

            migrationBuilder.DropTable(
                name: "Class");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Form");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropTable(
                name: "Rank");

            migrationBuilder.DropTable(
                name: "Style");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "07df3208-07fc-4661-920c-8e1f02316760");

            migrationBuilder.DropColumn(
                name: "Address",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Phone",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "AspNetUsers");
        }
    }
}
