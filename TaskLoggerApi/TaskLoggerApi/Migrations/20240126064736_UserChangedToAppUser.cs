using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TaskLoggerApi.Migrations
{
    /// <inheritdoc />
    public partial class UserChangedToAppUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UsersUserId",
                table: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Users",
                newName: "AppUserId");

            migrationBuilder.RenameColumn(
                name: "UsersUserId",
                table: "UserGroups",
                newName: "UsersAppUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UsersUserId",
                table: "UserGroups",
                newName: "IX_UserGroups_UsersAppUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UsersAppUserId",
                table: "UserGroups",
                column: "UsersAppUserId",
                principalTable: "Users",
                principalColumn: "AppUserId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserGroups_Users_UsersAppUserId",
                table: "UserGroups");

            migrationBuilder.RenameColumn(
                name: "AppUserId",
                table: "Users",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "UsersAppUserId",
                table: "UserGroups",
                newName: "UsersUserId");

            migrationBuilder.RenameIndex(
                name: "IX_UserGroups_UsersAppUserId",
                table: "UserGroups",
                newName: "IX_UserGroups_UsersUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserGroups_Users_UsersUserId",
                table: "UserGroups",
                column: "UsersUserId",
                principalTable: "Users",
                principalColumn: "UserId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
