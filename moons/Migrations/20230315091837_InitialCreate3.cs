using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace moons.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ExtraMoonImage");

            migrationBuilder.DropTable(
                name: "ExtraPlanetImage");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExtraMoonImage",
                columns: table => new
                {
                    ExtraImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MoonId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraMoonImage", x => x.ExtraImageId);
                    table.ForeignKey(
                        name: "FK_ExtraMoonImage_Moon_MoonId",
                        column: x => x.MoonId,
                        principalTable: "Moon",
                        principalColumn: "MoonId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ExtraPlanetImage",
                columns: table => new
                {
                    ExtraImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PlanetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExtraPlanetImage", x => x.ExtraImageId);
                    table.ForeignKey(
                        name: "FK_ExtraPlanetImage_Planet_PlanetId",
                        column: x => x.PlanetId,
                        principalTable: "Planet",
                        principalColumn: "PlanetId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ExtraMoonImage_MoonId",
                table: "ExtraMoonImage",
                column: "MoonId");

            migrationBuilder.CreateIndex(
                name: "IX_ExtraPlanetImage_PlanetId",
                table: "ExtraPlanetImage",
                column: "PlanetId");
        }
    }
}
