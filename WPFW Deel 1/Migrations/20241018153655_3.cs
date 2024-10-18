using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFW_Deel_1.Migrations
{
    /// <inheritdoc />
    public partial class _3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_User_userID1",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_userID1",
                table: "User");

            migrationBuilder.DropColumn(
                name: "userID1",
                table: "User");

            migrationBuilder.RenameColumn(
                name: "userID",
                table: "User",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "User",
                newName: "userID");

            migrationBuilder.AddColumn<int>(
                name: "userID1",
                table: "User",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_userID1",
                table: "User",
                column: "userID1");

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_userID1",
                table: "User",
                column: "userID1",
                principalTable: "User",
                principalColumn: "userID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
