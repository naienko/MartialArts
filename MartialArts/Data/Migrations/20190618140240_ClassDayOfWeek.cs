using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MartialArts.Data.Migrations
{
    public partial class ClassDayOfWeek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            //migrationBuilder.DeleteData(
            //    table: "AspNetUsers",
            //    keyColumn: "Id",
            //    keyValue: "6c2bbc08-6667-4069-bedd-af66e039edc3");

            migrationBuilder.AlterColumn<int>(
                name: "DayOfWeek",
                table: "Class",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Attendance_Class",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            //migrationBuilder.InsertData(
            //    table: "AspNetUsers",
            //    columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "FirstName", "LastName", "Phone" },
            //    values: new object[] { "8927b935-ed00-4063-951e-5e6e8aee8d1e", 0, "164ec6fe-9318-4437-947c-6fd7fe856e45", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAELugKhT8st27f4mi3gZARhDnzPoT6rAdZV3Y1GptzRF3W2cLY4Jp2jffa+YCByQxnA==", null, false, "cf932f17-8443-452e-b71e-75c19d0c97e0", false, "admin@admin.com", "3804 Round Rock Dr Antioch TN 37013", "Panya", "Farnette", "(615) 438-2777" });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfWeek", "EndTime", "StartTime" },
                values: new object[] { 2, new DateTime(2019, 6, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 18, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DayOfWeek", "EndTime", "StartTime" },
                values: new object[] { 3, new DateTime(2019, 6, 18, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 18, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "8927b935-ed00-4063-951e-5e6e8aee8d1e");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Attendance_Class");

            migrationBuilder.AlterColumn<string>(
                name: "DayOfWeek",
                table: "Class",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Discriminator", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName", "Address", "FirstName", "LastName", "Phone" },
                values: new object[] { "6c2bbc08-6667-4069-bedd-af66e039edc3", 0, "c8e2fe57-9c55-4568-b874-e3acf2908129", "ApplicationUser", "admin@admin.com", true, false, null, "ADMIN@ADMIN.COM", "ADMIN@ADMIN.COM", "AQAAAAEAACcQAAAAEAGe/ZUhMJGTm9kVI3lnlpJJolXNiL9K8ri77cM/SPyROn3tP4frKYTrE/5+x7y9qA==", null, false, "fb04266c-fa4c-49b0-968c-3c1689cd84ed", false, "admin@admin.com", "3804 Round Rock Dr Antioch TN 37013", "Panya", "Farnette", "(615) 438-2777" });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DayOfWeek", "EndTime", "StartTime" },
                values: new object[] { "Tuesday", new DateTime(2019, 6, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 17, 17, 30, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Class",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DayOfWeek", "EndTime", "StartTime" },
                values: new object[] { "Wednesday", new DateTime(2019, 6, 17, 19, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(2019, 6, 17, 18, 0, 0, 0, DateTimeKind.Unspecified) });
        }
    }
}
