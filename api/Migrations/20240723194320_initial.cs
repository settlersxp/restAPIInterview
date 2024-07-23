using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace api.Migrations
{
    /// <inheritdoc />
    public partial class initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "WeatherLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<string>(type: "TEXT", nullable: false),
                    TemperatureC = table.Column<decimal>(type: "decimal(3, 2)", nullable: false),
                    Summary = table.Column<int>(type: "INTEGER", nullable: true),
                    TemperatureF = table.Column<decimal>(type: "decimal(3, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WeatherLocation", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WeatherLocation");
        }
    }
}
