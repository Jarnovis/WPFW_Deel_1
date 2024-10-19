using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFW_Deel_1.Migrations
{
    /// <inheritdoc />
    public partial class _5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "User",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "studentId",
                table: "Grade",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_User_StudentId",
                table: "User",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Grade_studentId",
                table: "Grade",
                column: "studentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_User_studentId",
                table: "Grade",
                column: "studentId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_User_StudentId",
                table: "User",
                column: "StudentId",
                principalTable: "User",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_User_studentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_StudentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_StudentId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Grade_studentId",
                table: "Grade");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "studentId",
                table: "Grade");
        }
    }
}
