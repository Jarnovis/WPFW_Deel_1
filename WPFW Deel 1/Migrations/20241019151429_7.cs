using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFW_Deel_1.Migrations
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_User_studentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_User_User_StudentId",
                table: "User");

            migrationBuilder.DropTable(
                name: "GradeStudent");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "name",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Teacher");

            migrationBuilder.RenameIndex(
                name: "IX_User_StudentId",
                table: "Teacher",
                newName: "IX_Teacher_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "teachingCourse",
                table: "Teacher",
                type: "TEXT",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "TEXT",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Student",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    name = table.Column<string>(type: "TEXT", nullable: false),
                    email = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Student", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Grade_Student_studentId",
                table: "Grade",
                column: "studentId",
                principalTable: "Student",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Teacher_Student_StudentId",
                table: "Teacher",
                column: "StudentId",
                principalTable: "Student",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Grade_Student_studentId",
                table: "Grade");

            migrationBuilder.DropForeignKey(
                name: "FK_Teacher_Student_StudentId",
                table: "Teacher");

            migrationBuilder.DropTable(
                name: "Student");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Teacher",
                table: "Teacher");

            migrationBuilder.RenameTable(
                name: "Teacher",
                newName: "User");

            migrationBuilder.RenameIndex(
                name: "IX_Teacher_StudentId",
                table: "User",
                newName: "IX_User_StudentId");

            migrationBuilder.AlterColumn<string>(
                name: "teachingCourse",
                table: "User",
                type: "TEXT",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "TEXT");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                type: "TEXT",
                maxLength: 8,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "name",
                table: "User",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "GradeStudent",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    gradeId = table.Column<int>(type: "INTEGER", nullable: false),
                    studentId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GradeStudent", x => x.Id);
                });

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
    }
}
