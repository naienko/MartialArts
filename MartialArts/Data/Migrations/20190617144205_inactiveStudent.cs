using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialArts.Data.Migrations
{
    public partial class inactiveStudent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "1aa72924-31fc-4e21-9d8c-a930b9205b42");

            migrationBuilder.AddColumn<bool>(
                name: "Active",
                table: "Student",
                nullable: false,
                defaultValue: false);

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "FirstName", "LastName", "Phone" },
            //    values: new object[] { "6c2bbc08-6667-4069-bedd-af66e039edc3", 0, "c8e2fe57-9c55-4568-b874-e3acf2908129", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAGe/ZUhMJGTm9kVI3lnlpJJolXNiL9K8ri77cM/SPyROn3tP4frKYTrE/5+x7y9qA==", null, false, "fb04266c-fa4c-49b0-968c-3c1689cd84ed", false, "admin@admin.com", "3804 Round Rock Dr Antioch TN 37013", "Panya", "Farnette", "(615) 438-2777" });

            //migrationBuilder.UpdateData(
            //    table: "Class",
            //    keyColumn: "Id",
            //    keyValue: 1,
            //    columns: new[] { "EndTime", "StartTime" },
            //    values: new object[] { new DateTime(2019, 6, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 17, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            //migrationBuilder.UpdateData(
            //    table: "Class",
            //    keyColumn: "Id",
            //    keyValue: 2,
            //    columns: new[] { "EndTime", "StartTime" },
            //    values: new object[] { new DateTime(2019, 6, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) });

            //migrationBuilder.CreateIndex(
            //    name: "IX_Student_InternalRankId",
            //    table: "Student",
            //    column: "InternalRankId");

            //migrationBuilder.AddForeignKey(
            //    name: "FK_Student_Rank_InternalRankId",
            //    table: "Student",
            //    column: "InternalRankId",
            //    principalTable: "Rank",
            //    principalColumn: "Id",
            //    onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Student_Rank_InternalRankId",
                table: "Student");

            migrationBuilder.DropIndex(
                name: "IX_Student_InternalRankId",
                table: "Student");

            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "6c2bbc08-6667-4069-bedd-af66e039edc3");

            migrationBuilder.DropColumn(
                name: "Active",
                table: "Student");

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "FirstName", "LastName", "Phone" },
                values: new object[] { "1aa72924-31fc-4e21-9d8c-a930b9205b42", 0, "3bb2d1c7-4ca2-418e-9fd8-b74b4ac8bdef", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEEC26SrdaXq0Rt/vuijzoeJ+A6+dakQEymdvAzEhsPZQGcICzy2e2vfnkamnprINTQ==", null, false, "d1b2fa7d-56c9-4fc1-81fa-f28ca9530f54", false, "admin@admin.com", "3804 Round Rock Dr Antioch TN 37013", "Panya", "Farnette", "(615) 438-2777" });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2019, 6, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 11, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "EndTime", "StartTime" },
                values: new object[] { new DateTime(2019, 6, 11, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 11, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
