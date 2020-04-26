using Microsoft.EntityFrameworkCore.Migrations;

namespace BikeRentalAgency.Migrations
{
    public partial class ConsolidationUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReservationDetails");

            migrationBuilder.AddColumn<string>(
                name: "BranchEmail",
                table: "Locations",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "ReservationsId",
                table: "Bikes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Bikes_ReservationsId",
                table: "Bikes",
                column: "ReservationsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bikes_Reservations_ReservationsId",
                table: "Bikes",
                column: "ReservationsId",
                principalTable: "Reservations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bikes_Reservations_ReservationsId",
                table: "Bikes");

            migrationBuilder.DropIndex(
                name: "IX_Bikes_ReservationsId",
                table: "Bikes");

            migrationBuilder.DropColumn(
                name: "BranchEmail",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "ReservationsId",
                table: "Bikes");

            migrationBuilder.CreateTable(
                name: "ReservationDetails",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BikeId = table.Column<int>(type: "int", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false),
                    ReservationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReservationDetails", x => x.Id);
                });
        }
    }
}
