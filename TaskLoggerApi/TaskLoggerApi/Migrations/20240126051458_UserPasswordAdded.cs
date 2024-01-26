using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskLoggerApi.Migrations
{
    /// <inheritdoc />
    public partial class UserPasswordAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Groups",
                keyColumn: "GroupsId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "TasksId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserId",
                keyValue: 3);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Users",
                type: "varbinary(max)",
                nullable: false,
                defaultValue: new byte[0]);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Users");

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "Role", "UserName" },
                values: new object[,]
                {
                    { 1, 0, "admin" },
                    { 2, 1, "manager" },
                    { 3, 2, "user" }
                });

            migrationBuilder.InsertData(
                table: "Groups",
                columns: new[] { "GroupsId", "GroupsName", "ManagerId" },
                values: new object[] { 1, "Development", 2 });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "TasksId", "CreatedDate", "Description", "IsCompleted", "Title", "UserId" },
                values: new object[] { 1, new DateTime(2024, 1, 24, 22, 13, 25, 515, DateTimeKind.Local).AddTicks(2486), "This is a seeded task", false, "Initial Task", 3 });
        }
    }
}
