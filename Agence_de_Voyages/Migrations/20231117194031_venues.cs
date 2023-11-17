using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Agence_de_Voyages.Migrations
{
    /// <inheritdoc />
    public partial class venues : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Venues",
                columns: table => new
                {
                    VenueId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Rating = table.Column<int>(type: "int", nullable: false),
                    CostIndicator = table.Column<int>(type: "int", nullable: false),
                    HasFreeWiFi = table.Column<bool>(type: "bit", nullable: false),
                    PricePerNight = table.Column<int>(type: "int", nullable: true),
                    CuisineType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EntryFee = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Venues", x => x.VenueId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Venues");
        }
    }
}
