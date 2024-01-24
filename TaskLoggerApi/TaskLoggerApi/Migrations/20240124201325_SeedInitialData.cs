using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TaskLoggerApi.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserPools_Groups_GroupsId",
                table: "UserPools");

            migrationBuilder.DropForeignKey(
                name: "FK_UserPools_Users_UsersUserId",
                table: "UserPools");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserPools",
                table: "UserPools");

            migrationBuilder.RenameTable(
                name: "UserPools",
                newName: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "GroupName",
                table: "Groups",
                newName: "GroupsName");

            migrationBuilder.RenameIndex(
                name: "IX_UserPools_UsersUserId",
                table: "UserGroups",
                newName: "IX_UserGroups_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups",
                columns: new[] { "GroupsId", "UsersUserId" });

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

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Groups_GroupsId",
                table: "UserGroups",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "GroupsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UsersUserId",
                table: "UserGroups",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Groups_GroupsId",
                table: "UserGroups");

            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UsersUserId",
                table: "UserGroups");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UserGroups",
                table: "UserGroups");

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

            migrationBuilder.RenameTable(
                name: "UserGroups",
                newName: "UserPools");

            migrationBuilder.RenameColumn(
                name: "GroupsName",
                table: "Groups",
                newName: "GroupName");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UsersUserId",
                table: "UserPools",
                newName: "IX_UserPools_UsersUserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UserPools",
                table: "UserPools",
                columns: new[] { "GroupsId", "UsersUserId" });

            migrationBuilder.AddForeignKey(
                name: "FK_UserPools_Groups_GroupsId",
                table: "UserPools",
                column: "GroupsId",
                principalTable: "Groups",
                principalColumn: "GroupsId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserPools_Users_UsersUserId",
                table: "UserPools",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
