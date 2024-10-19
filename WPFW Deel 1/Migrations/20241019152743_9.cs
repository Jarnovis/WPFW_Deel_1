using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFW_Deel_1.Migrations
{
    /// <inheritdoc />
    public partial class _9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Student_StudentId",
                table: "Teacher");

            migrationBuilder.DropIndex(
                name: "IX_Teacher_StudentId",
                table: "Teacher");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "Teacher");

            migrationBuilder.CreateTable(
                name: "StudentTeacher",
                columns: table => new
                {
                    studentsId = table.Column<int>(type: "INTEGER", nullable: false),
                    teachersId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentTeacher", x => new { x.studentsId, x.teachersId });
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Student_studentsId",
                        column: x => x.studentsId,
                        principalTable: "Student",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentTeacher_Teacher_teachersId",
                        column: x => x.teachersId,
                        principalTable: "Teacher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StudentTeacher_teachersId",
                table: "StudentTeacher",
                column: "teachersId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StudentTeacher");

            migrationBuilder.AddColumn<int>(
                name: "StudentId",
                table: "Teacher",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teacher_StudentId",
                table: "Teacher",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Student_StudentId",
                table: "Teacher",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }
    }
}
