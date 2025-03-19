using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace TakenlijstManager.Migrations
{
    /// <inheritdoc />
    public partial class SecondInitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
            migrationBuilder.DeleteData(
                table: "TakenLijst",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TakenLijst",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TakenLijst",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TakenLijst",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
