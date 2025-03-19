using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TakenlijstManager.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StatusModel",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    VolgendeStatus = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StatusModel", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TakenLijst",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Naam = table.Column<string>(type: "TEXT", maxLength: 40, nullable: false),
                    Omvang = table.Column<int>(type: "INTEGER", nullable: false),
                    Prioriteit = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TakenLijst", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "TakenLijst",
                columns: new[] { "Id", "Naam", "Omvang", "Prioriteit" },
                values: new object[,]
                {
                    { 1, "Huiswerk Client", 5, 6 },
                    { 2, "Huiswerk Server", 3, 3 },
                    { 3, "Voorbereiden tentamen Client", 4, 10 },
                    { 4, "Voorbereiden tentamen Server", 5, 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StatusModel");

            migrationBuilder.DropTable(
                name: "TakenLijst");
        }
    }
}
