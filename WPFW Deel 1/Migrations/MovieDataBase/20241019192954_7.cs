using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WPFW_Deel_1.Migrations.MovieDataBase
{
    /// <inheritdoc />
    public partial class _7 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DirectorMovie",
                columns: table => new
                {
                    directorid = table.Column<int>(type: "INTEGER", nullable: false),
                    moviesid = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DirectorMovie", x => new { x.directorid, x.moviesid });
                    table.ForeignKey(
                        name: "FK_DirectorMovie_directors_directorid",
                        column: x => x.directorid,
                        principalTable: "directors",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DirectorMovie_movies_moviesid",
                        column: x => x.moviesid,
                        principalTable: "movies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DirectorMovie_moviesid",
                table: "DirectorMovie",
                column: "moviesid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DirectorMovie");
        }
    }
}
